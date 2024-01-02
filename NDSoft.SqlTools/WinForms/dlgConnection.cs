using Microsoft.Data.SqlClient;

using NDSoft.SqlTools.Lib;
using NDSoft.SqlTools.WinForms.Resources;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDSoft.SqlTools.WinForms;

public partial class dlgConnection : Form
{
   /// <summary>
   /// List of already defined Connections
   /// </summary>
   private List<SQLConStringDefinition> conList = new List<SQLConStringDefinition>();

   /// <summary>
   /// Current Connection
   /// </summary>
   private SQLConStringDefinition conString = new();

   /// <summary>
   /// Establish if the name of the connection is indexer edit mode, to not add a new one
   /// </summary>
   private bool IsEdit = false;

   /// <summary> <list of servers </summary>
   private StringCollection servList = new();
   private bool isNew = true;

   /// <summary>
   /// Initializes a new instance of the <see cref="dlgConnection"/> class. Being internal, the constructor disables instantiation out of this component
   /// </summary>
   internal dlgConnection()
   {
      InitializeComponent();
      conString.RequireCredentials += ConString_RequireCredentials;
   }

   /// <summary>
   /// manage changes of the <see cref="SQLConStringDefinition.RequireCredentials"/> event. 
   /// </summary>
   /// <param name="sender">The instance that raise the event.</param>
   /// <param name="e">The <see cref="RequireCredentialsEventArgs"/> instance containing the event data.</param>
   private void ConString_RequireCredentials(object? sender, RequireCredentialsEventArgs e) => EnableCredentials(e.NeedCredentials);

   /// <summary>
   /// Gets or sets the connection string.
   /// </summary>
   /// <value> The connection string. </value>
   internal string ConnectionString
   {
      get => conString.ConnectionString;
      set
      {
         if(!string.IsNullOrEmpty(value))
         {
            conString.RequireCredentials -= ConString_RequireCredentials;
            conString = SQLConStringDefinition.BuildFromString(value);
            conString.RequireCredentials += ConString_RequireCredentials;
            isNew = false;

         }
         else
            isNew = true;
      }
   }

   /// <summary>
   /// Gets or sets the list of well known servers' names.
   /// </summary>
   /// <value>
   /// The servers.
   /// </value>
   private string[] Servers { get; set; } = new string[0];

   #region "Form Event handlers"
   private void btnEdit_Click(object sender, EventArgs e)
   {
      IsEdit = true;
      cbServer.DropDownStyle = ComboBoxStyle.DropDown;
      cbServer.Focus();
   }

   private void btnLookupDB_Click(Object sender, EventArgs e)
   {
      Boolean isOk = CheckParameters();
      cbDB.Items.AddRange(conString.RetrieveDatabases());
      cbDB.DroppedDown = true;
      btnOk.Enabled = isOk;
   }


   private void btnNewServer_Click(Object sender, EventArgs e)
   {
      cbServer.DropDownStyle = ComboBoxStyle.DropDown;
      cbServer.Focus();
   }

   private void btnOk_Click(Object sender, EventArgs e)
   {
      if(CheckParameters())
      {
         conString.Database = cbDB.Items[cbDB.SelectedIndex].ToString();
      }
   }

   private void btnRemoveServer_Click(Object sender, EventArgs e)
   {
      servList.Remove(cbServer.Text);
      Properties.Settings.Default.SQLServers = servList;
      Properties.Settings.Default.Save();
      cbServer.Items.Clear();
      foreach(var x in servList)
      {
         cbServer.Items.Add(x);
      }
   }

