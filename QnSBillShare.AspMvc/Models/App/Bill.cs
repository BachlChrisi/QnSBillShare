using QnSBillShare.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBase.Extensions;
using System.ComponentModel.DataAnnotations;

namespace QnSBillShare.AspMvc.Models.App
{
    public class Bill : ModelObject, Contracts.Persistence.App.IBill
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Friends { get; set; }

        public void CopyProperties(IBill other)
        {
            base.CopyProperties(other);

            (Title,Date, Description, Currency, Friends) = (other.Title,other.Date, other.Description, other.Currency, other.Friends);
        }
    }
}
