using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.interfaces;
using infrastracture.externalservices.meyerapi.models.request.setsicil;
using infrastracture.externalservices.meyerapi.models.request.token;
using infrastracture.externalservices.meyerapi.models.response.meyersetsicil;
using infrastracture.persistance.repositories.dapper.employee;
using Microsoft.Extensions.Configuration;

namespace infrastracture.externalservices.meyerapi.services
{
    public class MeyerSetSicilService : IMeyerSetSicilService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMeyerGetTokenService _meyerGetTokenService;
        private readonly IEmployeeRepository _employeeRepository;
        public MeyerSetSicilService(HttpClient httpClient,IConfiguration configuration,IMeyerGetTokenService meyerGetTokenService,IEmployeeRepository employeeRepository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _meyerGetTokenService = meyerGetTokenService;
            _employeeRepository = employeeRepository;
        }
        public async Task<meyersetsicilresponse> MeyerSetSicilAsync()
        {
            var token_ = _meyerGetTokenService.GetTokenAsync().Result.successMessage;
            var baseurl_ = _configuration.GetSection("meyerservice:baseurl").Value;
            var url_ = baseurl_+"/API/SicilServisi/setSicil";
            var query = 
            """
            select 
                COMPANY_ID,
                EMP_NO,
                FNAME,
                LNAME,
                PICTURE_ID,
                DATE_OF_BIRTH,
                SEX,
                BLOOD_TYPE,
                EMPLOYEE_STATUS,
                DATE_OF_EMPLOYMENT,
                CASE
                WHEN DATE_OF_LEAVING > TO_CHAR(SYSDATE,'yyyy.MM.dd')
                    THEN null
                    ELSE DATE_OF_LEAVING
                END AS DATE_OF_LEAVING
                from vw_meyer_set_sicil
            """;

            var collection = await  _employeeRepository.GetAllAsync(query);

            var requestBody = new MeyerSetSicilRequest{
                ConnectAuthentication = new MeyerConnectAuthentication
                {
                    Token = token_
                },
                RequestData = new MeyerSicilRequestData
                {
                    Data = new List<MeyerSicilModel>()
                    
                }
            };


            foreach (var item in collection)
            {
                var setSicilModel = new MeyerSicilModel{
                    Ad = item.FNAME,
                    Soyad = item.LNAME,
                    SicilNo = item.COMPANY_ID+"-"+item.EMP_NO,
                    DogumTarihi = item.DATE_OF_BIRTH,
                    Firma = item.COMPANY_ID,
                    Cinsiyet = string.IsNullOrWhiteSpace(item.SEX)
                    ? "0"
                    : (item.SEX.ToLower() == "erkek" ? "1" : "2"),
                    Kangrubu = item.BLOOD_TYPE,
                    GirisTarih = item.DATE_OF_EMPLOYMENT,
                    CikisTarih = item.DATE_OF_LEAVING
                };

                requestBody.RequestData.Data.Add(setSicilModel);
            }

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(url_, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var responseText = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Hata: {response.StatusCode} - {responseText}");
            }

            var responseContent = response.Content.ReadAsStringAsync().Result;

            
            var responseData = JsonSerializer.Deserialize<meyersetsicilresponse>(responseContent);
            
            var setSicilResponse = JsonSerializer.Deserialize<meyersetsicilresponse>(responseContent);

            return await Task.FromResult(setSicilResponse);

        }
    }
}