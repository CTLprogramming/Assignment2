using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2
{
    internal class MyGlobals
    {
        public static bool frmClosing = false, frmShop = false, frmCustomer = false, frmCheckout = false, frmReceipt = false, frmRefunds = false ;
        public static int selectedCustNo=0;
        public static int cart = 0;
        public static decimal total = 0;
        public static List<MyOrderDetail> orderDetails= new List<MyOrderDetail>();
        public static MyCustomer customer = new MyCustomer();
        public static int[] justOrdered = { 0, 0 };
        public static int[] justReturned = { 0, 0 };

        //        public static long[] orderDetail = new long[2];

    }
}
