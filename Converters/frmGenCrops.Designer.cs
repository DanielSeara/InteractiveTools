namespace Converters;

partial class frmGenCrops
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
        button1 = new Button();
        txtFile = new TextBox();
        label1 = new Label();
        ofd = new OpenFileDialog();
        button2 = new Button();
        txtSQL = new TextBox();
        label2 = new Label();
        dataGridView1 = new DataGridView();
        cultivoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        campañaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        superficieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        Generado = new DataGridViewTextBoxColumn();
        producciónDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        rendimientoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        cSVDataBindingSource1 = new BindingSource(components);
        button3 = new Button();
        label3 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)cSVDataBindingSource1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(728, 21);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 5;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // txtFile
        // 
        txtFile.Location = new Point(1, 21);
        txtFile.Name = "txtFile";
        txtFile.Size = new Size(721, 23);
        txtFile.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(-2, 4);
        label1.Name = "label1";
        label1.Size = new Size(25, 15);
        label1.TabIndex = 3;
        label1.Text = "File";
        // 
        // button2
        // 
        button2.Location = new Point(721, 72);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 8;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // txtSQL
        // 
        txtSQL.Location = new Point(-2, 73);
        txtSQL.Name = "txtSQL";
        txtSQL.Size = new Size(717, 23);
        txtSQL.TabIndex = 7;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(-1, 51);
        label2.Name = "label2";
        label2.Size = new Size(90, 15);
        label2.TabIndex = 6;
        label2.Text = "SQLConnection";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cultivoDataGridViewTextBoxColumn, campañaDataGridViewTextBoxColumn, superficieDataGridViewTextBoxColumn, Generado, producciónDataGridViewTextBoxColumn, rendimientoDataGridViewTextBoxColumn });
        dataGridView1.DataSource = cSVDataBindingSource1;
        dataGridView1.Location = new Point(2, 105);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(713, 333);
        dataGridView1.TabIndex = 9;
        // 
        // cultivoDataGridViewTextBoxColumn
        // 
        cultivoDataGridViewTextBoxColumn.DataPropertyName = "Cultivo";
        cultivoDataGridViewTextBoxColumn.HeaderText = "Cultivo";
        cultivoDataGridViewTextBoxColumn.Name = "cultivoDataGridViewTextBoxColumn";
        // 
        // campañaDataGridViewTextBoxColumn
        // 
        campañaDataGridViewTextBoxColumn.DataPropertyName = "Campaña";
        campañaDataGridViewTextBoxColumn.HeaderText = "Campaña";
        campañaDataGridViewTextBoxColumn.Name = "campañaDataGridViewTextBoxColumn";
        // 
        // superficieDataGridViewTextBoxColumn
        // 
        superficieDataGridViewTextBoxColumn.DataPropertyName = "Superficie";
        superficieDataGridViewTextBoxColumn.HeaderText = "Superficie";
        superficieDataGridViewTextBoxColumn.Name = "superficieDataGridViewTextBoxColumn";
        // 
        // Generado
        // 
        Generado.DataPropertyName = "Generado";
        Generado.HeaderText = "Generado";
        Generado.Name = "Generado";
        // 
        // producciónDataGridViewTextBoxColumn
        // 
        producciónDataGridViewTextBoxColumn.DataPropertyName = "Producción";
        producciónDataGridViewTextBoxColumn.HeaderText = "Producción";
        producciónDataGridViewTextBoxColumn.Name = "producciónDataGridViewTextBoxColumn";
        // 
        // rendimientoDataGridViewTextBoxColumn
        // 
        rendimientoDataGridViewTextBoxColumn.DataPropertyName = "Rendimiento";
        rendimientoDataGridViewTextBoxColumn.HeaderText = "Rendimiento";
        rendimientoDataGridViewTextBoxColumn.Name = "rendimientoDataGridViewTextBoxColumn";
        // 
        // cSVDataBindingSource1
        // 
        cSVDataBindingSource1.DataSource = typeof(CSVData);
        // 
        // button3
        // 
        button3.Location = new Point(725, 121);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 10;
        button3.Text = "Procesar";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(735, 173);
        label3.Name = "label3";
        label3.Size = new Size(0, 15);
        label3.TabIndex = 11;
        // 
        // frmGenCrops
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(831, 450);
        Controls.Add(label3);
        Controls.Add(button3);
        Controls.Add(dataGridView1);
        Controls.Add(button2);
        Controls.Add(txtSQL);
        Controls.Add(label2);
        Controls.Add(button1);
        Controls.Add(txtFile);
        Controls.Add(label1);
        Name = "frmGenCrops";
        Text = "frmGenCrops";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)cSVDataBindingSource1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox txtFile;
    private Label label1;
    private OpenFileDialog ofd;
    private Button button2;
    private TextBox txtSQL;
    private Label label2;
    private DataGridView dataGridView1;
    private Button button3;
    private BindingSource cSVDataBindingSource1;
    private DataGridViewTextBoxColumn cultivoDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn campañaDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn superficieDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn Generado;
    private DataGridViewTextBoxColumn producciónDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn rendimientoDataGridViewTextBoxColumn;
    private Label label3;
}