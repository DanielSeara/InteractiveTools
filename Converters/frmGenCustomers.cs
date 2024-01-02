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
public partial class frmGenCustomers : Form
{
   public frmGenCustomers()
   {
      InitializeComponent();
   }

   private void button2_Click(object sender, EventArgs e)
   {
      txtSQL.Text = ConnectionBuilder.PromptForConnection();

   }

   private void button1_Click(object sender, EventArgs e)
   {
      using SqlConnection connection = new(txtSQL.Text);
      connection.Open();
      SqlCommand cmd = connection.CreateCommand();
      cmd.CommandText = """
            INSERT INTO [Sales].[Customers]
                       ([Name]
                       ,[Address Line 1]
                       ,[Postal Code]
                       ,[State]
                       ,[CountryId]
                       ,[CurrencyId]
                       ,[Active]
                       )
                 VALUES
                       (@Name
                       ,@AddressLine1
                       ,@PostalCode
                       ,@State
                       ,@CountryId
                       ,@CurrencyId
                       ,1
                       )
               
            """;
      cmd.Parameters.Add("Name", SqlDbType.Text);
      cmd.Parameters.Add("AddressLine1", SqlDbType.Text);
      cmd.Parameters.Add("PostalCode", SqlDbType.Text);
      cmd.Parameters.Add("State", SqlDbType.Text);
      cmd.Parameters.Add("CountryId", SqlDbType.Int);
      cmd.Parameters.Add("CurrencyId", SqlDbType.Text);
      SqlCommand getCountries = connection.CreateCommand();
      getCountries.CommandText = """
            SELECT        GeoId, ISOCurrency
            FROM            Masters.Countries
            WHERE        (InUse = 1)
            """;
      using var reader = getCountries.ExecuteReader();
      while(reader.Read())
      {
         int country = reader.GetInt32(0);
         if(country < 32000)
         {
            string currency = reader.GetString(1);
            int maxcount = RandomNumberGenerator.GetInt32(100);
            for(int i = 0; i < maxcount; i++)
            {
               cmd.Parameters["Name"].Value = $"Customer {i}_{country}";
               cmd.Parameters["AddressLine1"].Value = $"Address of Customer {i}_{country}";
               cmd.Parameters["PostalCode"].Value = $"{country}{i}";
               cmd.Parameters["State"].Value = $"{country}_{i}";
               cmd.Parameters["CountryId"].Value = country;
               cmd.Parameters["CurrencyId"].Value = currency;
               cmd.ExecuteNonQuery();
            }
         }
      }
      reader.Close();
      connection.Close();
      lblEnd.Visible = true;
   }
   private void txtSQL_TextChanged(object sender, EventArgs e) => button1.Enabled = !string.IsNullOrEmpty(txtSQL.Text);

   private void button3_Click(object sender, EventArgs e)
   {

   }
}
