using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Test.ViewModels;
using Test.Models;

namespace Test.Services
{
    /// <summary>
    /// Сводное описание для TestService
    /// </summary>
    [WebService(Namespace = "http://test.kz/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class TestService : System.Web.Services.WebService
    {

        [WebMethod]
        public ServiceModel GetAllReviews()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                ServiceModel res = new ServiceModel();
                res.Reviews = db.Reviews.Select(q => new ReviewItem()
                {
                    ID = q.ID,
                    ClientName = q.ClientName,
                    Review = q.Review
                }).ToList();
                return res;
            }
        }
    }
}
