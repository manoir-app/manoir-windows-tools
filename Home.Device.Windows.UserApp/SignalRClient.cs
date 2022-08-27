using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Device.Windows.UserApp
{
    public static class SignalRClient
    {
        static HubConnection connection;

        public static async Task SetupSignalRClient()
        {
            var creds = HomeDeviceHelper.GetSavedCredentials();
            connection = new HubConnectionBuilder()
                  .WithUrl(creds.ServerUrl + "hubs/1.0/devices")
                  .WithAutomaticReconnect()
                  .Build();
            connection.Closed += Connection_Closed;

            await connection.StartAsync();
        }

        private async static Task Connection_Closed(Exception arg)
        {
            //await Task.Delay(new Random().Next(0, 5) * 1000);
            //await connection.StartAsync();
        }
    }
}
