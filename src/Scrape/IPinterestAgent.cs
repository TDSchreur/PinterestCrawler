using System.Threading.Tasks;
using Scrape.Models;

namespace Scrape
{
    public interface IPinterestAgent
    {
        Task<ResponseModel> GetData(string[] keywords);
    }
}
