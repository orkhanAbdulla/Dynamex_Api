using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class AbroadAddress:BaseEntity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string AdressTitle { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
    }
}
