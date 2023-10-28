using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskaOpremaNemanjaTutunovic.Models.Interfaces
{
    interface IAuthRepository
    {
        bool isValid(UserBO userBo);
        void addUser(UserBO user);
        List<string> GetRolesForUser(string username);

         string GetRoleForUser(string username);
        int GetUserId(string username);
        bool postojiUsername(string username);
    }
}
