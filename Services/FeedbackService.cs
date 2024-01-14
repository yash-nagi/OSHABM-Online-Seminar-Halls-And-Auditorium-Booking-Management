using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class FeedbackService
    {
        readonly FeedbackRepository obj; 
        public FeedbackService() 
        { 
            obj = new FeedbackRepository();
        }

        public int CreateFeedback(Feedback _feedbackData)
        {
            try
            {
               return obj.CreateFeedback(_feedbackData);
            }
            catch
            {
                throw;
            }
        }
        public List<Feedback> GetFeedback()
        {
            try
            {
                return obj.GetFeedback();
            }
            catch
            {
                throw;
            }
        }
    }
}