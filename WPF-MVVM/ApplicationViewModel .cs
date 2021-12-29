using EFLib.CRUD;
using EFLib.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WPF_MVVM.Command;
using WPF_MVVM.Models;

namespace WPF_MVVM
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Project_WPF project;
        public ObservableCollection<Project_WPF> Projects { get; set; }
        private MainCRUD<Project> dbContext;

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Project_WPF project = new Project_WPF();
                      Projects.Insert(0, project);
                      SelectedProject = project;
                      dbContext.Add(project);
                  }));
            }
        }
        public Project_WPF SelectedProject
        {
            get { return project; }
            set
            {
                project = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        public ApplicationViewModel(MainCRUD<Project> dbCtx)
        {
            dbContext = dbCtx;
            Projects = new ObservableCollection<Project_WPF>(dbContext.GetAll().Cast<Project_WPF>().ToList());
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
