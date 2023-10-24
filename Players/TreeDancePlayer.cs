using log4net;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace TreeDance.Players
{
    
    public class TreeDancePlayer : ModPlayer
    {
        private ILog treeDanceLogger = ModContent.GetInstance<TreeDance>().Logger;
        private int prevDirection = 0;
        private byte WiggleDetectionCounter = 0;
        private byte WiggleDetectionThreshold = 60;
        private byte WigglePeriodCounter = 0;
        private byte WigglePeriodThreshold = 60;
        private byte TreeGrowthCooldownTicks = 30;
        private byte TreeGrowthCooldown = 0;

        //private bool CheckDirection(int playerDirection) => (playerDirection != prevDirection) ? true : false;

        public override void PostUpdate() // Update it is 12:23 AM I cba to write more comments so hopefully we remember the context here with what I have so far
        {

            //treeDanceLogger.Info(CheckDirection(Player.direction));

            // This code is very temporary

            if (Player.direction != prevDirection) // Reset counter if player changes direction
            {
                WiggleDetectionCounter = 0;
            }
            else
            {
                WiggleDetectionCounter = (byte)Math.Clamp(WiggleDetectionCounter + 1, Byte.MinValue, Byte.MaxValue); // Otherwise increment up to limit of data type
            }
            prevDirection = Player.direction; // Then store the current direction as the previous direction

            if (WiggleDetectionCounter <= WiggleDetectionThreshold && TreeGrowthCooldown == 0) // If the time since the last change in direction is less than the threshold and there's no cooldown
            {
                treeDanceLogger.Info("Attempted tree growth!"); // Attempt tree growth and apply cooldown
                TreeGrowthCooldown = TreeGrowthCooldownTicks;
            }

            if (TreeGrowthCooldown > 0)
            {
                TreeGrowthCooldown = (byte)Math.Clamp(WiggleDetectionCounter - 1, Byte.MinValue, Byte.MaxValue);
            }

            //treeDanceLogger.Info(Counter.ToString());
        }
    }
}
