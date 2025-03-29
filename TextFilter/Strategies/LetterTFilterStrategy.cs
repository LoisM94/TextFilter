﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter.Strategies
{
    public class LetterTFilterStrategy : IFilterStrategy
    {
        public bool RequiresFilter(string word)
        {
            return word.ToLower().Contains('t');
        }
    }
}
