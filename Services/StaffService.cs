using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class StaffService
    {
        StaffRepository repository;
        public StaffService()
        {
            repository = new StaffRepository(); 
        }
        public int CreateStaff(Staff _staff)
        {
            try
            {
                return repository.CreateStaff(_staff);
            }
            catch
            {
                throw;
            }
        }
    }
}