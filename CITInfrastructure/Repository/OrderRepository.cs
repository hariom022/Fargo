using Azure.Identity;
using CITApplication.ViewModels;
using CITDomain.Interfaces;
using CITDomain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> CreateOrder(OrderModel order)
        {
            int Res = 0;
            order.Repeats = "Monday";
             
            using var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5227/");api/User/GetUserAPI
            string endpoint = "http://localhost:5112/";
            HttpContent body = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {getToken().ToString()}");
            var response = await client.PostAsync(new Uri(endpoint + String.Format("api/Order/CreateOrder")), body);
            //int REspo= response.StatusCode;
            return Res;
        }

        public async Task<OrderResponse> GetOrderData(int ResourceId)
        {
            // using var client = new HttpClient();
            OrderResponse orderResponse = new OrderResponse();
            using (var client = new HttpClient())
            {
                string endpoint = "http://localhost:5112/";
                //HttpContent body = new StringContent(JsonConvert.SerializeObject(ResourceId), Encoding.UTF8, "application/json");
                var data = new StringContent("{\"ResourceId\":" + ResourceId + "}", Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(new Uri(endpoint + String.Format("api/Order/GetOrderDetails")),data).Result;
                if (response.IsSuccessStatusCode)
                {
                    var OrderlistDetails = response.Content.ReadAsStringAsync().Result;
                    orderResponse = JsonConvert.DeserializeObject<OrderResponse>(OrderlistDetails);
                }
                //HttpResponseMessage response =  client.PostAsync("api/Order/GetOrderData", data).Result;
                //int REspo= response.StatusCode;
                //var Customerlist = response.Read<CustomerMaster>().ToList();
                //var ordertypelist = response.Read<OrderTypeMaster>().ToList();
                //var orderlist = response.Read<OrderModel>().ToList();
                //var OrderRes = new OrderResponse
                //{
                //    OrdertypeMasterlist = ordertypelist,
                //    customerMasterslist = Customerlist,
                //    orderlist = orderlist,
                //};
            }
            return orderResponse;
        }

        public string getToken()
        {
            var Securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AzureAdAPI:Key"]));
            var credentials = new SigningCredentials(Securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["AzureAdAPI:Issuer"], _configuration["AzureAdAPI:Audience"],
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
