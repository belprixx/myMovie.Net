using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MovieNetWpf 
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			Name = "Hello MVVM";
			MyCommand = new RelayCommand(MyCommandExecute, MycommandCanExecute);
		}

		private string _name;

		public  string Name
		{
			get { return _name; }
			set {
				_name = value;
				RaisePropertyChanged();	
			}
		}

		public RelayCommand MyCommand { get; } 

		void MyCommandExecute()
		{
			Name = "Hello Click";
		}

		bool MycommandCanExecute()
		{
			return Name != "Hello Click";
		}
	}
}
