using Garage.Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.BusinessLogic.Services.Contracts
{
    public interface ITokenService
    {
        string CreateToken(Driver driver);
    }
}
