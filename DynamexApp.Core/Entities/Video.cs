using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class Video:BaseEntity
    {
        public string Image { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

    }
}
