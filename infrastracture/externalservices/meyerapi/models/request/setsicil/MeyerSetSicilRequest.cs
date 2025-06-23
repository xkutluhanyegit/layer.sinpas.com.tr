using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.models.request.token;

namespace infrastracture.externalservices.meyerapi.models.request.setsicil
{
    public class MeyerSetSicilRequest
    {
        public MeyerConnectAuthentication ConnectAuthentication { get; set; }
        public MeyerSicilRequestData RequestData { get; set; } 
    }
}