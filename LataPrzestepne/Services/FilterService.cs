using LataPrzestepne.Interfaces;
using LataPrzestepne.Filters;
using LataPrzestepne.Services;

namespace LataPrzestepne.Services
{
    public class FilterService : IFilter
    {
        public async Task<string> GetName(string name)
        {
            if (name.Contains("Edge") || name.Contains("Explorer"))
            {
                return "https://www.mozilla.org/pl/firefox/new";
            }
            return "";
        }
    }
}
