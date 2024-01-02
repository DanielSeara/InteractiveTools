namespace Converters;

partial class frmImportCSV
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
      label1 = new Label();
      txtFile = new TextBox();
      button1 = new Button();
      label2 = new Label();
      txtSQL = new TextBox();
      button2 = new Button();
      ofd = new OpenFileDialog();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(16, 15);
      label1.Name = "label1";
      label1.Size = new Size(25, 15);
      label1.TabIndex = 0;
      label1.Text = "File";
      label1.Click += label1_Click;
      // 
      // txtFile
      // 
      txtFile.Location = new Point(19, 32);
      txtFile.Name = "txtFile";
      txtFile.Size = new Size(721, 23);
      txtFile.TabIndex = 1;
      // 
      // button1
      // 
      button1.Location = new Point(746, 32);
      button1.Name = "button1";
      button1.Size = new Size(75, 23);
      button1.TabIndex = 2;
      button1.Text = "button1";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(24, 73);
      label2.Name = "label2";
      label2.Size = new Size(90, 15);
      label2.TabIndex = 3;
      label2.Text = "SQLConnection";
      // 
      // txtSQL
      // 
      txtSQL.Location = new Point(23, 95);
      txtSQL.Name = "txtSQL";
      txtSQL.Size = new Size(717, 23);
      txtSQL.TabIndex = 4;
      txtSQL.TextChanged += txtSQL_TextChanged;
      // 
      // button2
      // 
      button2.Location = new Point(746, 94);
      button2.Name = "button2";
      button2.Size = new Size(75, 23);
      button2.TabIndex = 5;
      button2.Text = "button2";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // ofd
      // 
      ofd.Filter = "CSV|*.csv|Text|*.txt|All|*.*";
      // 
      // frmImportCSV
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(849, 450);
      Controls.Add(button2);
      Controls.Add(txtSQL);
      Controls.Add(label2);
      Controls.Add(button1);
      Controls.Add(txtFile);
      Controls.Add(label1);
      Name = "frmImportCSV";
      Text = "frmImportCSV";
      ResumeLayout(false);
      PerformLayout();
   }

   #endregion

   private Label label1;
    private TextBox txtFile;
    private Button button1;
    private Label label2;
    private TextBox txtSQL;
    private Button button2;
    private OpenFileDialog ofd;
}