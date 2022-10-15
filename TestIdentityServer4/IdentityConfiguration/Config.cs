using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIdentityServer4.IdentityConfiguration
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("APICustomer", "API de los customers "),
      new ApiResource("APIEmployee", "API de los empleados ")
            };
        }
    }
}
