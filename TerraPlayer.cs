using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TerrasFuckery.Items;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery
{
    public class TerraPlayer : ModPlayer
    {
        public static TerraPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<TerraPlayer>();
        }
        public float stormDamageAdd;
        public float stormDamageMult = 1f;
        public float stormKnockback;
        public int stormCrit;
        int StormCoreLifeTimer = 0;
        public override void ResetEffects()
        {
            ResetVariables();
        }
        public override void UpdateDead()
        {
            ResetVariables();
        }
        private void ResetVariables()
        {
            stormDamageAdd = 0f;
            stormDamageMult = 1f;
            stormKnockback = 0f;
            stormCrit = 0;
        }
        public override void PostUpdateMiscEffects()
        {
            foreach (Item typeA in player.inventory)
            {
                if (typeA.type == ItemType<StormCore>())
                {
                    StormCoreLifeTimer++;
                    if (StormCoreLifeTimer % 3 == 0)
                    {
                        player.statLife -= 1;
                        StormCoreLifeTimer = 0;
                        player.AddBuff(BuffID.Electrified, 3);
                    }
                }
            }
        }
    }
}
