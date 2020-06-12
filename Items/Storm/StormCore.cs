using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrasFuckery.Items.Storm
{
    public class StormCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(12, 3));
            Tooltip.SetDefault("The power of a swirling storm rests within this core\nIt is not recommended to have this in your inventory");
        }
        public override void SetDefaults()
        {
            item.height = 40;
            item.width = 26;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(silver: 35);
            item.maxStack = 99;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 1);
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}
