using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class RouteValueDictionary: Dictionary<string,object>//保存路由的参数变量
    {
        public RouteValueDictionary Load(object values)
        {
            if (values != null)
            {
                foreach (var prop in values.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    this[prop.Name] = prop.GetValue(values);
                }
            }
            return this;

        }
    }
}
