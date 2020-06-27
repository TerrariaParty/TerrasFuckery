using Terraria.ModLoader;

namespace TerrasFuckery.Projectiles.Dirt
{
    public class DirtySlicerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dirty Slicer");
        }
        public override void SetDefaults()
        {
            projectile.width = 78;
            projectile.height = 78;
            projectile.aiStyle = 140;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 8;
            projectile.ownerHitCheck = true;
        }
    }
}
