using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public class Http404:IMiddleware
    {
        public MiddlewareResult Execute(HttpListenerContext context)
        {
            context.Response.Status(404, "File Not Found");
            return MiddlewareResult.Processed;
        }

    }
}
