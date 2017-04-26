namespace Store.Console
{
    public class Program
    {
        private static void Main()
        {
            var configuration = new Configuration();
            configuration.ConfigureAutoMapper();
            configuration.ConfigureAutofac();
        }

    }
}