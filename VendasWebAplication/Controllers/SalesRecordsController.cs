using Microsoft.AspNetCore.Mvc;
using VendasWebAplication.Services;

namespace VendasWebAplication.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate?.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate?.ToString("yyyy-MM-dd");
            var result = _salesRecordService.FindByDate(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate?.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate?.ToString("yyyy-MM-dd");
            var result = _salesRecordService.FindByDateGrouping(minDate, maxDate);
            return View(result);
        }
    }
}
