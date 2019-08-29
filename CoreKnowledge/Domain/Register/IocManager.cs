using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CoreKnowledge.Configuration;
using System.Reflection;
using CoreKnowledge.Domain.Services.Interfaces;

namespace CoreKnowledge.Domain.Register
{
    public class IocManager
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region     LifeTime
            //services.AddTransient<>();
            //services.AddScoped<>();
            //services.AddSingleton<>();
            //services.AddTransient();
            #endregion  LifeTime


            var options = configuration.Get<CoreKnowledgeOptions>();

            // exceptions
            var ProviderException = Assembly.GetEntryAssembly().GetType(options.Exception.Provider);

            services.AddSingleton(typeof(IExceptionProvider), ProviderException);

            // search engine
            var SeacrhEngine = Assembly.GetEntryAssembly().GetType(options.SearchEngine.Provider);
            services.AddScoped(typeof(ISeacrhService), SeacrhEngine);


        }
    }
}
