using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class Filter : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }
        
        private void OnBeginRequest(object sender, EventArgs e)
        {
            
            if (HttpContext.Current.Request.Headers["X-Requested-With"] != null && HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                string[] pathArr = HttpContext.Current.Request.Path.Split('/');
                string controllerName = pathArr[1];
                string actionName = pathArr[2];
                if (controllerName.StartsWith("_"))
                {
                    return;
                }
                Type type = Type.GetType(string.Format("Controller.{0}Controller, Controller", controllerName));
                if(type != null)
                {
                    MethodInfo mi = type.GetMethod(actionName, BindingFlags.Public | BindingFlags.Instance);
                    var obj = Activator.CreateInstance(type);
                    HttpContext.Current.Response.Write(mi.Invoke(obj, null));
                    HttpContext.Current.Response.StatusCode = 200;
                    HttpContext.Current.Response.End();
                }

            }
        }
    }
}
