using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
        //Middleware执行结果
        public enum MiddlewareResult
        {
            Processed = 1,
            //请求已经处理，不用再执行任何步骤
            Continue =  2,
            //继续执行下一个中间件
        }



            
    }

