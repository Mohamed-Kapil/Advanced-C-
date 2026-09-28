using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_C_.Q20
{
    public class Cache<TKey, TValue>
    {
        private Dictionary<TKey, CacheItem<TValue>> cache =
            new Dictionary<TKey, CacheItem<TValue>>();

        public void Add(TKey key, TValue value, int seconds)
        {
            cache[key] = new CacheItem<TValue>
            {
                Value = value,
                ExpirationTime = DateTime.Now.AddSeconds(seconds)
            };
        }
        public TValue Get(TKey key)
        {
            if (cache.ContainsKey(key))
            {
                var item = cache[key];

                if (DateTime.Now <= item.ExpirationTime)
                    return item.Value;

                cache.Remove(key);
            }

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            return cache.ContainsKey(key);
        }
        public void Remove(TKey key)
        {
            cache.Remove(key);
        }
    }

}