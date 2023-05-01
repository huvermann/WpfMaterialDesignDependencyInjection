using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfMd.Options;
using WpfMd.ViewModel;

namespace WpfMd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private IConfiguration _configuration;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    _configuration = context.Configuration;
                    ConfigureServices(services, _configuration);
                    
                })
                .Build();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.Configure<TestOption>(options => configuration.GetSection(TestOption.SectionName).Bind(options));
        }
    }
}
