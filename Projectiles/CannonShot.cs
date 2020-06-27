using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrasFuckery.Projectiles
{
    public class CannonShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cannon Shot");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 180;
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.width = 28;
            projectile.height = 28;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 1200;
            projectile.ranged = true;
            projectile.hostile = true;
        }
    }
}
