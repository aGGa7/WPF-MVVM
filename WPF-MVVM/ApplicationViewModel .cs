using EFLib.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WPF_MVVM
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Project project;
        public ObservableCollection<Project> Projects { get; set; }
        
        public Project Project
        {
            get { return project; }
            set
            {
                project = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
