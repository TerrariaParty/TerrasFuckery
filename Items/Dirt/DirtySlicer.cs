using Microsoft.Xna.Framework;
using Mono.Cecil.Pdb;
using System.Data.SqlTypes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Tiles;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Items.Dirt
{
    public class DirtySlicer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Not a legend of Maxx reference'");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
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
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Dirt);
            }
        }
        string text;
        int randomNum;
        public override bool UseItem(Player player)
        {
            randomNum = Main.rand.Next(4);
            switch(randomNum)
            {
                default:
                    break;
                case 1:
                    text = "Engarde!";
                    break;
                case 2:
                    text = "Have at thee!";
                    break;
                case 3:
                    text = "Wait, why am I using a dirt sword?";
                    break;
            }
            if(Main.rand.Next(6) == 0)
            {
                CombatText.NewText(player.getRect(), new Color(150, 35, 5), text);
            }
            return true;
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
