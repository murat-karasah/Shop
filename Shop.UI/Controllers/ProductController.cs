using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.UI.Models;
using System.Text.Json;

namespace Shop.UI.Controllers
{
    

    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            ProductModel model = new ProductModel();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7233/api/Products/" + id);
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonString = await response.Content.ReadAsStringAsync();
                var product = System.Text.Json.JsonSerializer.Deserialize<ProductModel>(jsonString, options);
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
