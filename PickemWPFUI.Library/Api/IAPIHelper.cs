using PickemWPFUI.Models;
using System.Threading.Tasks;

namespace PickemWPFUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}