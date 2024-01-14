using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class QueryService
    {
        QueryRepository obj;
        public QueryService()
        {
            obj = new QueryRepository();
        }
        public int CreateQuery(Query _queryDate)
        {
            try
            {
                return obj.CreateQuery(_queryDate);
            }
            catch
            {
                throw;
            }
        }
        public List<Query> GetQueryList()
        {
            try
            {
                return obj.GetQueryList();
            }
            catch
            {
                throw;
            }
        }
    }
}