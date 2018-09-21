using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagamentoXM
{
    public class Class1
    {
        public string SessionID { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Link { get; set; }
        public string MerchantID{ get; set; }
        public int Amount { get; set; }
        public int Currency { get; set; }
        public string PurchaseRef { get; set; }
        public string Description { get; set; }
    }
}