using NDSoft.SqlTools.Lib;

namespace NDSoft.SqlTools.WinForms;

partial class dlgConnection
{
   /// <summary>
   /// Required designer variable.
   /// </summary>
   private System.ComponentModel.IContainer components = null;

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   protected override void Dispose(bool disposing)
   {
      if(disposing && (components != null))
      {
         components.Dispose();
      }
      base.Dispose(disposing);
   }

   #region Windows Form Designer generated code

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgConnection));
      toolTip1 = new ToolTip(components);
      picOk = new PictureBox();
      btnNewServer = new Button();
      btnLookupDB = new Button();
      btnCancel = new Button();
      btnOk = new Button();
      btnTest = new Button();
      btnRemoveServer = new Button();
      txtUsername = new TextBox();
      conStringDefinitionBindingSource = new BindingSource(components);
      label5 = new Label();
      label4 = new Label();
      cbDB = new ComboBox();
      label3 = new Label();
      cbAuth = new ComboBox();
      label2 = new Label();
      txtPassword = new TextBox();
      cbServer = new ComboBox();
      label1 = new Label();
      label7 = new Label();
      txtAppName = new TextBox();
      chkCert = new CheckBox();
      label8 = new Label();
      label9 = new Label();
      checkBox1 = new CheckBox();
      label10 = new Label();
      checkBox2 = new CheckBox();
      errorProvider1 = new ErrorProvider(components);
      tableLayoutPanel1 = new TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)picOk).BeginInit();
      ((System.ComponentModel.ISupportInitialize)conStringDefinitionBindingSource).BeginInit();
      ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // picOk
      // 
      picOk.Image = Resources.ModelsData.Approve32x32_Transparent;
      resources.ApplyResources(picOk, "picOk");
      picOk.Name = "picOk";
      picOk.TabStop = false;
      // 
      // btnNewServer
      // 
      resources.ApplyResources(btnNewServer, "btnNewServer");
      btnNewServer.Image = Resources.ModelsData.NewFile;
      btnNewServer.Name = "btnNewServer";
      btnNewServer.UseVisualStyleBackColor = true;
      btnNewServer.Click += btnNewServer_Click;
      // 
      // btnLookupDB
      // 
      resources.ApplyResources(btnLookupDB, "btnLookupDB");
      btnLookupDB.Image = Resources.ModelsData.Search;
      btnLookupDB.Name = "btnLookupDB";
      btnLookupDB.UseVisualStyleBackColor = true;
      btnLookupDB.Click += btnLookupDB_Click;
      // 
      // btnCancel
      // 
      btnCancel.DialogResult = DialogResult.Cancel;
      resources.ApplyResources(btnCancel, "btnCancel");
      btnCancel.Name = "btnCancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      btnOk.DialogResult = DialogResult.OK;
      resources.ApplyResources(btnOk, "btnOk");
      btnOk.Name = "btnOk";
      btnOk.UseVisualStyleBackColor = true;
      btnOk.Click += btnOk_Click;
      // 
      // btnTest
      // 
      resources.ApplyResources(btnTest, "btnTest");
      btnTest.Name = "btnTest";
      btnTest.UseVisualStyleBackColor = true;
      btnTest.Click += btnTest_Click;
      // 
      // btnRemoveServer
      // 
      resources.ApplyResources(btnRemoveServer, "btnRemoveServer");
      btnRemoveServer.Image = Resources.ModelsData.DeleteRed_22x22;
      btnRemoveServer.Name = "btnRemoveServer";
      btnRemoveServer.UseVisualStyleBackColor = true;
      btnRemoveServer.Click += btnRemoveServer_Click;
      // 
      // txtUsername
      // 
      tableLayoutPanel1.SetColumnSpan(txtUsername, 5);
      txtUsername.DataBindings.Add(new Binding("Text", conStringDefinitionBindingSource, "Username", true));
      resources.ApplyResources(txtUsername, "txtUsername");
      txtUsername.Name = "txtUsername";
      // 
      // conStringDefinitionBindingSource
      // 
      conStringDefinitionBindingSource.DataSource = typeof(SQLConStringDefinition);
      // 
      // label5
      // 
      resources.ApplyResources(label5, "label5");
      label5.Name = "label5";
      // 
      // label4
      // 
      resources.ApplyResources(label4, "label4");
      label4.Name = "label4";
      label4.Click += label4_Click;
      // 
      // cbDB
      // 
      tableLayoutPanel1.SetColumnSpan(cbDB, 5);
      cbDB.DropDownStyle = ComboBoxStyle.DropDownList;
      cbDB.FormattingEnabled = true;
      resources.ApplyResources(cbDB, "cbDB");
      cbDB.Name = "cbDB";
      cbDB.SelectedIndexChanged += cbDB_SelectedIndexChanged;
      // 
      // label3
      // 
      resources.ApplyResources(label3, "label3");
      label3.Name = "label3";
      // 
      // cbAuth
      // 
      tableLayoutPanel1.SetColumnSpan(cbAuth, 5);
      cbAuth.DataBindings.Add(new Binding("SelectedItem", conStringDefinitionBindingSource, "AuthenticationMethod", true, DataSourceUpdateMode.OnPropertyChanged));
      cbAuth.DropDownStyle = ComboBoxStyle.DropDownList;
      cbAuth.FormattingEnabled = true;
      resources.ApplyResources(cbAuth, "cbAuth");
      cbAuth.Name = "cbAuth";
      cbAuth.SelectedIndexChanged += cbAuth_SelectedIndexChanged;
      // 
      // label2
      // 
      resources.ApplyResources(label2, "label2");
      label2.Name = "label2";
      // 
      // txtPassword
      // 
      tableLayoutPanel1.SetColumnSpan(txtPassword, 5);
      txtPassword.DataBindings.Add(new Binding("Text", conStringDefinitionBindingSource, "Password", true, DataSourceUpdateMode.OnPropertyChanged));
      resources.ApplyResources(txtPassword, "txtPassword");
      txtPassword.Name = "txtPassword";
      txtPassword.Leave += txtPassword_Leave;
      // 
      // cbServer
      // 
      tableLayoutPanel1.SetColumnSpan(cbServer, 5);
      cbServer.DropDownStyle = ComboBoxStyle.DropDownList;
      cbServer.FormattingEnabled = true;
      resources.ApplyResources(cbServer, "cbServer");
      cbServer.Name = "cbServer";
      cbServer.SelectedIndexChanged += cbServer_SelectedIndexChanged;
      cbServer.Leave += cbServer_Leave;
      // 
      // label1
      // 
      resources.ApplyResources(label1, "label1");
      label1.Name = "label1";
      // 
      // label7
      // 
      resources.ApplyResources(label7, "label7");
      label7.Name = "label7";
      // 
      // txtAppName
      // 
      tableLayoutPanel1.SetColumnSpan(txtAppName, 5);
      txtAppName.DataBindings.Add(new Binding("Text", conStringDefinitionBindingSource, "ApplicationName", true));
      resources.ApplyResources(txtAppName, "txtAppName");
      txtAppName.Name = "txtAppName";
      // 
      // chkCert
      // 
      resources.ApplyResources(chkCert, "chkCert");
      chkCert.DataBindings.Add(new Binding("Checked", conStringDefinitionBindingSource, "TrustServerCertificate", true));
      chkCert.Name = "chkCert";
      chkCert.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      resources.ApplyResources(label8, "label8");
      label8.Name = "label8";
      // 
      // label9
      // 
      resources.ApplyResources(label9, "label9");
      label9.Name = "label9";
      // 
      // checkBox1
      // 
      checkBox1.DataBindings.Add(new Binding("Checked", conStringDefinitionBindingSource, "Encrypt", true));
      resources.ApplyResources(checkBox1, "checkBox1");
      checkBox1.Name = "checkBox1";
      checkBox1.UseVisualStyleBackColor = true;
      // 
      // label10
      // 
      resources.ApplyResources(label10, "label10");
      label10.Name = "label10";
      // 
      // checkBox2
      // 
      checkBox2.DataBindings.Add(new Binding("Checked", conStringDefinitionBindingSource, "MultipleActiveResultSets", true));
      resources.ApplyResources(checkBox2, "checkBox2");
      checkBox2.Name = "checkBox2";
      checkBox2.UseVisualStyleBackColor = true;
      // 
      // errorProvider1
      // 
      errorProvider1.ContainerControl = this;
      // 
      // tableLayoutPanel1
      // 
      resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(cbServer, 1, 0);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Controls.Add(cbAuth, 1, 1);
      tableLayoutPanel1.Controls.Add(label4, 0, 2);
      tableLayoutPanel1.Controls.Add(label8, 0, 6);
      tableLayoutPanel1.Controls.Add(txtUsername, 1, 2);
      tableLayoutPanel1.Controls.Add(label5, 0, 3);
      tableLayoutPanel1.Controls.Add(txtAppName, 1, 5);
      tableLayoutPanel1.Controls.Add(txtPassword, 1, 3);
      tableLayoutPanel1.Controls.Add(label7, 0, 5);
      tableLayoutPanel1.Controls.Add(label3, 0, 4);
      tableLayoutPanel1.Controls.Add(cbDB, 1, 4);
      tableLayoutPanel1.Controls.Add(chkCert, 1, 6);
      tableLayoutPanel1.Controls.Add(label9, 2, 6);
      tableLayoutPanel1.Controls.Add(checkBox1, 3, 6);
      tableLayoutPanel1.Controls.Add(label10, 4, 6);
      tableLayoutPanel1.Controls.Add(checkBox2, 5, 6);
      tableLayoutPanel1.Controls.Add(btnRemoveServer, 7, 0);
      tableLayoutPanel1.Controls.Add(btnLookupDB, 6, 4);
      tableLayoutPanel1.Controls.Add(btnNewServer, 6, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      // 
      // dlgConnection
      // 
      AcceptButton = btnOk;
      resources.ApplyResources(this, "$this");
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      Controls.Add(picOk);
      Controls.Add(btnCancel);
      Controls.Add(btnOk);
      Controls.Add(btnTest);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      MinimizeBox = false;
      Name = "dlgConnection";
      ShowInTaskbar = false;
      Load += dlgConnection_Load;
      ((System.ComponentModel.ISupportInitialize)picOk).EndInit();
      ((System.ComponentModel.ISupportInitialize)conStringDefinitionBindingSource).EndInit();
      ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
   }

   #endregion

   private ToolTip toolTip1;
   private PictureBox picOk;
   private ErrorProvider errorProvider1;
   private Button btnNewServer;
   private Button btnLookupDB;
   private Button btnCancel;
   private Button btnOk;
   private Button btnTest;
   private Button btnRemoveServer;
   private TextBox txtUsername;
   private BindingSource conStringDefinitionBindingSource;
   private Label label5;
   private Label label4;
   private ComboBox cbDB;
   private Label label3;
   private ComboBox cbAuth;
   private Label label2;
   private TextBox txtPassword;
   private ComboBox cbServer;
   private Label label1;
   private Label label7;
   private Label label8;
   private CheckBox chkCert;
   private TextBox txtAppName;
   private Label label10;
   private CheckBox checkBox2;
   private Label label9;
   private CheckBox checkBox1;
   private TableLayoutPanel tableLayoutPanel1;
}