using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Security
{
    public class UserSecurity
    {
        public bool ValidateUser(string user, string password) 
        {
            if (user == "darwin" && password == "test123")
            {
                return true;
            }
            return false;
        }
    }
}
