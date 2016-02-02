using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IShare.Controllers.DpContrl
{
    public class DpControlController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Customer
        public ActionResult CustomerGetAll()
        {
            var requestUri = new Uri("http://localhost:44354//v1/Customers");
            var credCache = new CredentialCache
            {
                {
                    requestUri,
                    "Basic",// "Digest",
                    new NetworkCredential("Test", "Test_123", "localhost")
                }
            };
            using (var clientHander = new HttpClientHandler
            {
                Credentials = credCache,
                PreAuthenticate = true
            })
            using (var httpClient = new HttpClient(clientHander))
            {
                for (var i = 0; i < 5; i++)
                {
                    var responseTask = httpClient.GetAsync(requestUri);
                    var bb = responseTask.Result.Content.ReadAsStringAsync();
                    responseTask.Result.EnsureSuccessStatusCode();
                }
            }

            return Json("");
        }

        #endregion
    }
}
