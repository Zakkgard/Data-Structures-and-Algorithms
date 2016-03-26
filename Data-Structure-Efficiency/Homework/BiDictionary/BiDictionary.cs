using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private Dictionary<TKey1, List<TValue>> valuesByFirstKey = new Dictionary<TKey1, List<TValue>>();
        private Dictionary<TKey2, List<TValue>> valuesBySecondKey = new Dictionary<TKey2, List<TValue>>();
        private Dictionary<Tuple<TKey1, TKey2>, List<TValue>> valuesByBothKeys = new Dictionary<Tuple<TKey1, TKey2>, List<TValue>>();

        public void Add(TKey1 firstKey, TKey2 secondKey, TValue value)
        {
            if (!this.valuesByFirstKey.ContainsKey(firstKey))
            {
                this.valuesByFirstKey.Add(firstKey, new List<TValue>());
            }

            this.valuesByFirstKey[firstKey].Add(value);

            if (!this.valuesBySecondKey.ContainsKey(secondKey))
            {
                this.valuesBySecondKey.Add(secondKey, new List<TValue>());
            }

            this.valuesBySecondKey[secondKey].Add(value);

            var pair = new Tuple<TKey1, TKey2>(firstKey, secondKey);
            if (!this.valuesByBothKeys.ContainsKey(pair))
            {
                this.valuesByBothKeys.Add(pair, new List<TValue>());
            }

            this.valuesByBothKeys[pair].Add(value);
        }

        public IEnumerable<TValue> Find(TKey1 firstKey, TKey2 secondKey)
        {
            var pair = new Tuple<TKey1, TKey2>(firstKey, secondKey);

            if (!this.valuesByBothKeys.ContainsKey(pair))
            {
                return Enumerable.Empty<TValue>();
            }

            return this.valuesByBothKeys[pair];
        }

        public IEnumerable<TValue> FindByFirstKey(TKey1 firstKey)
        {
            if (!this.valuesByFirstKey.ContainsKey(firstKey))
            {
                return Enumerable.Empty<TValue>();
            }

            return this.valuesByFirstKey[firstKey];
        }

        public IEnumerable<TValue> FindBySecondKey(TKey2 secondKey)
        {
            if (!this.valuesBySecondKey.ContainsKey(secondKey))
            {
                return Enumerable.Empty<TValue>();
            }

            return this.valuesBySecondKey[secondKey];
        }

        public bool Remove(TKey1 firstKey, TKey2 secondKey)
        {
            var byBothKeys = this.Find(firstKey, secondKey);
            foreach (var item in byBothKeys)
            {
                this.valuesByFirstKey[firstKey].Remove(item);
                this.valuesBySecondKey[secondKey].Remove(item);
            }

            this.valuesByBothKeys[new Tuple<TKey1, TKey2>(firstKey, secondKey)].Clear();
            return true;
        }
    }
}
