using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1
{
   public class Http500 : IExecptionHandler
    {
        public void HandleException(HttpListenerContext context, Exception exp)
        {
            Console.WriteLine(exp.Message);
            Console.WriteLine(exp.StackTrace);
            context.Response.Status(500, "Inter Server Error");
        }
    }
}
