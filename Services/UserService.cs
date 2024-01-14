using Microsoft.Win32;
using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;


namespace OSHABM_proj.Services
{
    public class UserService
    {
        readonly UserRepository obj = new UserRepository();

        public int CreateUser(User userData)
        {
            try
            {
                return obj.CreateUser(userData);
            }
            catch
            {
                throw;
            }
        }

        public User GetUserDetailsById(string EmailID)
        {
            try
            {
                return obj.GetUserDetailsById(EmailID);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateUser(string EmailID,User userData) 
        {
            try
            {
                return obj.UpdateUser(EmailID,userData);
            }
            catch
            {
                throw;
            }
        }
        public List<User> GetUserData()
        {
            try
            {
                return obj.GetUserData();
            }
            catch
            {
                throw;
            }
        }
        public int DeleteUserDetails(string EmailID)
        {
            try
            {
                return obj.DeleteUserDetails(EmailID);
            }
            catch
            {
                throw;
            }
        }
        public User GetUserDetailsAdminById(string EmailID)
        {
            try
            {
                return obj.GetUserDetailsById(EmailID);
            }
            catch
            {
                throw;
            }
        }
    }
}