using Microsoft.AspNetCore.Mvc;
using Race_Day.Client.Models.DTOs;

using Race_Day.Mvc.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Race_Day.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _factory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient("ApiClient");
            var viewModel = new DashboardDto();
            try
            {
                viewModel.UserCount = await CountAsync(client, "api/User");
                viewModel.EventCount = await CountAsync(client, "api/Event");
                viewModel.CategoryCount = await CountAsync(client, "api/Category");
                viewModel.EnrolmentCount = await CountAsync(client, "api/Enrolment");
                viewModel.ResultCount = await CountAsync(client, "api/Results");


                viewModel.UpcomingEvents = await GetListAsync<EventDto>(client, "api/Events") ?? new();
                viewModel.Categories = await GetListAsync<CategoryDto>(client, "api/Categories") ?? new();
                viewModel.RecentEnrolments = await GetListAsync<EnrolmentDto>(client, "api/Enrolments") ?? new();
                viewModel.RecentResults = await GetListAsync<ResultDto>(client, "api/Results") ?? new();

                viewModel.TotalRevenue = viewModel.RecentEnrolments
                    .Where(e => e.PaymentStatus == "Paid")
                    .Sum(e => e.AmountPaid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching dashboard data");
            }
            return View(viewModel);
        }

        private async Task<List<T>?> GetListAsync<T>(HttpClient client, string path)
        {
            try
            {
                return await client.GetFromJsonAsync<List<T>>(path);
            }
            catch { return null; }
            }

        private async Task<int> CountAsync(HttpClient client, string path)
        {
            try
            {
                var list = await client.GetFromJsonAsync<List<object>>(path);
                return list?.Count ?? 0;
            }
            catch { return 0; }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
