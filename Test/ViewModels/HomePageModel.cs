using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.ViewModels
{
    public class PageModel
    {
        public ReviewItem MetaModel { get; set; }
        public List<ReviewItem> ListModel { get; set; }
    }

    public class ReviewItem
    {
        public long ID { get; set; }
        [Required]
        [DisplayName("Имя клиента")]
        public string ClientName { get; set; }
        [DisplayName("Отзыв")]
        public string Review { get; set; }
    }

    public class ServiceModel
    {
        public List<ReviewItem> Reviews { get; set; }
    }
}