
namespace Converters;

partial class frmGenCurrencies
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
        button2 = new Button();
        txtSQL = new TextBox();
        label2 = new Label();
        button1 = new Button();
        lblEnd = new Label();
        SuspendLayout();
        // 
        // button2
        // 
        button2.Location = new Point(725, 27);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 11;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // txtSQL
        // 
        txtSQL.Location = new Point(2, 28);
        txtSQL.Name = "txtSQL";
        txtSQL.Size = new Size(717, 23);
        txtSQL.TabIndex = 10;
        txtSQL.TextChanged += txtSQL_TextChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(3, 6);
        label2.Name = "label2";
        label2.Size = new Size(90, 15);
        label2.TabIndex = 9;
        label2.Text = "SQLConnection";
        // 
        // button1
        // 
        button1.Enabled = false;
        button1.Location = new Point(725, 73);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 12;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // lblEnd
        // 
        lblEnd.AutoSize = true;
        lblEnd.Location = new Point(725, 125);
        lblEnd.Name = "lblEnd";
        lblEnd.Size = new Size(69, 15);
        lblEnd.TabIndex = 13;
        lblEnd.Text = "Completed!";
        lblEnd.Visible = false;
        // 
        // frmGenCurrencies
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(882, 450);
        Controls.Add(lblEnd);
        Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(txtSQL);
        Controls.Add(label2);
        Name = "frmGenCurrencies";
        Text = "frmGenCurrencies";
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion

    private Button button2;
    private TextBox txtSQL;
    private Label label2;
    private Button button1;
    private Label lblEnd;
}