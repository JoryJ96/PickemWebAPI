using PickemWPFUI.Library.Models;
using System.Threading.Tasks;

namespace PickemWPFUI.Library.Api
{
    public interface IPickSetEndpoint
    {
        Task PostPickSet(PickSetModel set);
    }
}