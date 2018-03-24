﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pandaros.Settlers.Entities;
using NPC;
using Pandaros.Settlers.AI;
using Pandaros.Settlers.Managers;

namespace Pandaros.Settlers.AI
{
    public static class SettlerEvaluation 
    {
        private static readonly double _minFoodHours = TimeSpan.FromDays(3).TotalHours;

        public static float SpawnChance(Players.Player p, Colony c, PlayerState state)
        {
            float chance = .3f;
            var remainingBeds = BedBlockTracker.GetCount(p) - c.FollowerCount;

            if (remainingBeds < 1)
                chance -= 0.1f;

            if (remainingBeds >= state.MaxPerSpawn)
                chance += 0.3f;
            else if (remainingBeds > SettlerManager.MIN_PERSPAWN)
                chance += 0.15f;

            var hoursofFood = Stockpile.GetStockPile(p).TotalFood / c.FoodUsePerHour;

            if (hoursofFood > _minFoodHours)
                chance += 0.2f;

            var jobCount = JobTracker.GetOpenJobCount(p);

            if (jobCount > state.MaxPerSpawn)
                chance += 0.4f;
            else if (jobCount > SettlerManager.MIN_PERSPAWN)
                chance += 0.1f;
            else
                chance -= 0.2f;

            if (state.Difficulty != GameDifficulty.Easy)
                if (c.InSiegeMode ||
                c.LastSiegeModeSpawn != 0 &&
                Pipliz.Time.SecondsSinceStartDouble - c.LastSiegeModeSpawn > TimeSpan.FromMinutes(5).TotalSeconds)
                    chance -= 0.4f;

            return chance;
        }
    }
}