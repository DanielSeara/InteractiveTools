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
   internal dlgConnection()
   {
      InitializeComponent();
      Model = (dlgConnectionModel)this.DataContext;
      txtPassword.PasswordChanged += TxtPassword_PasswordChanged;
      Model.SetFocusInServer += Model_SetFocusInServer;
   }

   private void Model_SetFocusInServer(object? sender, EventArgs e) => cbServer.Focus();
   private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e) => Model.Current.Password = txtPassword.Password;

   public string ConnectionString
   {
      get => Model.Current.ConnectionString;
      internal set
      {
         Model.Current = SqlTools.Lib.SQLConStringDefinition.BuildFromString(value);
         if(Model.Current.UseCredentials) { txtPassword.Password = Model.Current.Password; }
      }

   }
   public dlgConnectionModel Model { get; }

   private void btnOk_Click(object sender, RoutedEventArgs e)
   {
      this.DialogResult = true;
      this.Hide();
   }
}
