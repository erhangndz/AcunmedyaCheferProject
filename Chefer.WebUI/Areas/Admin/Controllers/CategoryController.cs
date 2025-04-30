using Chefer.WebUI.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Chefer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;

        public CategoryController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7033/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            
                return View(categories);
            }
            return View();
        }
    }
}
