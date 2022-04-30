using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class Language:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<Service> HowItWorks { get; set; }
        public ICollection<Slider> Sliders { get; set; }

    }
}
