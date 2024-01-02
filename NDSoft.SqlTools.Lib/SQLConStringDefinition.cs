using Microsoft.Data.SqlClient;

namespace NDSoft.SqlTools.Lib;

public class SQLConStringDefinition

{
   private string authenticationMethod = "ActiveDirectoryIntegrated";

   public event EventHandler<RequireCredentialsEventArgs> RequireCredentials;

   /// <summary>
   /// Gets the authentication methods names list.
   /// </summary>
   /// <value> The authentication methods names list. </value>
   public static string[] AuthenticationMethodsList =>
      (from el in Enum.GetNames(typeof(SqlAuthenticationMethod))
       where el != "NotSpecified"
       orderby el
       select el).ToArray();

   /// <summary>
   /// Gets or sets the name of the application.
   /// </summary>
   /// <value> The name of the application. </value>
   public string ApplicationName { get; set; }

   /// <summary>
   /// Gets or sets the authentication method name.
   /// </summary>
   /// <value> The authentication method name. </value>
   public string AuthenticationMethod
   {
      get => authenticationMethod; set
      {
         authenticationMethod = value;
         SqlAuthenticationMethod method = (SqlAuthenticationMethod)Enum.Parse(typeof(SqlAuthenticationMethod), AuthenticationMethod);
         switch(method)
         {
            case SqlAuthenticationMethod.ActiveDirectoryPassword:
            case SqlAuthenticationMethod.SqlPassword:
               CallRequireCredentials(true);
               break;

            case SqlAuthenticationMethod.ActiveDirectoryIntegrated:
            case SqlAuthenticationMethod.ActiveDirectoryInteractive:
            case SqlAuthenticationMethod.ActiveDirectoryServicePrincipal:
            case SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow:
            case SqlAuthenticationMethod.ActiveDirectoryManagedIdentity:
            case SqlAuthenticationMethod.ActiveDirectoryMSI:
            case SqlAuthenticationMethod.ActiveDirectoryDefault:
            case SqlAuthenticationMethod.NotSpecified:
               CallRequireCredentials(false);
               break;

            default:
               CallRequireCredentials(false);
               break;
         }
      }
   }

   /// <summary>
   /// Gets the connection string, prepared from the different parameters' values.
   /// </summary>
   /// <value> The connection string. </value>
   public string ConnectionString
   {
      get
      {
         SqlAuthenticationMethod method = (SqlAuthenticationMethod)Enum.Parse(typeof(SqlAuthenticationMethod), AuthenticationMethod);
         SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
         sqlConnectionStringBuilder.DataSource = Server;
         sqlConnectionStringBuilder.InitialCatalog = Database ?? "master";
         sqlConnectionStringBuilder.Authentication = method;
         sqlConnectionStringBuilder.MultipleActiveResultSets = MultipleActiveResultSets;
         sqlConnectionStringBuilder.Encrypt = Encrypt;
         sqlConnectionStringBuilder.TrustServerCertificate = TrustServerCertificate;
         sqlConnectionStringBuilder.ApplicationName = ApplicationName ?? "No name";
         switch(method)
         {
            case SqlAuthenticationMethod.ActiveDirectoryIntegrated:
               sqlConnectionStringBuilder.IntegratedSecurity = true;
               break;

            case SqlAuthenticationMethod.ActiveDirectoryInteractive:
               break;

            case SqlAuthenticationMethod.ActiveDirectoryPassword:
            case SqlAuthenticationMethod.SqlPassword:
               sqlConnectionStringBuilder.UserID = Username;
               sqlConnectionStringBuilder.Password = Password;
               break;

            case SqlAuthenticationMethod.ActiveDirectoryServicePrincipal:
            case SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow:
            case SqlAuthenticationMethod.ActiveDirectoryManagedIdentity:
            case SqlAuthenticationMethod.ActiveDirectoryMSI:
            case SqlAuthenticationMethod.ActiveDirectoryDefault:
            case SqlAuthenticationMethod.NotSpecified:
               break;

            default:
               break;
         }
         return sqlConnectionStringBuilder.ToString();
      }
   }

