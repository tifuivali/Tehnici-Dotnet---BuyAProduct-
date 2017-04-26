using Autofac;
using Store.Common;

namespace Store.Console
{
    public class Configuration : StoreConfigurations
    {

        private void OnRunningWithDependences(ConsoleInterface consoleInterface)
        {
            consoleInterface.Run();
        }

        public override void ConfigureAutofac()
        {
            base.ConfigureAutofac();
            AutofacBuilder.RegisterType<ConsoleInterface>();
            var container = BuildConfigurations();
            using (var scope = container.BeginLifetimeScope())
            {
                var consoleInterface = scope.Resolve<ConsoleInterface>();
                OnRunningWithDependences(consoleInterface);
            }
        }
    }
}
