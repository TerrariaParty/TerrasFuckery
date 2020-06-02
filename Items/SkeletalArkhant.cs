using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrasFuckery.Items
{
	public class SkeletalArkhant : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Unleashes a dicing fury\nRight click to fire a burst of beams");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.width = 32;
			item.height = 52;
			item.useTime = 14;
			item.useAnimation = 14;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.channel = true;
			item.noMelee = true;
			item.knockBack = 4f;
			item.autoReuse = true;
			item.noMelee = true;
			item.melee = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ProjectileID.Arkhalis;
			item.shootSpeed = 15f;
		}
		float wantedSpeed = 9.5f;
		Vector2 direction = Main.MouseWorld;
		public override bool AltFunctionUse(Player player)
		{
			Vector2 velocity = direction * wantedSpeed;
			for (int i = 0; i < 3; i++)
			{
				Projectile.NewProjectile(player.Center, velocity, ProjectileID.EnchantedBeam, 16, 2.5f);
			}
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				//should shoot a 3 burst of enchanted sword projectiles
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 45;
				item.useAnimation = 20;
				item.reuseDelay = 14;
				item.damage = 16;
				item.shoot = ProjectileID.EnchantedBeam;
				item.shootSpeed = 9.5f;
			}
			else
			{
				//haha arkhalis go brrrr
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 14;
				item.useAnimation = 14;
				item.damage = 26;
				item.shoot = ProjectileID.Arkhalis;
				item.shootSpeed = 15f;
			}
			return base.CanUseItem(player);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.Arkhalis);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}