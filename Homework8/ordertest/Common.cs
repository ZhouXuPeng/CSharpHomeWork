using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    public class Common // static 不是必须
    {
        private int Flag { set; get; }
        public Common()
        {
            Flag = 0;
        }
    }
}
