using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infrastracture.externalservices.meyerapi.models.response.meyersetsicil
{
    public class meyersetsicilresponse
    {
        public List<PersonInfo> PersonInfo { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime Date { get; set; }
    }
}