using LataPrzestepne.Models;

namespace LataPrzestepne.Interfaces
{
    public interface IRepozitory
    {
        IQueryable<HistoryData> GetData(string Search);
        public void AddHistoryData(HistoryData data);
        public void DeleteHistoryData(HistoryData remove);
    }
}
