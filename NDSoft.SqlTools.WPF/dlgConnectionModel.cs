using Microsoft.Data.SqlClient;

using NDSoft.SqlTools.Lib;
using NDSoft.WPF;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NDSoft.SqlTools.WPF;

public class dlgConnectionModel : DependencyObject, INotifyPropertyChanged
{
   public event EventHandler<EventArgs> SetFocusInServer;
   private SQLConStringDefinition currentConnection;


   public Boolean ShowDBs
   {
      get { return (Boolean)GetValue(ShowDBsProperty); }
      set { SetValue(ShowDBsProperty, value); }
   }

   // Using a DependencyProperty as the backing store for ShowDBs.  This enables animation, styling, binding, etc...
   public static readonly DependencyProperty ShowDBsProperty =
       DependencyProperty.Register("ShowDBs", typeof(Boolean), typeof(dlgConnectionModel), new PropertyMetadata(false));


   // Using a DependencyProperty as the backing store for ConnectionIsOk. This enables animation, styling, binding, etc...
   public static readonly DependencyProperty ConnectionIsOkProperty =
       DependencyProperty.Register("ConnectionIsOk", typeof(bool), typeof(dlgConnectionModel), new PropertyMetadata(false));
   private bool connectionIsOk;
   /// <summary>
   /// Gets or sets a value indicating whether the authentication methods requires credentials.
   /// </summary>
   /// <value>
   ///   <c>true</c> if [need credentials]; otherwise, <c>false</c>.
   /// </value>
   public bool NeedCredentials
   {
      get { return (bool)GetValue(NeedCredentialsProperty); }
      set { SetValue(NeedCredentialsProperty, value); }
   }

   // Using a DependencyProperty as the backing store for NeedCredentials.  This enables animation, styling, binding, etc...
   public static readonly DependencyProperty NeedCredentialsProperty =
       DependencyProperty.Register("NeedCredentials", typeof(bool), typeof(dlgConnectionModel), new PropertyMetadata(false));


   public bool IsServerEditable
   {
      get { return (bool)GetValue(IsServerEditableProperty); }
      set { SetValue(IsServerEditableProperty, value); }
   }

   // Using a DependencyProperty as the backing store for IsServerEditable.  This enables animation, styling, binding, etc...
   public static readonly DependencyProperty IsServerEditableProperty =
       DependencyProperty.Register("IsServerEditable", typeof(bool), typeof(dlgConnectionModel), new PropertyMetadata(false));



   public dlgConnectionModel()
   {
      CreateCommands();
      currentConnection = new();
      Current.RequireCredentials += Connection_RequireCredentials;
   }
   private void Connection_RequireCredentials(
      object? sender,
      RequireCredentialsEventArgs e)
      => NeedCredentials = e.NeedCredentials;

   public event PropertyChangedEventHandler? PropertyChanged;
   private void CreateCommands()
   {
      CreateAddServerCommand();
      CreateLoadDBsCommand();
      CreateRemoveServerCommand();
      CreateTestConnectionCommand();
   }


   /// <summary>
   /// Exposes if the connection is ok
   /// </summary>
   public bool ConnectionIsOk
   {
      get { return (bool)GetValue(ConnectionIsOkProperty); }
      set { SetValue(ConnectionIsOkProperty, value); }
   }

   /// <summary>
   /// Gets or sets the <see cref="SQLConStringDefinition" />instance.
   /// </summary>
   /// <value>
   /// The  <see cref="SQLConStringDefinition" />instance.
   /// </value>
   public SQLConStringDefinition Current
   {
      get => currentConnection; set
      {
         currentConnection.RequireCredentials -= Connection_RequireCredentials;
         currentConnection = value;
         currentConnection.RequireCredentials += Connection_RequireCredentials;
      }
   }


   public ObservableCollection<string> Databases { get; set; } = new();

   public ObservableCollection<string> Defined { get; set; }

   public ObservableCollection<string> Servers { get; set; }

   private void PropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

   #region "Commands"

   public ICommand AddServerCommand
   {
      get;
      internal set;
   }
   public ICommand TestConnectionCommand
   {
      get;
      internal set;
   }

   public ICommand LoadDBsCommand
   {
      get;
      internal set;
   }

   public ICommand RemoveServerCommand
   {
      get;
      internal set;
   }

   public void AddServerCommandExecute()
   {
      IsServerEditable = true;
      SetFocusInServer?.Invoke(this, EventArgs.Empty);
   }
   public void TestConnectionCommandExecute()
   {
      using SqlConnection con = new SqlConnection(currentConnection.ConnectionString);
      try
      {
         con.Open();
         ConnectionIsOk = true;
         con.Close();
      }
      catch(Exception ex)
      {
         MessageBox.Show(
            ex.Message
            , "",
            MessageBoxButton.OK, MessageBoxImage.Error
            );
      }
   }

   public void LoadDBsCommandExecute()
   {
      Databases.Clear();
      foreach(var item in currentConnection.RetrieveDatabases())
      {
         Databases.Add(item);
      }
      ShowDBs = Databases.Count > 0;
   }

   public void RemoveServerCommandExecute()
   {
      Servers.Remove(currentConnection.Server);
   }


   private bool CanExecuteLoadDBsCommand()
   {
      return true;
   }

   private bool CanExecuteRemoveServerCommand()
   {
      return true;
   }

   private bool CanExecuteAddServerCommand()
   {
      return true;
   }
   private void CreateAddServerCommand()
   {
      AddServerCommand = new RelayCommand(AddServerCommandExecute, CanExecuteAddServerCommand);
   }

   private bool CanExecuteTestConnectionCommand()
   {
      return true;
   }
   private void CreateTestConnectionCommand()
   {
      TestConnectionCommand = new RelayCommand(TestConnectionCommandExecute, CanExecuteTestConnectionCommand);
   }

   private void CreateLoadDBsCommand()
   {
      LoadDBsCommand = new RelayCommand(LoadDBsCommandExecute, CanExecuteLoadDBsCommand);
   }

   private void CreateRemoveServerCommand()
   {
      RemoveServerCommand = new RelayCommand(RemoveServerCommandExecute, CanExecuteRemoveServerCommand);
   }

   #endregion "Commands"
}