
using NDSoft.SqlTools;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converters;
public partial class frmImportCSV : Form
{
   private bool byCode;

   public frmImportCSV()
   {
      InitializeComponent();
      byCode = true;
      txtSQL.Text = Properties.Settings.Default.SqlConnection;
      byCode = false;
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
      txtSQL.Text = ConnectionBuilder.PromptForConnection(txtSQL.Text);
   }

   private void label1_Click(object sender, EventArgs e)
   {

   }

   private void txtSQL_TextChanged(object sender, EventArgs e)
   {
      if(!byCode)
      {
         Properties.Settings.Default.SqlConnection = txtSQL.Text;
         Properties.Settings.Default.Save();
      }
   }
}
