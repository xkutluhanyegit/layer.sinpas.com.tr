using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.models.response.token;

namespace infrastracture.externalservices.meyerapi.interfaces
{
    public interface IMeyerGetTokenService
    {
        Task<tokenresponse> GetTokenAsync();
    }
}