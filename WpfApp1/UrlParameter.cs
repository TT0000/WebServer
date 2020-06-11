using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public  class UrlParameter
    {
        public static readonly UrlParameter Optional = new UrlParameter();//标识路径中的可选参数
        public static readonly UrlParameter missing = new UrlParameter();//用来表示参数中缺失的部分
    }
}
