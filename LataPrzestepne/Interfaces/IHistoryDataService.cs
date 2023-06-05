using LataPrzestepne.Models;
using LataPrzestepne.ViewModels;
using System;

namespace LataPrzestepne.Interfaces
{
    public interface IHistoryDataService
    {
        //public IQueryable<HistoryData> GetActivePeople();
        public HistoryList<HistoryDataVM> getHistoryData(string search, int pageIndex);
        public void AddHistoryData(HistoryData data);
        public void DeleteHistoryData(int Id);
    }
}

