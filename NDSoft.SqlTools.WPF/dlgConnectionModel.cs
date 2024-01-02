using NDSoft.SqlTools.Lib;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSoft.SqlTools.WPF;
public class dlgConnectionModel : INotifyPropertyChanged
{
   public event PropertyChangedEventHandler? PropertyChanged;
   void PropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
   public SQLConStringDefinition Current { get; set; }
   public ObservableCollection<string> Defined { get; set; }
   public ObservableCollection<string> Servers { get; set; }
   public ObservableCollection<string> Databases { get; set; }
   public SQLConStringDefinition Connection { get; set; }
}
