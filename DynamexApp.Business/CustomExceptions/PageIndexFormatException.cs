using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.CustomExceptions
{
    public class PageIndexFormatException:Exception
    {
        public PageIndexFormatException(string msg):base(msg)
        {
                
        }
    }
}
