using NDSoft.SqlTools.Lib;
using NDSoft.WPF;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NDSoft.SqlTools.WPF;

public class dlgConnectionModel : DependencyObject, INotifyPropertyChanged
{
   // Using a DependencyProperty as the backing store for ConnectionIsOk. This enables animation, styling, binding, etc...
   public static readonly DependencyProperty ConnectionIsOkProperty =
       DependencyProperty.Register("ConnectionIsOk", typeof(bool), typeof(dlgConnectionModel), new PropertyMetadata(false));

   private bool connectionIsOk;
   private SQLConStringDefinition connection;

   public bool NeedCredentials
   {
      get { return (bool)GetValue(NeedCredentialsProperty); }
      set { SetValue(NeedCredentialsProperty, value); }
   }

   // Using a DependencyProperty as the backing store for NeedCredentials.  This enables animation, styling, binding, etc...
   public static readonly DependencyProperty NeedCredentialsProperty =
       DependencyProperty.Register("NeedCredentials", typeof(bool), typeof(dlgConnectionModel), new PropertyMetadata(false));


   public dlgConnectionModel()
   {
      CreateAddServerCommand();
      CreateLoadDBsCommand();
      CreateRemoveServerCommand();
      Connection = new();
      Connection.RequireCredentials += Connection_RequireCredentials;
   }

   private void Connection_RequireCredentials(object? sender, RequireCredentialsEventArgs e) => NeedCredentials = e.NeedCredentials;

   public event PropertyChangedEventHandler? PropertyChanged;

   public SQLConStringDefinition Connection
   {
      get => connection; set
      {
         connection.RequireCredentials -= Connection_RequireCredentials;
         connection = value;
         connection.RequireCredentials += Connection_RequireCredentials;
      }
   }

   public bool ConnectionIsOk
   {
      get { return (bool)GetValue(ConnectionIsOkProperty); }
      set { SetValue(ConnectionIsOkProperty, value); }
   }

   public SQLConStringDefinition Current { get; set; }

   public ObservableCollection<string> Databases { get; set; }

   public ObservableCollection<string> Defined { get; set; }

   public ObservableCollection<string> Servers { get; set; }

   private void PropertyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

   #region "Commands"

   public ICommand AddServerCommand
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
   }

   public void LoadDBsCommandExecute()
   {
   }

   public void RemoveServerCommandExecute()
   {
   }

   private bool CanExecuteAddServerCommand()
   {
      return true;
   }

   private bool CanExecuteLoadDBsCommand()
   {
      return true;
   }

   private bool CanExecuteRemoveServerCommand()
   {
      return true;
   }

   private void CreateAddServerCommand()
   {
      AddServerCommand = new RelayCommand(AddServerCommandExecute, CanExecuteAddServerCommand);
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