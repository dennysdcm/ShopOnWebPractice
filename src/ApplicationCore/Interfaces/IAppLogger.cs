namespace ShopOnWeb.ApplicationCore.Interfaces
{
    // To eliminate dependencies on ASP.NET Core Logging
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
