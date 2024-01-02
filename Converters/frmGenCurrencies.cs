using Microsoft.Data.SqlClient;

using NDSoft.SqlTools;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converters;
public partial class frmGenCurrencies : Form
{
    public frmGenCurrencies()
    {
        InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        txtSQL.Text = ConnectionBuilder.PromptForConnection();

    }

    private void button1_Click(object sender, EventArgs e)
    {
        List<string> currencyList = new List<string>();
        using SqlConnection connection = new(txtSQL.Text);
        connection.Open();
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = """
                INSERT INTO [Masters].[Currencies]
               ([ISO]
               ,[Name]
               ,[EnglishName]
               ,[Symbol]
               ,[Active]
               )
             VALUES
               (@ISO
               ,@Name
               ,@EnglishName
               ,@Symbol
               ,0)
               
            """;
        cmd.Parameters.Add("Name", SqlDbType.Text);
        cmd.Parameters.Add("EnglishName", SqlDbType.Text);
        cmd.Parameters.Add("Symbol", SqlDbType.Text);
        cmd.Parameters.Add("ISO", SqlDbType.Text);

        foreach(var country in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures))
        {
            var region = new RegionInfo(country.Name);
            if(region != null && region.ISOCurrencySymbol != "¤¤")
            {
                if(!currencyList.Contains(region.ISOCurrencySymbol))
                {
                    cmd.Parameters["Name"].Value = region.CurrencyNativeName;
                    cmd.Parameters["EnglishName"].Value = region.CurrencyEnglishName;
                    cmd.Parameters["Symbol"].Value = region.CurrencySymbol;
                    cmd.Parameters["ISO"].Value = region.ISOCurrencySymbol;
                    cmd.ExecuteNonQuery();
                    currencyList.Add(region.ISOCurrencySymbol);
                }
            }
        }

        connection.Close();
        lblEnd.Visible = true;
    }
    private void txtSQL_TextChanged(object sender, EventArgs e) => button1.Enabled = !string.IsNullOrEmpty(txtSQL.Text);

}
