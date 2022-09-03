using Home.Common.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home.Device.Windows.UserApp
{
    public static class SignalRClient
    {
        static HubConnection _deviceConnection;
        static string _deviceConnectionId = null;
        static HubConnection _userConnection;
        static string _userConnectionId = null;

        public static async Task SetupSignalRClient()
        {
            try
            {
                var creds = HomeDeviceHelper.GetSavedCredentials();
                _deviceConnection = new HubConnectionBuilder()
                      .WithUrl(creds.ServerUrl + "hubs/1.0/appanddevices")
                      .WithAutomaticReconnect()
                      .Build();
                _deviceConnection.Closed += DeviceConnection_Closed;

                await _deviceConnection.StartAsync();
                _deviceConnectionId = _deviceConnection.ConnectionId;

                _userConnection = new HubConnectionBuilder()
                      .WithUrl(creds.ServerUrl + "hubs/1.0/users")
                      .WithAutomaticReconnect()
                      .Build();

                _userConnection.Closed += UserConnection_Closed;
                _userConnection.Reconnected += UserConnection_Reconnected;

                _userConnection.On<string, UserNotification>("NewNotification", OnNewNotification);

                await _userConnection.StartAsync();
                await SendUserNewConnectionId(creds);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async static Task DeviceConnection_Closed(Exception arg)
        {
            //await Task.Delay(new Random().Next(0, 5) * 1000);
            //await connection.StartAsync();
        }


        private async static Task UserConnection_Closed(Exception arg)
        {
            //await Task.Delay(new Random().Next(0, 5) * 1000);
            //await _userConnection.re
        }

        private async static Task UserConnection_Reconnected(string arg)
        {
            var creds = HomeDeviceHelper.GetSavedCredentials();
            await SendUserNewConnectionId(creds);

        }

        private static async Task SendUserNewConnectionId(HomeDeviceHelper.Credentials creds)
        {
            if (_userConnectionId != null)
                await _userConnection.SendAsync("ClearUserConnectionId", creds.UserId, _userConnectionId);
            _userConnectionId = _userConnection.ConnectionId;
            await _userConnection.SendAsync("RegisterUserConnectionId", creds.UserId, _userConnectionId);
        }

        private static void OnNewNotification(string userId, UserNotification notification)
        {
            NotificationHelper.GenerateToast("", null, notification.Title, "", "");
            MessageBox.Show(notification.Title);

        }

    }
}
