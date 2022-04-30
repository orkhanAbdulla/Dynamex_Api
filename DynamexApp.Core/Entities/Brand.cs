using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class Brand:BaseEntity
    {
        public string Image { get; set; }
        public string Link { get; set; }
        public ICollection<CountryBrand> CountryBrands { get; set; }
    }
}
