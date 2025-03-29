using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Extensions;

namespace TextFilter.Strategies
{
    public class LessThanThreeCharFilterStrategy : IFilterStrategy
    {
        public bool RequiresFilter(string word)
        {
            return word.StripPunctuation().Trim().Length < 3;
        }
    }
}
