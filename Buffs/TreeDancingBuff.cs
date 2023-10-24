using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TreeDance;

namespace TreeDance.Buffs
{
    public class TreeDancingBuff : ModBuff
    {
        public ILog treeDanceLogger = ModContent.GetInstance<TreeDance>().Logger;
        public override void SetStaticDefaults()
        {
            //Set some settings for the buff
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
            Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = true; // This buff's timer will not decrease
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true; // This buff cannot be removed by the nurse

        }



        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams) // Prevent buff from being drawn
        {
            return false;
        }
        public override bool RightClick(int buffIndex) // Prevent buff from being cancelled
        {
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //I'm just going to add and remove the buff in the player class itself.

            treeDanceLogger.Info("test");
        }

    }
}
