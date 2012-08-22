using System;
using ConDep.Dsl.Core;

namespace ConDep.Dsl
{
    public static class AppPoolInfrastructureExtension
    {
        public static void AppPool(this IProvideForInfrastructureIis iisOptions, string appPoolName)
        {
            var options = (InfrastructureIisOptions) iisOptions;
            var appPoolProvider = new AppPoolInfrastructureProvider(appPoolName);
            options.WebDeploySetup.ConfigureProvider(appPoolProvider);
        }

        public static void AppPool(this IProvideForInfrastructureIis iisOptions, string appPoolName, Action<AppPoolInfrastructureOptions> appPoolOptions)
        {
            var options = (InfrastructureIisOptions)iisOptions;
            var appPoolProvider = new AppPoolInfrastructureProvider(appPoolName);

            appPoolOptions(new AppPoolInfrastructureOptions(appPoolProvider));
            options.WebDeploySetup.ConfigureProvider(appPoolProvider);
        }
    }
}