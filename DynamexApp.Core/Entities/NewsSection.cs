using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class NewsSection:BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
