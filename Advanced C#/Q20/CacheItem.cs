using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_C_.Q20
{
    public class CacheItem<T>
    {
        public T Value { get; set; }
        public DateTime ExpirationTime { get; set; }
    }

}
