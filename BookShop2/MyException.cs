using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookShop2
{
    public class MyException : Exception  //ask, extends in java?
    {
        private string message;
        public MyException(string Message)
        {
            this.message = Message;
        }
        public String toString()
        {
            return String.Format("Error: {0}", message);  // {0} is a placeholder in a string (in this case for 'message', - e.g. see MyCustomer for messages)
        }
    }
}
