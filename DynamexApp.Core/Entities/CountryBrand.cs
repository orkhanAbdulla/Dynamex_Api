using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class CountryBrand
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
