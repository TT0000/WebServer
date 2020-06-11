using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using System.Net;

namespace WpfApp1
{
    public class BlockIp:IMiddleware
    {
        public BlockIp(params string[] forbiddens)
        {
        _forbiddens = forbiddens;
       }
    private string[]_forbiddens;
        public MiddlewareResult Execute(HttpListenerContext context)
        {
            var clientIp = context.Request.RemoteEndPoint.Address;
            if (_forbiddens.Contains(clientIp.ToString()))
            {
                context.Response.Status(403, "Forbidden");
                return MiddlewareResult.Processed;
            }
            return MiddlewareResult.Continue;
        }

    }
}
