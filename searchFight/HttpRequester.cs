using System;

using System.IO;
using System.Net;
using System.Text;

namespace searchFight
{
    public class HttpRequester
    {
        public virtual string request(string url) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36";


            using (var response = (HttpWebResponse)(request.GetResponse()))
            {
                HttpStatusCode code = response.StatusCode;
                if (code == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            return "";
        }
    }
}
