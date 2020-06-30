using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TerrasFuckery.Projectiles;

namespace TerrasFuckery.Items
{
    public class SunplateStriker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Strike with the power of the sky and sun'" + "\n3 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTime = 30;
            item.width = 18;
            item.height = 18;
            item.value = 1000;
            item.shoot = ProjectileType<SunplateWhip>();
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.damage = 14;
            item.knockBack = 2;
            item.shootSpeed = 7;
            item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SunplateBlock, 25);
            recipe.AddIngredient(ItemID.Cloud, 15);
            recipe.AddIngredient(ItemID.Feather, 3);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}