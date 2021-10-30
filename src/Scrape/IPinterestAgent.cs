using System.Threading.Tasks;

namespace Scrape
{
    public interface IPinterestAgent
    {
        Task<string> GetData(string[] keywords);
    }
}
