using log4net;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.Versioning;
using Terraria;
using Terraria.ModLoader;
using TreeDance;

namespace TreeDance.Players
{
    [RequiresPreviewFeatures]
    public class TreeDancePlayer : ModPlayer
    {
        private int prevDirection = 0;
        private Counter<byte> WiggleDetectionCounter = new Counter<byte>(0, byte.MinValue, byte.MaxValue);
        private byte WiggleDetectionThreshold = 60;
        private byte WigglePeriodCounter = 0;
        private byte WigglePeriodThreshold = 60;
        private byte TreeGrowthCooldownTicks = 30;
        private byte TreeGrowthCooldown = 0;

        private Counter<byte> byteCounter = new Counter<byte>(0, byte.MinValue, byte.MaxValue);
        

        //private bool CheckDirection(int playerDirection) => (playerDirection != prevDirection) ? true : false;

        public override void PostUpdate()
        {

            //treeDanceLogger.Info(CheckDirection(Player.direction));

            // This code is very temporary


            if (Player.direction != prevDirection) // Reset counter if player changes direction
            {
                WiggleDetectionCounter.Value = 0;
            }
            else
            {
                WiggleDetectionCounter.Value += 1; // Otherwise increment up to limit of data type
            }
            prevDirection = Player.direction; // Then store the current direction as the previous direction

            TreeDance.Log.Info("Counter value: " + WiggleDetectionCounter.Value);

            if (WiggleDetectionCounter.Value <= WiggleDetectionThreshold && TreeGrowthCooldown == 0) // If the time since the last change in direction is less than the threshold and there's no cooldown
            {
                //TreeDance.Log.Info("Attempted tree growth!"); // Attempt tree growth and apply cooldown
                TreeGrowthCooldown = TreeGrowthCooldownTicks;
            }

            if (TreeGrowthCooldown > 0)
            {
                TreeGrowthCooldown = (byte)System.Math.Clamp(TreeGrowthCooldown - 1, byte.MinValue, byte.MaxValue);
            }


            //Counter<byte> test = new Counter<byte>(0, byte.MinValue, byte.MinValue);

            //treeDanceLogger.Info(Counter.ToString());
        }
    }
}
