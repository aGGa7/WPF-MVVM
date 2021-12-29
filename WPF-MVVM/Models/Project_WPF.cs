using EFLib.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM.Models
{
    class Project_WPF:Project
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
