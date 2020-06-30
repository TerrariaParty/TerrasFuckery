using Terraria;
using TerrasFuckery.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Projectiles
{
    public class MoonLordWhip : WhipClass
    {
        public override void SafeSetDefaults()
        {
            summonTagDamage = 26;
            rangeMult = 0.5f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            var owner = Main.player[projectile.owner];
            owner.AddBuff(BuffType<ExtraTerrestrialStrength>(), 180);
        }
    }
}