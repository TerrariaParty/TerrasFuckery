using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrasFuckery.Items
{
    public class Xenoburster : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Caesar would be proud'");
		}
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 5;
			item.useTime = 5;
			item.autoReuse = true;
			item.width = 54;
			item.height = 22;
			item.shoot = ProjectileID.Xenopopper;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item95;
			item.value = Item.sellPrice(gold: 25);
			item.damage = 36;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.ranged = true;
			item.rare = 9;
			item.knockBack = 1.5f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); // 2 or 3 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(12, 12).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
				Projectile.NewProjectile(player.Center, perturbedSpeed, ProjectileID.Xenopopper, 36, 1.5f, Main.myPlayer);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, -5);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Xenopopper, 6);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 20);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
