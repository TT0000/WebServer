using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
        public interface IMiddleware
        {
            MiddlewareResult Execute(HttpListenerContext context);
        }
    public interface IExecptionHandler
    {
        void HandleExecption(HttpListenerContext context,Exception exp);
        void HandleExecption(object ex);
    }

}
