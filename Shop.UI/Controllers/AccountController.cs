using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Shop.UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Shop.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(UserLoginModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var requesContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
          var response = await  client.PostAsync("https://localhost:7233/api/Auth/SignIn", requesContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel?.Token);
                if (token!=null)
                {
                    ClaimsIdentity identiy = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identiy), authProps);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }
        }
    }
}
