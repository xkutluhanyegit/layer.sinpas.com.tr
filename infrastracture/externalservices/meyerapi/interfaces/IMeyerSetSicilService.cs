using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.models.response.meyersetsicil;

namespace infrastracture.externalservices.meyerapi.interfaces
{
    public interface IMeyerSetSicilService
    {
        Task<meyersetsicilresponse> MeyerSetSicilAsync();
    }
}