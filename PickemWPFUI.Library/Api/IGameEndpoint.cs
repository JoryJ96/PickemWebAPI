using PickemWPFUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickemWPFUI.Library.Api
{
    public interface IGameEndpoint
    {
        Task<List<Game>> GetAll();
    }
}