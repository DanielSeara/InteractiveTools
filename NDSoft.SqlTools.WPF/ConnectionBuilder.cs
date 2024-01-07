
namespace NDSoft.SqlTools.WPF;

public static class ConnectionBuilder
{
   public static string? PromptForConnection(string connectionString = null)
   {
      var dlg = new dlgConnection();
      if(connectionString is not null)
         dlg.ConnectionString = connectionString;
      var result = dlg.ShowDialog();
      dlg.Close();
      if(result.HasValue && result.Value)
         return dlg.ConnectionString;
      else
         return null;
   }

}

