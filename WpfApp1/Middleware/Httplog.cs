using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1
{
    class Httplog: IMiddleware
    {
        public MiddlewareResult Execute(HttpListenerContext contex)
        {
            var request = contex.Request;
            var path = request.Url.LocalPath;
            var clientIP = request.RemoteEndPoint.Address;
            var methd = request.HttpMethod;

            Console.WriteLine("[{0:yyyy-MM-dd HH:mm:ss}]{1} {2} {3}",DateTime.Now,clientIP,methd,path);
            return MiddlewareResult.Continue;

        }
    }
}
