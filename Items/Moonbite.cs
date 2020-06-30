using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TerrasFuckery.Projectiles;
using Terraria;

namespace TerrasFuckery.Items
{
    public class Moonbite : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Disgusting parasite'" + "\n26 summon tag damage" + "\nStrike enemies to gain attack speed" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 35;
            item.useTime = 35;
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(gold: 10);
            item.shoot = ProjectileType<MoonLordWhip>();
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 175;
            item.knockBack = 3.5f;
            item.shootSpeed = 10;
            item.rare = ItemRarityID.Red;
        }
    }
}