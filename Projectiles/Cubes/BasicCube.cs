using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TerrasFuckery.Buffs;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TerrasFuckery.Projectiles.Cubes
{
    public class BasicCube : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; 
		}

        public sealed override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 28;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.penetrate = -1;
            projectile.netImportant = true;
        }
		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool MinionContactDamage()
		{
			return true;
		}

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            #region Active check
            // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType<BasicCubeBuff>());
            }
            if (player.HasBuff(BuffType<BasicCubeBuff>()))
            {
                projectile.timeLeft = 2;
            }
            #endregion

            #region General behavior
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 48f;
            #endregion
        }
    }
}