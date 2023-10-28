using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportskaOpremaNemanjaTutunovic.Models.EFRepository
{
    public class AuthRepository : IAuthRepository
    {
        private ProdavnicaPPPEntities prodavnicaEntities = new ProdavnicaPPPEntities();
        public void addUser(UserBO user)
        {
            

            User userModel = new User
            {
                Password = user.Password,
                Username = user.Username,
                Email = user.Email
            };
            prodavnicaEntities.User.Add(userModel);
            prodavnicaEntities.SaveChanges();
        }

        public List<string> GetRolesForUser(string username)
        {
            User userModel = prodavnicaEntities.User.FirstOrDefault(t => t.Username == username);
            return userModel?.UserRole.Select(t => t.Role.Naziv).ToList();
        }

        public bool isValid(UserBO userBo)
        {
            bool isValid =
                 prodavnicaEntities.User.Any(t => t.Username == userBo.Username && t.Password == userBo.Password);
            return isValid;
        }

        public string GetRoleForUser(string username)
        {
            User userModel = prodavnicaEntities.User.FirstOrDefault(t => t.Username == username);
           string admin = userModel?.UserRole.Select(t => t.Role.Naziv).FirstOrDefault();
            return admin;
        }

        public int GetUserId(string username)
        {
            User userModel = prodavnicaEntities.User.FirstOrDefault(t => t.Username == username);
            int id = userModel.UserId;
            return id;
        }

        public bool postojiUsername(string username)
        {
            User userModel = prodavnicaEntities.User.FirstOrDefault(t => t.Username == username);
            if (userModel.Username == username)
            {
                return true;
            }
            return false;
        }
    }
}