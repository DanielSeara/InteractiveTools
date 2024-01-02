using Microsoft.Data.SqlClient;

using NDSoft.SqlTools;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converters;
public partial class frmGenCrops : Form
{
   public frmGenCrops()
   {
      InitializeComponent();
   }

   private void button1_Click(object sender, EventArgs e)
   {
      if(ofd.ShowDialog() == DialogResult.OK)
      {
         txtFile.Text = ofd.FileName;
      }

   }

   private void button2_Click(object sender, EventArgs e)
   {
      txtSQL.Text = ConnectionBuilder.PromptForConnection();

   }

   private void button3_Click(object sender, EventArgs e)
   {
      List<CSVData> datas = new List<CSVData>();
      cSVDataBindingSource1.DataSource = datas;
      using SqlConnection connection = new SqlConnection(txtSQL.Text);
      connection.Open();
      SqlCommand command = connection.CreateCommand();
      command.Parameters.Add(
          new SqlParameter("@newId", SqlDbType.Int) { Direction = ParameterDirection.InputOutput });
      SqlCommand command2 = connection.CreateCommand();
      SqlCommand GetId = connection.CreateCommand();

      var f = System.IO.File.OpenText(txtFile.Text);
      f.ReadLine();
      while(!f.EndOfStream)

      {
         string s = f.ReadLine();
         var data = s.Split(";");
         datas.Add(new CSVData()
         {
            Cultivo = data[0],
            Campaña = data[1],
            Superficie = int.Parse(data[2]),
            Producción = int.Parse(data[3]),
            Rendimiento = int.Parse(data[4]),
         });
      }
      cSVDataBindingSource1.DataSource = datas;
      dataGridView1.DataSource = datas;
      Application.DoEvents();
      foreach(var data in datas)
      {
         command.CommandText = $"""
               INSERT INTO [Production].[Crops]
              ([Name]
              ,[EnglishName]
              ,[Yield])
              VALUES
              ('{data.Cultivo}'
              ,'{data.Cultivo}'
              ,{data.Rendimiento})
            """;
         command.Parameters["@newId"].Value = 0;
         command.ExecuteNonQuery();
         GetId.CommandText = $"SELECT         Id FROM            Production.Crops WHERE        (Name = N'{data.Cultivo}')";
         int idcrop = (int)GetId.ExecuteScalar();
         while(data.Generado < data.Superficie)
         {
            int qty = RandomNumberGenerator.GetInt32(data.Superficie - data.Generado);
            if(qty < 0 || (data.Superficie - data.Generado) < data.Superficie * .1) qty = data.Superficie - data.Generado;
            command.CommandText = $"""
                INSERT INTO [Production].[Sowers] 
                ([Name]
                ,[Address Line 1]
           
                )
                VALUES
                ('{data.Cultivo} Sower {qty}'
                ,'{data.Cultivo} Sower {qty} line1'
          
                )
                set @newId= IDENT_CURRENT('[Production].[Sowers]');
                """;
            command.Parameters["@newId"].Value = 0;
            command.ExecuteNonQuery();
            int id = (int)command.Parameters["@newId"].Value;
            command2.CommandText =
                $"""
                        INSERT INTO [Production].[Sown Fields]
                        (
                        IdSowers
                        ,IdCrops
                        ,[Area]
                        )
                        VALUES
                        ({id}
                        ,{idcrop}
                    
                        ,{qty}
                        )

                    """;
            command2.ExecuteNonQuery();
            data.Generado += qty;
            Application.DoEvents();
         }
      }
      connection.Close();
      label3.Text = "¡Listo!";
   }
}
public class CSVData : INotifyPropertyChanged
{
   private int generado;
   public event PropertyChangedEventHandler? PropertyChanged;

   public string Cultivo { get; set; }
   public string Campaña { get; set; }
   public int Superficie { get; set; }
   public int Producción { get; set; }
   public int Rendimiento { get; set; }
   public int Generado { get => generado; set { generado = value; Notify("Generado"); } }

   private void Notify(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
