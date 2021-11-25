using DesktopApiClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DesktopClientWinforms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DesktopClientForm());

            var services = new ServiceCollection();
            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var desktopClientForm = serviceProvider.GetRequiredService<DesktopClientForm>();
            Application.Run(desktopClientForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            string webApiUri = ConfigurationManager.ConnectionStrings["webApiUri"].ConnectionString;
            services.AddSingleton((desktopApiClient) => DesktopApiClientFactory.GetDesktopApiClient<IWhatToWatchApiClient>(webApiUri));
            services.AddScoped<DesktopClientForm>();
        }
    }
}
