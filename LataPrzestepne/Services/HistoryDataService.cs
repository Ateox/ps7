using System;
using LataPrzestepne.Models;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Data;
using LataPrzestepne.ViewModels;
//using Microsoft.EntityFrameworkCore;
//using static Humanizer.On;

namespace LataPrzestepne.Services

{
    public class HistoryDataService: IHistoryDataService
    {
        private readonly IRepozitory _Repozitory;
        public HistoryDataService(IRepozitory context)
        {
            _Repozitory = context;
        }
        public HistoryList<HistoryDataVM> getHistoryData(string search, int pageIndex)
        {
            var Query = _Repozitory.GetData(search);
            List<HistoryDataVM> historyDataVMs = new List<HistoryDataVM>();
            foreach (var item in Query)
            {
                var Data = new HistoryDataVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    UserID = item.UserId,
                    Year = item.Year
                };
                historyDataVMs.Add(Data);
            }
            return HistoryList<HistoryDataVM>.Create(historyDataVMs, pageIndex, 20);
        }
        public void AddHistoryData(HistoryData data)
        {
            _Repozitory.AddHistoryData(data);
        }
        public void DeleteHistoryData(int Id)
        {
            var query = _Repozitory.GetData("");
            var remove = query.Where(d => d.Id == Id).FirstOrDefault();
            _Repozitory.DeleteHistoryData(remove);
        }
    }
}
