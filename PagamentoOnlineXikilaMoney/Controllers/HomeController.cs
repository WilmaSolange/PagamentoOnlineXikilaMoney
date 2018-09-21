using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagamentoXM;

namespace PagamentoOnlineXikilaMoney.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "All the products.";

            return View();
        }

        public ActionResult SinglePost()
        {
            ViewBag.Message = "Blog";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Blog";

            return View();
        }

        public ActionResult Buying()
        {
            System.Diagnostics.Debug.Print("Estou no GetXikila");
            Class1 classe = new Class1();
           HomeController hc = new HomeController();

            System.Diagnostics.Debug.Print("Estou no Index");

            classe.SessionID = hc.getSessionIDS();

            System.Diagnostics.Debug.Print("\nSessionID \n" + classe.SessionID);

            ViewBag.SessionID = classe.SessionID;

            classe.MerchantID = "2769989316156566";
            ViewBag.MerchantID = classe.MerchantID;
            System.Diagnostics.Debug.Print("\nMerchantID \n" + classe.MerchantID);

            classe.Amount = 200000;
            ViewBag.Amount = classe.Amount;
            System.Diagnostics.Debug.Print("\nAmount \n" + classe.Amount);

            classe.Currency = 973;
            ViewBag.Currency = classe.Currency;
            System.Diagnostics.Debug.Print("\nCurrency\n" + classe.Currency);

            classe.PurchaseRef = "00001";
            ViewBag.PurchaseRef = classe.PurchaseRef;
            System.Diagnostics.Debug.Print("\nPurchaseRef \n" + classe.PurchaseRef);

            classe.Description = "testando dinamicamente";
            ViewBag.Description = classe.Description;
            System.Diagnostics.Debug.Print("\nDescription \n" + classe.Description);

            return View();
        }

        [HttpPost]
        public ActionResult GoToXikila(string sessionid, string merchantid, int amount, int currency, string purchaseref, string description)
        {
            System.Diagnostics.Debug.Print("Estou no GoToXikila");

            // HomeController hController = new HomeController();

            return new RedirectResult("https://24401.tagpay.fr/online/online.php");

            /* var request = WebRequest.Create("https://24401.tagpay.fr/online/online.php");
             var response = (HttpWebResponse)request.GetResponse();
             Stream data = response.GetResponseStream();*/
        }

        public void Sessao()
        {
            getSessionIDS();
            RedirectToRoute("Buying.cshtml");
        }

        public String getSessionIDS()
        {

            System.Diagnostics.Debug.Print("\nEstou no getSessionID");
            System.Net.WebClient wc = new System.Net.WebClient();

            string url = wc.DownloadString("https://24403.tagpay.fr/online/online.php?merchantid=2769989316156566");

            System.Diagnostics.Debug.Print("\nSpeciall call:" + url);

            //debugging
            string left = url.Substring(0, 3);
            string right = url.Substring(3, 32);
            string nok = "Erro ao tentar aceder a página";

            if (left.Equals("OK:"))
            {
                System.Diagnostics.Debug.Print("\nEverything is fine," + right);
                return right;
            }
            else
            {
                System.Diagnostics.Debug.Print("\nDude check your code," + nok);
                return nok;
            }

            //   u can still retrieve with JS and store it on a variable... transfer that on a POST form
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult Accept()
        {
            return View();
        }

        public ActionResult Decline()
        {
            return View();
        }
    }
}