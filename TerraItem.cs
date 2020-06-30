using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Items;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery
{
    class TerraItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			// Typically you'll also want to also add an item to the non-expert boss drops, that code can be found in ExampleGlobalNPC.NPCLoot. Use this and that to add drops to bosses.
			if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
			{
				if (Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(ItemType<Moonbite>(), 1);
				}
			}
		}
	}
}
