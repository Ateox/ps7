using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using LataPrzestepne.Data;
using LataPrzestepne.Models;
using LataPrzestepne.Services;
using LataPrzestepne.Interfaces;
using LataPrzestepne.ViewModels;

namespace LataPrzestepne.Pages
{
    public class HistoryPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty]
        //public ID ID { get; set; }

        //public HistoryData HistoryData { get; set; }
        public HistoryList<HistoryDataVM> HistoryPages { get; set; }
        private readonly IHistoryDataService _context;


        public HistoryPageModel(IHistoryDataService context)
        {
            _context = context;
        }

        public void OnGet(int pageIndex = 1)
        {
            HistoryPages = _context.getHistoryData(Search, pageIndex);
        }

        public IActionResult OnPost(int remid, int pageIndex = 1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR" + remid);
            _context.DeleteHistoryData(remid);
            HistoryPages = _context.getHistoryData(Search, pageIndex);
            return Page();
        }
    }
}