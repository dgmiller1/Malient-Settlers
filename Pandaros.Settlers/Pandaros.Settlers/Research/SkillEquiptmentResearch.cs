﻿using Pandaros.Settlers.Entities;
using Pandaros.Settlers.Items;
using Pandaros.Settlers.Items.Reagents;
using Pandaros.Settlers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandaros.Settlers.Research
{
    public class SkillEquiptmentResearch : IPandaResearch
    {
        public Dictionary<ushort, int> RequiredItems => new Dictionary<ushort, int>()
        {
            { ItemId.GetItemId(Adamantine.NAME), 1 },
            { ItemId.GetItemId(AirStone.Item.name), 1 },
            { ItemId.GetItemId(EarthStone.Item.name), 1 },
            { ItemId.GetItemId(WaterStone.Item.name), 1 },
            { ItemId.GetItemId(FireStone.Item.name), 1 },
        };

        public int NumberOfLevels => 2;

        public float BaseValue => 1;

        public List<string> Dependancies => new List<string>()
        {
            Jobs.SorcererRegister.JOB_NAME + "1"
        };

        public int BaseIterationCount => 200;

        public bool AddLevelToName => true;

        public string name => "SkillEquiptmentResearch";

        public void OnRegister()
        {
            
        }

        public void ResearchComplete(object sender, ResearchCompleteEventArgs e)
        {
            if (e.Research.Level == 1)
            {
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledBoots1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledChest1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledGloves1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledHelm1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledLegs1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledShield1"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledSword1"), true);
            }
            else
            {
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledBoots2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledChest2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledGloves2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledHelm2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledLegs2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledShield2"), true);
                e.Manager.Colony.RecipeData.SetRecipeAvailability(new Recipes.RecipeKey(GameLoader.NAMESPACE + "SkilledSword2"), true);
            }
        }
    }
}
