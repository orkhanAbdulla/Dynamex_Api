using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class DeliveryType:BaseEntity
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }
    }
}
