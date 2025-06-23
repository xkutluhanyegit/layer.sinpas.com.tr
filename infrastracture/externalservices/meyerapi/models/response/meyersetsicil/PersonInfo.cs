using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infrastracture.externalservices.meyerapi.models.response.meyersetsicil
{
    public class PersonInfo
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sicilno { get; set; }
        public string PersonelNo { get; set; }
        public string GirisTarih { get; set; }  
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}