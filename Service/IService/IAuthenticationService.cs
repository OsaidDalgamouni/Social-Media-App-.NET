using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAuthenticationService
    {
        string CreateJWT(User user);
        //Authentication CreateJWT(Applicationuser User);

    }
}
