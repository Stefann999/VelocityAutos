using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAddress(string emailAddress);
    }
}
