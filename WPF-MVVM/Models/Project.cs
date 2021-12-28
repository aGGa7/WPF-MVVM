using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFLib.Models;

namespace EFLib.Models
{
    public partial class Project : BaseClass, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
