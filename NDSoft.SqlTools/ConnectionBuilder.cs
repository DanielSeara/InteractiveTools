using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSoft.SqlTools;
public static class ConnectionBuilder
{
   public static string? PromptForConnection(string connectionString = null)
   {
      var dlg = new NDSoft.SqlTools.WinForms.dlgConnection();
      if(!string.IsNullOrEmpty(connectionString))
         dlg.ConnectionString = connectionString;
      if(dlg.ShowDialog() == DialogResult.OK)
         return dlg.ConnectionString;
      else
         return null;
   }
}
