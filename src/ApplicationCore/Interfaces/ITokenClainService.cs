using System.Threading.Tasks;

namespace ShopOnWeb.ApplicationCore.Interfaces
{
    public interface ITokenClainService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
