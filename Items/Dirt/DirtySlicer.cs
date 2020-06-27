using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Tiles;
using TerrasFuckery.Projectiles.Dirt;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Items.Dirt
{
    public class DirtySlicer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Spins a dirty blade around you\nRight click to thrust forward");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = 100;
            item.crit = 10;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.knockBack = 2.5f;
            item.autoReuse = true;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ProjectileType<DirtySlicerProjectile>();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 15;
                item.useTime = 20;
                item.useAnimation = 20;
                item.rare = ItemRarityID.Green;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
                item.melee = true;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.shoot = ProjectileType<DirtySlicerProjectileAlt>();
            }
            else
            {
                item.damage = 14;
                item.useTime = 20;
                item.useAnimation = 20;
                item.rare = ItemRarityID.Green;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
                item.melee = true;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.shoot = ProjectileType<DirtySlicerProjectile>();
                item.channel = true;
            }
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 16);
            recipe.AddTile(TileType<DirtManipulatorTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
