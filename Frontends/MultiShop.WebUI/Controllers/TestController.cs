﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";

            using (var httpclient = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id","MultiShopVisitorId"},
                        {"client_secret","multishopsecret"},
                        {"grant_type","client_credentials"}
                    })
                };

                using (var response = await httpclient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var tokenResponse = JsonObject.Parse(content);

                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.GetAsync("https://localhost:7227/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        public IActionResult Deneme()
        {
            return View();
        }

        public async Task<IActionResult> Deneme1()
        {
            var values = await _categoryService.GetAllAsync();

            return View(values);
        }
    }
}
