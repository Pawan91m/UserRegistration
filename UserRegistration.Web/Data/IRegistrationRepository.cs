using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Web.Models;

namespace UserRegistration.Web.Data
{
    public interface IRegistrationRepository
    {
        public bool Register(UserModel user);
    }
}
