﻿using NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pandaros.Settlers.Entities
{
    public class PlayerColonyInterface
    {
        FieldInfo _followersRef;
        FieldInfo _foodPerHourFieldRef;

        public PlayerColonyInterface(Colony c)
        {
            Colony = c;
            _foodPerHourFieldRef = typeof(Colony).GetField("foodUsePerHour", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            _followersRef = typeof(Colony).GetField("followers", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        }

        public Colony Colony { get; private set; }

        public float FoodPerHourField
        {
            get { return (float)_foodPerHourFieldRef.GetValue(Colony); }
            set { _foodPerHourFieldRef.SetValue(Colony, value); }
        }

        public List<NPCBase> Followers
        {
            get
            {
                return _followersRef.GetValue(Colony) as List<NPCBase>;
            }
        }
    }
}
