using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    
        public class RouteEntry
        {
            public RouteEntry(string name, string url, object defaults)
            {
                _name = name;
                _fragments = Parse(url, defaults);
            }

            private readonly string _name;

            private readonly RouteFragment[] _fragments;

            private RouteFragment[] Parse(string url, object defaults)
            {
                var defaultValues = new RouteValueDictionary().Load(defaults);
                return url.Split('/')
                    .Select(x => new RouteFragment(x, defaultValues))
                    .ToArray();
            }

            public RouteValueDictionary Match(HttpListenerRequest request)
            {
                // TODO: Extract url parameters from request
                
    
        }
    }
