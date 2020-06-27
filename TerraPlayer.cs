using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TerrasFuckery.Items.Storm;
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
        public bool cubeBasic;
        int StormCoreLifeTimer = 0;
        public int summonTagDamage;
        public int summonTagCrit;
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
            cubeBasic = false;
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
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && target.whoAmI == player.MinionAttackTargetNPC) 
            { 
                damage += summonTagDamage; 
                if (summonTagCrit > 0) 
                { 
                    if (Main.rand.Next(1, 101) < summonTagCrit) 
                    { 
                        crit = true; 
                    } 
                } 
            }
        }
    }
}
