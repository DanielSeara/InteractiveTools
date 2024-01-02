namespace Converters;

partial class frmGenCustomers
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
      lblEnd = new Label();
      button1 = new Button();
      button2 = new Button();
      txtSQL = new TextBox();
      label2 = new Label();
      button3 = new Button();
      SuspendLayout();
      // 
      // lblEnd
      // 
      lblEnd.AutoSize = true;
      lblEnd.Location = new Point(719, 426);
      lblEnd.Name = "lblEnd";
      lblEnd.Size = new Size(69, 15);
      lblEnd.TabIndex = 18;
      lblEnd.Text = "Completed!";
      lblEnd.Visible = false;
      // 
      // button1
      // 
      button1.Enabled = false;
      button1.Location = new Point(725, 67);
      button1.Name = "button1";
      button1.Size = new Size(75, 23);
      button1.TabIndex = 17;
      button1.Text = "Customers";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // button2
      // 
      button2.Location = new Point(725, 21);
      button2.Name = "button2";
      button2.Size = new Size(75, 23);
      button2.TabIndex = 16;
      button2.Text = "button2";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // txtSQL
      // 
      txtSQL.Location = new Point(2, 22);
      txtSQL.Name = "txtSQL";
      txtSQL.Size = new Size(717, 23);
      txtSQL.TabIndex = 15;
      txtSQL.TextChanged += txtSQL_TextChanged;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(3, 0);
      label2.Name = "label2";
      label2.Size = new Size(90, 15);
      label2.TabIndex = 14;
      label2.Text = "SQLConnection";
      // 
      // button3
      // 
      button3.Enabled = false;
      button3.Location = new Point(725, 105);
      button3.Name = "button3";
      button3.Size = new Size(75, 23);
      button3.TabIndex = 19;
      button3.Text = "Customers";
      button3.UseVisualStyleBackColor = true;
      button3.Click += button3_Click;
      // 
      // frmGenCustomers
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(button3);
      Controls.Add(lblEnd);
      Controls.Add(button1);
      Controls.Add(button2);
      Controls.Add(txtSQL);
      Controls.Add(label2);
      Name = "frmGenCustomers";
      Text = "frmGenCustomers";
      ResumeLayout(false);
      PerformLayout();
   }

   #endregion

   private Label lblEnd;
    private Button button1;
    private Button button2;
    private TextBox txtSQL;
    private Label label2;
    private Button button3;
}