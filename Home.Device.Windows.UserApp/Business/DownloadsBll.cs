using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Home.Device.Windows.UserApp.Business
{
    public class DownloadsBll : BaseBll
    {

        public class DirectDownloadRequest
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public async Task<bool> QueueMagnetDownload(string magnetUrl)
        {
            var tmp = HttpUtility.ParseQueryString(magnetUrl);
            var name = tmp["dn"];
            if (name == null)
                name = $"Download {DateTime.Now.ToString("yyyyMMdd-HHmmss")}";


            var url = $"/v1.0/downloads/direct/magnet";
            return await UploadData<bool, DirectDownloadRequest>(url, new DirectDownloadRequest()
            {
                Name = name,
                Url = magnetUrl,
            }, "POST");
        }
    }
}
