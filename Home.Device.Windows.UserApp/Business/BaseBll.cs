using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Security;
using System.Threading.Tasks;

namespace Home.Device.Windows.UserApp.Business
{
    public abstract class BaseBll
    {
        protected async Task<T> UploadData<T>(string url, object value)
        {
            return await UploadData<T, object>(url, value, "POST");
        }


        protected async Task<T> UploadData<T>(string url, object value, string method)
        {
            return await UploadData<T, object>(url, value, method);
        }

        protected async Task<T> UploadData<T, R>(string url, R value)
        {
            return await UploadData<T, R>(url, value, "POST");
        }

        protected async Task<T> UploadData<T, R>(string url, R value, string method)
        {
            for (int i = 0; i < 3; i++)
            {
                var cred = HomeDeviceHelper.GetSavedCredentials();
                if (cred == null)
                    throw new SecurityException();

                using (var cli = new WebClient())
                {
                    cli.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    cli.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + cred.Password);
                    cli.BaseAddress = cred.ServerUrl;

                    try
                    {
                        var ret = await cli.UploadStringTaskAsync(url,
                    method,
                    JsonConvert.SerializeObject(value));
                        var res = JsonConvert.DeserializeObject<T>(ret);
                        return res;
                    }
                    catch (WebException)
                    {
                        if (i < 2)
                            continue;
                        throw;
                    }
                }
            }

            return default;
        }

        protected async Task<T> DownloadData<T>(string url)
        {
            for (int i = 0; i < 3; i++)
            {
                var cred = HomeDeviceHelper.GetSavedCredentials();
                if (cred == null)
                    throw new SecurityException();

                using (var cli = new WebClient())
                {
                    cli.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    cli.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + cred.Password);
                    cli.BaseAddress = cred.ServerUrl;

                    try
                    {
                        var ret = await cli.DownloadStringTaskAsync(url);
                        var res = JsonConvert.DeserializeObject<T>(ret);
                        return res;
                    }
                    catch (WebException ex)
                    {
                        Debug.WriteLine(ex.Message);
                        if (i < 2)
                            continue;
                        throw;
                    }
                }
            }

            return default;
        }
    }
}
