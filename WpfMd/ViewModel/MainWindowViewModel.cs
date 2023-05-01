﻿using ControlzEx.Standard;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfMd.Options;

namespace WpfMd.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
		private DateTime _zeit = DateTime.Now;
        private readonly ILogger<MainWindowViewModel> _logger;
        private readonly IOptions<TestOption> _option;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger, IOptions<TestOption> option )
        {
			_logger = logger;
			_option = option;
			_kundenName = option.Value.Nachname;
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


	}
}