   /// <summary>
   /// Gets or sets the database name.
   /// </summary>
   /// <value> The database name. </value>
   public string Database { get; set; }

   /// <summary>
   /// Gets or sets a value indicating whether this <see cref="SQLConStringDefinition"/> is encrypted.
   /// </summary>
   /// <value> <c> true </c> if encrypt; otherwise, <c> false </c>. </value>
   public bool Encrypt { get; set; } = true;

   /// <summary>
   /// Gets or sets a value indicating whether multiple active result sets are eabled.
   /// </summary>
   /// <value> <c> true </c> if multiple active result sets are enabled; otherwise, <c> false </c>. </value>
   public bool MultipleActiveResultSets { get; set; } = true;

   /// <summary>
   /// Gets or sets the password.
   /// </summary>
   /// <value> The password. </value>
   public string Password { get; set; }

   /// <summary>
   /// Gets or sets the server name.
   /// </summary>
   /// <value> The server name. </value>
   public string Server { get; set; }

   /// <summary>
   /// Gets or sets a value indicating whether trust server certificate.
   /// </summary>
   /// <value> <c> true </c> if trust server certificate; otherwise, <c> false </c>. </value>
   public bool TrustServerCertificate { get; set; } = true;

   /// <summary>
   /// Gets or sets a value indicating whether the connection requires credentials.
   /// </summary>
   /// <value> <c> true </c> if requires credentials; otherwise, <c> false </c>. </value>
   public Boolean UseCredentials { get; set; }

   /// <summary>
   /// Gets or sets the username.
   /// </summary>
   /// <value> The username. </value>
   public string Username { get; set; }

   /// <summary>
   /// Creates a new instance of this type, using the values of the <paramref name="connectionString"/> string.
   /// </summary>
   /// <param name="connectionString"> The connection string. </param>
   /// <returns> </returns>
   public static SQLConStringDefinition BuildFromString(String connectionString)
   {
      SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
      SQLConStringDefinition conStringDefinition = new SQLConStringDefinition()
      {
         Server = sqlConnectionStringBuilder.DataSource,
         Database = sqlConnectionStringBuilder.InitialCatalog,
         AuthenticationMethod = sqlConnectionStringBuilder.Authentication.ToString(),
         ApplicationName = sqlConnectionStringBuilder.ApplicationName,
         Username = sqlConnectionStringBuilder.UserID,
         Password = sqlConnectionStringBuilder.Password,
         TrustServerCertificate = sqlConnectionStringBuilder.TrustServerCertificate,
         Encrypt = sqlConnectionStringBuilder.Encrypt,
         MultipleActiveResultSets = sqlConnectionStringBuilder.MultipleActiveResultSets
      };
      return conStringDefinition;
   }

   /// <summary>
   /// Retrieves the databases' names.
   /// </summary>
   /// <returns> <see cref="string[]"/> of Database Names </returns>
   public string[] RetrieveDatabases()
   {
      string oldDb = Database;
      Database = "master";
      try
      {
         SqlConnection con = new SqlConnection(ConnectionString);
         con.Open();
         string sql = "select name from sys.databases where name not in ('master','model','tempdb','msdb') order by name";
         using SqlCommand com = new SqlCommand(sql, con);
         using SqlDataReader reader = com.ExecuteReader();
         List<string> list = new List<string>();
         while(reader.Read())
         {
            list.Add(reader.GetString(0));
         }
         return list.ToArray();
      }
      catch(Exception)
      {
         throw;
      }
      finally { Database = oldDb; }
   }

   private void CallRequireCredentials(bool needCredentials) =>
      RequireCredentials?.Invoke(this,
         new RequireCredentialsEventArgs(needCredentials));
}