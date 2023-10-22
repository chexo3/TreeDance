using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TreeDance.Configs
{
	public class Settings : ModConfig
	{
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Header("TreeDanceToggle")]
        [DefaultValue(true)]
        public bool TreeDanceToggle;
    }
}