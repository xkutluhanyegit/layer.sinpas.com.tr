using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infrastracture.externalservices.meyerapi.models.response.token
{
    public class tokenresponse
    {
        public bool success { get; set; }
        public string successMessage { get; set; }
        public bool error { get; set; }
        public string errorMessage { get; set; }
        public string date { get; set; }
    }
}