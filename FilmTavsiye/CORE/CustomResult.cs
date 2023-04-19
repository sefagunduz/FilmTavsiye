using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class CustomResult<T> where T : class, new()
    {
        public int page { get; set; }
        public int count { get; set; }
        public int resultCount { get; set; }
        public int totalPage { get; set; }
        public int totalCount { get; set; }
        public IEnumerable<T> list { get; set; }
    }
}
