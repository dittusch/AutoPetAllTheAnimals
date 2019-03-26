﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace AutoPetAllTheAnimals
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += GameLoopOnDayStarted;
        }

        private static void GameLoopOnDayStarted(object sender, DayStartedEventArgs e)
        {
            var animals = Game1.getFarm().getAllFarmAnimals();

            foreach (var animal in animals)
            {
                animal.friendshipTowardFarmer.Value = Math.Min(1000, animal.friendshipTowardFarmer.Value + 15);
                
                //TODO: This might be a bit too much when a new day started. Observe.
                animal.happiness.Value = (byte)Math.Min(255,
                    animal.happiness.Value + Math.Max(5, 40 - animal.happinessDrain.Value));

                animal.wasPet.Value = true;
            }
        }
    }
}