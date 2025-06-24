using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.models.response.meyersetsicilfotograf;

namespace infrastracture.externalservices.meyerapi.interfaces
{
    public interface IMeyerSetSicilFotografService
    {
        Task<meyersetsicilfotografresponse> MeyerSetSicilFotografAsync();
    }
}