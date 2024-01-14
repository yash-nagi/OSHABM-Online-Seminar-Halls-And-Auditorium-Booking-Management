using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class AuditoriumService
    {
        AuditoriumRepository auditrepo = null;
        public AuditoriumService()
        {
            auditrepo = new AuditoriumRepository();
        }
        public int CreateAuditorium(AuditoriumDetails _auditDetail)
        {
            try
            {
                return auditrepo.CreateAuditorium(_auditDetail);
            }
            catch
            {
                throw;
            }
        }
        public List<AuditoriumDetails> GetAuditorium()
        {
            try
            {
                return auditrepo.GetAuditorium();
            }
            catch
            {
                throw;
            }
        }
        public AuditoriumDetails GetAuditoriumById(string AuditID)
        {
            try
            {
                return auditrepo.GetAuditoriumById(AuditID);
            }
            catch
            {
                throw;
            }
        }
        public int UpdateAuditorium(string AuditID, AuditoriumDetails auditoriumData)
        {
            try
            {
                return auditrepo.UpdateAuditorium(AuditID, auditoriumData);
            }
            catch
            {
                throw;
            }
        }
        public void DeleteAuditoriumById(string AuditID)
        {
            try
            {
                auditrepo.DeleteAuditoriumById(AuditID);
            }
            catch
            {
                throw;
            }
        }
    }
}