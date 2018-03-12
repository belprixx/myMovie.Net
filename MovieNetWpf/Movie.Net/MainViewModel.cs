using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using DatabaseMovie;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Data;

namespace Movie.Net
{
    class MainViewModel : ViewModelBase
    {
        //UtilisateurDaoImpl uDao = new UtilisateurDaoImpl();
        private List<Utilisateur> _utilisateurs { get; set; } //= Facade.Instance.methodGetAllUtilisateur();
        private List<Film> _films { get; set; }

        public MainViewModel()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Model1Container"].ConnectionString;
            _name = "";
            loginValue = "Login";
            AddCommand = new RelayCommand(AddCommandExecute, AddCommandCanExecute);
            AddFilmCommand = new RelayCommand(AddFilmCommandExecute, AddFilmCommandCanExecute);
            _utilisateurs = Facade.Instance.methodGetAllUtilisateur();
            _films = Facade.Instance.methodGetAllFilm();

            SizeQuantityTable = new DataTable();
            DataColumn tColumn = new DataColumn();
            tColumn.ColumnName = "Titre";
            SizeQuantityTable.Columns.Add(tColumn);
            DataColumn gColumn = new DataColumn();
            gColumn.ColumnName = "Genre";
            SizeQuantityTable.Columns.Add(gColumn);
            DataColumn rColumn = new DataColumn();
            rColumn.ColumnName = "Resume";
            SizeQuantityTable.Columns.Add(rColumn);
            foreach (Film f in _films)
            {
                DataRow row = this.SizeQuantityTable.NewRow();
                row[tColumn] = f.Titre;
                row[gColumn] = f.Genre;
                row[rColumn] = f.Resume;
                this.SizeQuantityTable.Rows.Add(row);
            }
        }

        private DataTable sizeQuantityTable;

        public DataTable SizeQuantityTable
        {
            get { return sizeQuantityTable; }
            set { sizeQuantityTable = value; }
        }

        public List<Utilisateur> Utilisateurs
        {
            get { return _utilisateurs; }
            set
            {
                if (value != _utilisateurs)
                {
                    _utilisateurs = value;
                    OnPropertyChanged("Utilisateurs");
                }
            }
        }

        public List<Film> Films
        {
            get { return _films; }
            set
            {
                if (value != _films)
                {
                    _films = value;
                    OnPropertyChanged("Films");
                }
            }
        }

        public string utilisateurLogin = "";
        private Utilisateur _selectedUtilisateur = Facade.Instance.methodGetAllUtilisateur().ElementAt(0);
        public Utilisateur SelectedUtilisateur
        {
            get { return _selectedUtilisateur; }
            set
            {
                if (value != _selectedUtilisateur)
                {
                    _selectedUtilisateur = value;
                    utilisateurLogin = value.login;
                    Name = utilisateurLogin;
                    RaisePropertyChanged("SelectedUtilisateur");
                }
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string loginValue;

        public string LoginValue
        {
            get { return loginValue; }
            set
            {
                loginValue = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; }

        void AddCommandExecute()
        {
            Console.WriteLine("AddCommandExecute");
            Utilisateur u = new Utilisateur();
            u.login = loginValue;
            Facade.Instance.methodAddUtilisateur(u);
            Utilisateurs = Facade.Instance.methodGetAllUtilisateur();
        }

        bool AddCommandCanExecute()
        {
            return true;
        }

        public RelayCommand AddFilmCommand { get; }

        void AddFilmCommandExecute()
        {
            Console.WriteLine("AddFilmCommandExecute");
            Film f = new Film();
            f.Titre = "Test";
            f.Genre = "Test";
            f.Resume = "Test";
            Facade.Instance.methodAddFilm(f);
            Films = Facade.Instance.methodGetAllFilm();
        }

        bool AddFilmCommandCanExecute()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }


    }
}
