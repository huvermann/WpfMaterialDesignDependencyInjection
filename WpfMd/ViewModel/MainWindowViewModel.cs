using ControlzEx.Standard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfMd.Options;
using WpfMd.Repositories;

namespace WpfMd.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
		private DateTime _zeit = DateTime.Now;
        private readonly ILogger<MainWindowViewModel> _logger;
        private readonly IOptions<TestOption> _option;
        private readonly ICertificateRepository _certificateRepository;

        public MainWindowViewModel(
			ILogger<MainWindowViewModel> logger, 
			IOptions<TestOption> option, 
			IOptions<SecretsOptions> secretOptions,
            ICertificateRepository certificateRepository)
        {
			_logger = logger;
			_option = option;
			_kundenName = option.Value.Nachname;
			_username = secretOptions.Value.Username;
            _certificateRepository = certificateRepository;
            _logger.LogInformation("Starte Application");
        }
        public DateTime Zeitangabe
		{
			get { return _zeit; }
			set { _zeit = value;
			OnPropertyChanged();
			}
		}

		private string _kundenName;



		public string KundenName
		{
			get { return _kundenName; }
			set { 
				_kundenName = value;
				OnPropertyChanged();
			}
		}

		private string _username;
       

        public string Username
		{
			get { return _username; }
			set { _username = value;
				OnPropertyChanged();

			}
		}

		public ObservableCollection<string> CertList => GetCertsFromStore();

        private ObservableCollection<string> GetCertsFromStore()
        {
			var certs = _certificateRepository.GetCertNames();
			ObservableCollection<string> result = new ObservableCollection<string>(certs);
			return result;
        }
    }
}
