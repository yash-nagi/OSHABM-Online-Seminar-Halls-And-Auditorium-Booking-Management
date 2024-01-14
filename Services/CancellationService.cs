using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class CancellationService
    {
        CancellationRepository obj = new CancellationRepository();
        public int CancelRequest(Cancellation cancellation)
        {
            try
            {
                return obj.CancelRequest(cancellation);
            }
            catch 
            {
                throw;
            }

        }
        
        public List<Cancellation> GetCancellation()
        {
            try
            {
                return obj.GetCancellation();
            }
            catch
            {
                throw;
            }
        }
        
    }
}