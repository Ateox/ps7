using LataPrzestepne.Data;
using LataPrzestepne.Models;
using LataPrzestepne.Interfaces;
//using static Humanizer.On;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LataPrzestepne.Services
{
    public class Repozitory : IRepozitory
    {

        private readonly DataContext _context;
        public Repozitory(DataContext context)
        {
            _context = context;
        }
        public IQueryable<HistoryData> GetData(string Search)
        {
            if(Search == null) { 
                return _context.HistoryData;
            }
            var query = _context.HistoryData.Where(d => d.Name.Contains(Search) || d.Year.ToString().Contains(Search));
            query = query.OrderByDescending(x => x.Time);
            return query;
        }
        public void AddHistoryData(HistoryData data)
        {
            _context.HistoryData.Add(data);
            _context.SaveChanges();
        }
        public void DeleteHistoryData(HistoryData remove)
        {
            _context.HistoryData.Remove(remove);
            _context.SaveChanges();
        }
    }
}
