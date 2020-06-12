using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using TerrasFuckery.Tiles;

namespace TerrasFuckery.Items.Tiles
{
	public class DirtManipulatorItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Manipulator");
		}

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.createTile = TileType<DirtManipulatorTile>();
            item.placeStyle = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 20);
            recipe.AddIngredient(ItemID.DirtRod, 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}