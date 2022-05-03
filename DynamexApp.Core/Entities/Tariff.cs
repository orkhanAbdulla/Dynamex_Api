using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class Tariff:BaseEntity
    {
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
        public bool IsMoreThanOneKg { get; set; }
        public decimal Price { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int DeliveryTypeId { get; set; }
        public DeliveryType DeliveryType { get; set; }
    }
}
