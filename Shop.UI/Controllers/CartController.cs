using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.UI.Models;
using System.Dynamic;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Shop.UI.Controllers
{
    [Authorize(Roles = "Member")]
    public class CartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> AddCart()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            int idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var response = await client.GetAsync("https://localhost:7233/api/Cart");
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<CartModel>>(jsonString, options);
                 idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                list = list.Where(x => x.AppUserID == idm && x.Status ==false).ToList();
                if (list.Count==0)
                {
                    CartModel model = new CartModel();
                    model.AppUserID = idm;
                    model.Status = false;
                    var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("https://localhost:7233/api/Cart", stringContent);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");




        }

        [HttpGet]
        public async Task<IActionResult> AllListCart()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7233/api/Cart");
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<CartModel>>(jsonString, options);
                int idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var myCart = list.FirstOrDefault(x => x.AppUserID == idm && x.Status == false);
                dynamic mymodel = new ExpandoObject();

                if (myCart!=null)
                {
                    var cartItemresponse = await client.GetAsync("https://localhost:7233/api/CartItem");
                    var jsonCartItemString = await cartItemresponse.Content.ReadAsStringAsync();
                    var CartItemList = System.Text.Json.JsonSerializer.Deserialize<List<CartItemModel>>(jsonCartItemString, options);
                    CartItemList = CartItemList.Where(x => x.CartId == myCart.Id).ToList();
                    mymodel.CartItem = CartItemList;

                }
                mymodel.Cart = myCart;
                
                return View(mymodel);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> AddCartItem(int id,int amount,decimal price)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("https://localhost:7233/api/Cart");
           

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<CartModel>>(jsonString, options);
                int idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var myCart = list.FirstOrDefault(x => x.AppUserID == idm && x.Status == false);
               
           
            CartItemModel model = new CartItemModel();

            model.ProductId = id;
            model.ProducAmount = amount;
            model.ProducPrice = price;
            model.CartId = myCart.Id;
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7233/api/CartItem", stringContent);

            return RedirectToAction("AllListCart", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCart(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            CartModel myCart = new CartModel();
            int idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            myCart.AppUserID = idm;
            myCart.Status = true;
            myCart.Id=id;
            myCart.OrderId = 0;
            var stringContent = new StringContent(JsonConvert.SerializeObject(myCart), Encoding.UTF8, "application/json");
            var result = await client.PutAsync("https://localhost:7233/api/Cart", stringContent);

            return RedirectToAction("AddCart", "Cart");

        }

        [HttpGet]
        public async Task<IActionResult> PastCart()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7233/api/Cart");
            if (response.IsSuccessStatusCode)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var jsonString = await response.Content.ReadAsStringAsync();
                var list = System.Text.Json.JsonSerializer.Deserialize<List<CartModel>>(jsonString, options);
                int idm = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var myCart = list.Where(x => x.AppUserID == idm && x.Status == true).ToList();
                dynamic mymodel = new ExpandoObject();

                if (myCart != null)
                {
                    var cartItemresponse = await client.GetAsync("https://localhost:7233/api/CartItem");
                    var jsonCartItemString = await cartItemresponse.Content.ReadAsStringAsync();
                    var CartItemList = System.Text.Json.JsonSerializer.Deserialize<List<CartItemModel>>(jsonCartItemString, options);
                    List<CartItemModel> cartItemCartList = new List<CartItemModel>();
                    foreach (var item in myCart)
                    {
                        cartItemCartList.AddRange(CartItemList.Where(x => x.CartId == item.Id).ToList());

                    }
                    mymodel.CartItem = cartItemCartList;

                }
                mymodel.Cart = myCart;

                return View(mymodel);
            }
            else
            {
                return View();
            }
        }
}
}