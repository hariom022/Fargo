using Azure;
using Azure.Identity;
using CITApplication.Data;
using CITDomain.Interfaces;
using CITDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public string getToken()
        {
            string Audience = _configuration["AzureAdAPI:Audience"];
            string ClientId = _configuration["AzureAdAPI:ClientId"];
            string ClinetSecret = _configuration["AzureAdAPI:ClinetSecret"];
            string TenentId = _configuration["AzureAdAPI:TenentId"];
            var response = new ClientSecretCredential(TenentId, ClientId, ClinetSecret);
            var result = response.GetToken(new Azure.Core.TokenRequestContext(new string[] { Audience }));
            return result.Token;
        }

        public async Task<UserModel> GetUserDetails(string username)
        {
            UserModel model = new UserModel();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _configuration["AzureAdAPI:APIENDPOINT"];
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer{getToken().ToString()}");

                var response = await httpClient.GetAsync(new Uri(endpoint + String.Format("User/GetUserAPI")));
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                }
            }
            return model;
        }
    }
}
