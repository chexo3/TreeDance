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
            /*
             
            Procedure is going to be:

            1. Player update checks if it should add this buff, breaking out early if the buff is already active
            2. Buff update will check if buff should be removed, and will remove itself and break out early if so
            3. Both above checks will use a method in the buff class to do this, but will behave differently depending on the result
            4. If buff update doesn't decide to remove itself, it will then run the tree growing code.
             
             */

            treeDanceLogger.Info("test");
        }

    }
}
