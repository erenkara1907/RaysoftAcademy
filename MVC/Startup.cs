using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;

using MVC.Data;

using Owin;

[assembly: OwinStartup(typeof(MVC.Startup))]

namespace MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }

       
    }
}
