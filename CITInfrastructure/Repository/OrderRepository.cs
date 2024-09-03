using Azure.Identity;
using CITDomain.Interfaces;
using CITDomain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
            string endpoint = "http://localhost:5227/";
            HttpContent body = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {getToken().ToString()}");
            var response = await client.PostAsync(new Uri(endpoint + String.Format("api/Order/CreateOrderAPI")), body);
            return Res;
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
