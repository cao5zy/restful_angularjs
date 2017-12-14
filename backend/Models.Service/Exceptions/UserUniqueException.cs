using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Service.Exceptions
{
    public class UserUniqueException :Exception
    {
        public UserUniqueException(string userName) : base($"{ userName} has been existed. ")
        {}
    }
}
