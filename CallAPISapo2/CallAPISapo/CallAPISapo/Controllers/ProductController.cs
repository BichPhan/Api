using CallAPISapo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CallAPISapo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            //string URL = "https://bf1f4e5b519a4325834deefa3ebbbad9:03951cb96629424194705d98d292e7eb@phanbich-test.bizwebvietnam.net/admin/products.json";
            const string url = "https://phanbich-test.bizwebvietnam.net/admin/products.json";

            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Credentials = GetCredential(url);
            req.PreAuthenticate = true;

            string result = "";
            using (var resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("Call failed. Received HTTP {0}", resp.StatusCode);
                    throw new ApplicationException(message);
                }

                var sr = new StreamReader(resp.GetResponseStream());
                result = sr.ReadToEnd();
            }
            Products products = JsonConvert.DeserializeObject<Products>(result);

            return View(products);
        }

        private static CredentialCache GetCredential(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            var credentialCache = new CredentialCache();
            credentialCache.Add(new Uri(url), "Basic", new NetworkCredential("bf1f4e5b519a4325834deefa3ebbbad9", "03951cb96629424194705d98d292e7eb"));
            return credentialCache;
        }
    }
}