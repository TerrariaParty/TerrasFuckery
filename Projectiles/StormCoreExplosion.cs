using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrasFuckery.Projectiles
{
    public class StormCoreExplosion : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energized Storm");
		}

		public override void SetDefaults()
		{
			projectile.aiStyle = 0;
			projectile.width = 80;
			projectile.height = 80;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.alpha = 255;
			projectile.tileCollide = true;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			// Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
			if (Main.expertMode)
			{
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
				{
					damage /= 5;
				}
			}
		}
	}
}
