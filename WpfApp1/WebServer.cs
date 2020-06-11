using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WebServerExample 
{
    public class WebServer
    {
        private readonly Semaphore _sem;//定义一个信号量来控制可接受的并发请求数量
        private readonly HttpListener _listener;//定义一个监听器 
        public WebServer(int concurrentCount)
        {
            _sem = new Semaphore(concurrentCount, concurrentCount);
            _listener = new HttpListener();
        }
        public void Bind(string url)
        {
            _listener.Prefixes.Add(url);
            //定义服务器侦听的地址前缀（Prefixes）；
        }
        public void Start()
        {
            _listener.Start(); //new HttpListener().Start()
            Task.Run(async () =>
            {
                while (true)
                {
                    _sem.WaitOne();
                    var context = await _listener.GetContextAsync();
                    _sem.Release();
                    HandleRequest(context);
                }
            });
        }
        private void HandleRequest(HttpListenerContext context)//收到请求后返回一个context
        {
            var request = context.Request;//从请求的上下文中拿到--请求对象
            var response = context.Response;//写入应答
            var urlPath = request.Url.LocalPath.TrimStart('/');
            Console.WriteLine($"url path={urlPath}");
            try
            {
                string filePath = Path.Combine("file", urlPath);
                byte[] data = File.ReadAllBytes(filePath);
                response.ContentType = "Text/html";
                response.ContentLength64 = data.Length;
                response.ContentEncoding = Encoding.UTF8;
                response.StatusCode = 200;
                response.OutputStream.Write(data, 0, data.Length);
                response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
