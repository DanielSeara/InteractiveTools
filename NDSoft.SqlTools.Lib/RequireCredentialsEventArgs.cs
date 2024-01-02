namespace NDSoft.SqlTools.Lib;

public class RequireCredentialsEventArgs : EventArgs
{
   public RequireCredentialsEventArgs(bool needCredentials) => NeedCredentials = needCredentials;

   public bool NeedCredentials { get; }
}