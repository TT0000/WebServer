using System;
using WebServerExample;
using WpfApp1;

namespace WpfApp1
{
    internal class program
    {
        private const int concurrentCount = 20;//最多可接受20个并发连接
        private const string ServerUrl = "http://localhost:9000/";//监听端口9000的地址
        public static void Main(string[] args)
        {
            var server = new WebServer(concurrentCount);
            RegisterMiddleware(server);
            server.Bind(ServerUrl); //本质上是监听  --bind 对端口做监听
            server.Start(); 
            Console.WriteLine($"Web server started at {ServerUrl}. Press any key to exist...");
            Console.ReadKey();
        }
        static void RegisterMiddleware(IwebServerBuilder builder)
        {
            builder.Use(new Httplog());
            var routes = new Routing();
            RegisterRoutes(routes);
            builder.Use(routes);
            builder.Use(new StaticFile());
            builder.Use(new Http404());

            builder.UnhandleException(new Http500());
        }
        static void RegisterMiddleware(routing routing)
        {
            route.MapRoute(name: "Deafault",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
