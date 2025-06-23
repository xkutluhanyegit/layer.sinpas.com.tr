using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.interfaces;
using infrastracture.externalservices.meyerapi.models.response.token;
using Microsoft.Extensions.Configuration;

namespace infrastracture.externalservices.meyerapi.services
{
    public class MeyerGetTokenService : IMeyerGetTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MeyerGetTokenService(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<tokenresponse> GetTokenAsync()
        {
            var baseurl_ = _configuration.GetSection("meyerservice:baseurl").Value;
            var requesturl = baseurl_ + "/API/TokenServisi/Token";
            var pin_ = _configuration.GetSection("meyerservice:pin").Value;
            var username_ = _configuration.GetSection("meyerservice:username").Value;
            var password_ = _configuration.GetSection("meyerservice:password").Value;

            var requestBody = new
            {
                pin = pin_,
                username = username_,
                password = password_
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requesturl, content);

            if (!response.IsSuccessStatusCode)
            {
                var responseText =  response.Content.ReadAsStringAsync();
                throw new Exception($"Hata: {response.StatusCode} - {responseText}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<tokenresponse>(responseContent);
            if (tokenResponse == null)
            {
                throw new Exception("Token response boş.");
            }
            return tokenResponse;
        }
    }
}