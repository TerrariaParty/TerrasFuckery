using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Items;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery
{
    public class TerraNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.MoonLordCore && !Main.expertMode)
            {
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem(npc.getRect(), ItemType<Moonbite>(), 1);
                }
            }
        }
	}
}
