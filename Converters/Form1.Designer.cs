namespace Converters;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        txtSource = new TextBox();
        txtResultado = new TextBox();
        label2 = new Label();
        panel1 = new Panel();
        button4 = new Button();
        button3 = new Button();
        button2 = new Button();
        button1 = new Button();
        btnUTF8Enc = new Button();
        button5 = new Button();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(46, 15);
        label1.TabIndex = 0;
        label1.Text = "&Origen:";
        // 
        // txtSource
        // 
        txtSource.Location = new Point(12, 27);
        txtSource.Multiline = true;
        txtSource.Name = "txtSource";
        txtSource.Size = new Size(504, 124);
        txtSource.TabIndex = 1;
        // 
        // txtResultado
        // 
        txtResultado.Location = new Point(12, 177);
        txtResultado.Multiline = true;
        txtResultado.Name = "txtResultado";
        txtResultado.Size = new Size(504, 124);
        txtResultado.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 159);
        label2.Name = "label2";
        label2.Size = new Size(62, 15);
        label2.TabIndex = 2;
        label2.Text = "&Resultado:";
        // 
        // panel1
        // 
        panel1.Controls.Add(button5);
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(button2);
        panel1.Controls.Add(button1);
        panel1.Controls.Add(btnUTF8Enc);
        panel1.Dock = DockStyle.Right;
        panel1.Location = new Point(647, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(153, 450);
        panel1.TabIndex = 4;
        // 
        // button4
        // 
        button4.AutoSize = true;
        button4.Location = new Point(44, 218);
        button4.Name = "button4";
        button4.Size = new Size(97, 25);
        button4.TabIndex = 4;
        button4.Text = "Gen Currencies";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button3
        // 
        button3.Location = new Point(43, 189);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 3;
        button3.Text = "Gen Crops";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button2
        // 
        button2.Location = new Point(43, 160);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 2;
        button2.Text = "Import CSV";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.Location = new Point(3, 32);
        button1.Name = "button1";
        button1.Size = new Size(140, 23);
        button1.TabIndex = 1;
        button1.Text = "UTF8 Decode";
        button1.UseVisualStyleBackColor = true;
        // 
        // btnUTF8Enc
        // 
        btnUTF8Enc.Location = new Point(3, 3);
        btnUTF8Enc.Name = "btnUTF8Enc";
        btnUTF8Enc.Size = new Size(140, 23);
        btnUTF8Enc.TabIndex = 0;
        btnUTF8Enc.Text = "UTF8 Encode";
        btnUTF8Enc.UseVisualStyleBackColor = true;
        btnUTF8Enc.Click += btnUTF8Enc_Click;
        // 
        // button5
        // 
        button5.AutoSize = true;
        button5.Location = new Point(43, 258);
        button5.Name = "button5";
        button5.Size = new Size(98, 25);
        button5.TabIndex = 5;
        button5.Text = "Gen Customers";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(panel1);
        Controls.Add(txtResultado);
        Controls.Add(label2);
        Controls.Add(txtSource);
        Controls.Add(label1);
        Name = "Form1";
        Text = "Form1";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtSource;
    private TextBox txtResultado;
    private Label label2;
    private Panel panel1;
    private Button button1;
    private Button btnUTF8Enc;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
}
