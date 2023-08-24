using Microsoft.AspNetCore.Mvc;
using Serkan_MVC.Models;
using System.Text;
using System.Text.Json;

namespace Serkan_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public async Task <IActionResult> OrderPage()
        {
           HttpClient client= new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5103/api");
            var response = await client.GetAsync($"{client.BaseAddress}/Orders");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<OrderGetDtoItem>>(responseRead);

            return View(result.data);



        }
        public async Task<IActionResult> OrderId(int orderId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5103/api");
            var response = await client.GetAsync($"{client.BaseAddress}/Orders/{"orderId"}");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<OrderGetDtoItem>>(responseRead);
            return View(result.data);
        }
        [HttpPost]
        public async Task<IActionResult> Employee(string iscininAdi, string iscininSoyadi)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5103/api");
            var employeeData = new
            {
                Adi = iscininAdi,
                Soyadi = iscininSoyadi
            };

            // Veriyi JSON formatında serialize edin
            var jsonData = JsonSerializer.Serialize(employeeData);

            // StringContent ile HTTP isteği için içerik oluşturun
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // POST isteği atın ve cevabı bekleyin
            var response = await client.PostAsync("Employees", content);

            // Cevabın içeriğini okuyun
            var responseContent = await response.Content.ReadAsStringAsync();

            // Gerekli işlemleri yapın (örneğin, cevabı deserialize edebilirsiniz)
            var result = JsonSerializer.Deserialize<ResponseComing<EmployeePostDto>>(responseContent);

            // View'a veriyi taşıyın
            ViewBag.ResponseResult = result;

            // View'ı döndürün
            return View();
        }
           

        
        public async Task<IActionResult> Customer()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5103/api");
            var response = await client.GetAsync($"{client.BaseAddress}/Customers");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<CustomerGetDtoItem>>(responseRead);

            return View(result.data);

        }
    }
}
