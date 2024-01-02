using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NDSoft.SqlTools.WPF;
/// <summary>
/// Lógica de interacción para dlgConnection.xaml
/// </summary>
public partial class dlgConnection : Window
{
   public dlgConnection()
   {
      InitializeComponent();
   }

   public string ConnectionString { get; internal set; }
}