   private void btnTest_Click(Object sender, EventArgs e)
   {
      if(CheckParameters())
      {
         conString.Server = cbServer.Items[cbServer.SelectedIndex].ToString();
         using SqlConnection con = new SqlConnection(conString.ConnectionString);
         try
         {
            con.Open();
            picOk.Visible = true;
            con.Close();
            btnOk.Enabled = true;
         }
         catch(Exception ex)
         {
            MessageBox.Show(
               ex.Message,
               ModelsData.Data_Connection_Error,
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
         }
      }
   }


   private void cbAuth_SelectedIndexChanged(Object sender, EventArgs e)
   {
      if(cbAuth.SelectedIndex < 0) return;
      string selected = cbAuth.Items[cbAuth.SelectedIndex].ToString();
      cbAuth.Text = selected;
      conString.AuthenticationMethod = selected;
   }

   private void cbDB_SelectedIndexChanged(Object sender, EventArgs e)
   {
      conString.Database = cbDB.Items[cbDB.SelectedIndex].ToString();
   }



   private void cbServer_Leave(Object sender, EventArgs e)
   {
      ComboBox source = (ComboBox)sender;
      if(source.DropDownStyle != ComboBoxStyle.DropDown)
      {
         return;
      }
      string newName = source.Text;
      source.Items.Add(newName);
      source.DropDownStyle = ComboBoxStyle.DropDownList;
      for(int i = 0; i < source.Items.Count; i++)
      {
         if(source.Items[i].ToString() == newName)
         {
            source.SelectedIndex = i;
            break;
         }
      }

      servList.Add(cbServer.Text);
      Properties.Settings.Default.SQLServers = servList;
      Properties.Settings.Default.Save();
   }

   private void cbServer_SelectedIndexChanged(Object sender, EventArgs e)
   {
      if(cbServer.SelectedIndex != -1) conString.Server = cbServer.Items[cbServer.SelectedIndex].ToString();
   }

   private void cbServer_TextUpdate(Object sender, EventArgs e)
   {
   }
   private void txtPassword_Leave(Object sender, EventArgs e)
   {
      conString.Password = txtPassword.Text;
   }

   private void txtUsername_Leave(Object sender, EventArgs e)
   {
      conString.Username = txtUsername.Text;
   }
   private void dlgConnection_Load(object sender, EventArgs e)
   {
      StringCollection servList = Properties.Settings.Default.SQLServers ?? new System.Collections.Specialized.StringCollection();
      if(!servList.Contains("localhost"))
      {
         servList.Add("localhost");
         Properties.Settings.Default.SQLServers = servList;
         Properties.Settings.Default.Save();
      }
      Servers = (from string el in servList select el).ToArray();
      conStringDefinitionBindingSource.DataSource = conString;
      //conStringDefinitionBindingSource.Position = 0;
      cbServer.Items.Clear();
      cbServer.Items.AddRange(Servers);
      cbServer.SelectedIndex = 0;
      cbAuth.Items.AddRange(SQLConStringDefinition.AuthenticationMethodsList);
      if(!isNew)
      {
         cbDB.Items.AddRange(conString.RetrieveDatabases());
         SelectItem(cbDB, conString.Database);
         SelectItem(cbAuth, conString.AuthenticationMethod);
         SelectItem(cbServer, conString.Server);
      }
   }

   /// <summary>
   /// Selects the item that match with the value.
   /// </summary>
   /// <param name="dd">The <see cref="ComboBox"/> .</param>
   /// <param name="value">The value.</param>
   private void SelectItem(ComboBox dd, string value)
   {
      for(int i = 0; i < dd.Items.Count; i++)
      {
         if(dd.Items[i].ToString() == value)
         {
            dd.SelectedIndex = i;
            break;
         }
      }
   }
   #endregion
   /// <summary>
   /// Checks the values to establish if is possible to connect to a database.
   /// </summary>
   /// <returns> </returns>
   private Boolean CheckParameters()
   {
      bool isOk = true;
      errorProvider1.Clear();
      if(string.IsNullOrEmpty(cbServer.Text))
      {
         errorProvider1.SetError(cbServer, ModelsData.Missing_Server);
         isOk = false;
      }
      if(cbAuth.SelectedIndex < 0)
      {
         errorProvider1.SetError(cbAuth, ModelsData.Missing_Auth);
         isOk = false;
      }
      if(conString.UseCredentials)
      {
         if(string.IsNullOrEmpty(txtUsername.Text))
         {
            errorProvider1.SetError(txtUsername, ModelsData.Missing_User);
            isOk = false;
         }
         if(string.IsNullOrEmpty(txtPassword.Text))
         {
            errorProvider1.SetError(txtPassword, ModelsData.Missing_Pwd);
            isOk = false;
         }
      }
      if(string.IsNullOrEmpty(txtAppName.Text))
      {
         errorProvider1.SetError(txtAppName, ModelsData.Missing_Appname);
         isOk = false;
      }

      return isOk;
   }


   /// <summary>
   /// Change the Enable state of the credentials input boxes.
   /// </summary>
   /// <param name="enable"></param>
private void EnableCredentials(Boolean enable)
{
   txtPassword.Enabled = enable;
   txtUsername.Enabled = enable;
}



   private void label4_Click(object sender, EventArgs e)
   {

   }
}