using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1
{
    class MiddlewarePapeline//注册并依次执行各个中间件
    {
        public MiddlewarePapeline()
        {
            _middlewares = new List<IMiddleware>();
        }
        private readonly List<IMiddleware> _middlewares;
        private IExecptionHandler _execptionHandler;
        internal void Add(IMiddleware middleware)
        {
            _middlewares.Add(middleware);
        }
        internal void UnhandledException(IExecptionHandler handler)
        {
            _execptionHandler = handler;
        }
        internal void Execete(HttpListenerContext context)
        {
            try
            {
                foreach (var middleware in _middlewares)
                {
                    var result = middleware.Execute(context);
                    if (result == MiddlewareResult.Processed) 
                    { 
                        break;
                    }
                    else if (result == MiddlewareResult.Continue)
                    {
                        continue;
                    }
                }
            }

            catch (Exception ex)
            {
                if (_execptionHandler != null)
                    _execptionHandler.HandleExecption(context,ex);
                else
                    throw;
                    
            }


        }
    }
}
