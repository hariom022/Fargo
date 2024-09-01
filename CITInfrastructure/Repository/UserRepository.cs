using Azure;
using Azure.Identity;
using CITApplication.Data;
using CITApplication.ViewModels;
using CITDomain.Interfaces;
using CITDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICITDBContext _citcontext;
        private readonly ICITDbConnection _dbconnection;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        public UserRepository(ICITDBContext citcontext, ICITDbConnection dbconnection, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _citcontext = citcontext;
            _dbconnection = dbconnection;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        //public async void getUseDetails(UserModel model)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        HttpContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        //        string endpoint = _configuration["AzureAdAPI:APIENDPOINT"];
        //        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer{getToken().ToString()}");

        //        var response = await httpClient.GetAsync(new Uri(endpoint + String.Format("User/GetUserAPI")));
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseData = response.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //}

        //public string getToken()
        //{
        //    string Audience = _configuration["AzureAdAPI:Audience"];
        //    string ClientId = _configuration["AzureAdAPI:ClientId"];
        //    string ClinetSecret = _configuration["AzureAdAPI:ClinetSecret"];
        //    string TenentId = _configuration["AzureAdAPI:TenentId"];
        //    var response = new ClientSecretCredential(TenentId, ClientId, ClinetSecret);
        //    var result = response.GetToken(new Azure.Core.TokenRequestContext(new string[] { Audience }));
        //    return result.Token;
        //}

        public async Task<UserModel> GetUserDetails(string username, string UserEmail)
        {
            UserModel userModel = new UserModel();
            userModel.UserName = username;
            userModel.EMail = UserEmail;
            userModel.UserID = "2";

            using var client = new HttpClient();
            string endpoint = "http://localhost:5227/";
            HttpContent body = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {getToken().ToString()}");
            var response = await client.PostAsync(new Uri(endpoint + String.Format("api/User/GetUserAPI")), body);
            return userModel;

            //UserModel model = new UserModel();
            //using var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5227/");
            //var response = await client.GetAsync("User/GetUserAPI");
            //return model;
            //UserModel model = new UserModel();
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            //    string endpoint = _configuration["AzureAdAPI:APIENDPOINT"];
            //    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer{getToken().ToString()}");

            //    var response = await httpClient.GetAsync(new Uri(endpoint + String.Format("User/GetUserAPI")));
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseData = response.Content.ReadAsStringAsync().Result;
            //    }
            //}
            //return model;
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

        //public async Task <UserModel> GetUserDetails(string username)
        // {
        //     UserModel model = new UserModel();
        //     using (HttpClient httpClient = new HttpClient())
        //     {
        //         HttpContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        //         string endpoint = _configuration["AzureAdAPI:APIENDPOINT"];
        //         httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer{getToken().ToString()}");

        //         var response = await httpClient.GetAsync(new Uri(endpoint + String.Format("User/GetUserAPI")));
        //         if (response.IsSuccessStatusCode)
        //         {
        //             var responseData = response.Content.ReadAsStringAsync().Result;
        //         }
        //     }
        //     return model;
        // }
    }
}
