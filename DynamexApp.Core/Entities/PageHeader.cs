using DynamexApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Entities
{
    public class PageHeader:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PageType Page { get; set; }
        
    }
}
