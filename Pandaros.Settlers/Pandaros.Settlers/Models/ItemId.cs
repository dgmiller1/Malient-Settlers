﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandaros.Settlers.Models
{
    public class ItemId : IEquatable<ItemId>
    {
        static Dictionary<string, ItemId> _cacheString = new Dictionary<string, ItemId>();
        static Dictionary<ushort, ItemId> _cacheUshort = new Dictionary<ushort, ItemId>();

        public static ItemId GetItemId(string name)
        {
            ItemId item = null;

            lock (_cacheString)
                lock(_cacheUshort)
                    if (!_cacheString.TryGetValue(name, out item))
                    {
                        item = new ItemId(name);
                        _cacheString.Add(item.Name, item);
                        _cacheUshort.Add(item.Id, item);
                    }

            return item;
        }

        public static ItemId GetItemId(ushort id)
        {
            ItemId item = null;

            lock (_cacheString)
                lock (_cacheUshort)
                    if (!_cacheUshort.TryGetValue(id, out item))
                    {
                        item = new ItemId(id);
                        _cacheString.Add(item.Name, item);
                        _cacheUshort.Add(item.Id, item);
                    }

            return item;
        }

        ushort _id;
        string _name;

        public ushort Id
        {
            get
            {
                if (_id == default(ushort))
                {
                    if (ItemTypes.IndexLookup.StringLookupTable.TryGetValue(_name, out var item))
                        _id = item;
                    else
                        throw new ArgumentException($"name {_name} is not registered as an item type yet. Unable to create ItemId object.");
                }

                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    if (ItemTypes.IndexLookup.IndexLookupTable.TryGetValue(_id, out string name))
                        _name = name;
                    else
                        throw new ArgumentException($"Id {_id} is not registered as an item type yet. Unable to create ItemId object.");
                }

                return _name;
            }
            private set
            {
                _name = value;
            }
        }

        private ItemId(ushort id)
        {
            _id = id;
        }

        private ItemId(string name)
        {
            _name = name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public bool Equals(ItemId other)
        {
            return Id == other.Id;
        }

        public static implicit operator string(ItemId itemId)
        {
            return itemId.Name;
        }

        public static implicit operator ushort(ItemId itemId)
        {
            return itemId.Id;
        }
    }
}
