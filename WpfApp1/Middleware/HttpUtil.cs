using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public static class HttpUtil
    {
        public static HttpListenerResponse Status(this HttpListenerResponse response,int statusCode, string description)
        {
            var messageByte = Encoding.UTF8.GetBytes(description);

            response.StatusCode = statusCode;
            response.StatusDescription = description;
            response.ContentLength64 = messageByte.Length;
            response.OutputStream.Write(messageByte, 0, messageByte.Length);
            response.OutputStream.Close();
            return response;

        }


    }
}
