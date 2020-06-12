using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TerrasFuckery.Projectiles.Storm;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TerrasFuckery.Items.Storm
{
    public class StormCoreCannon : ModItem
    {
        public override bool CloneNewInstances => true; 
        public virtual void SafeSetDefaults() {  }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires cores of pure swirling energy");
        }
        public override void SetDefaults()
        {
            SafeSetDefaults();
            item.damage = 200;
            item.crit = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 40;
            item.useAnimation = 40;
            item.autoReuse = true;
            item.height = 44;
            item.width = 120;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(gold: 1, silver: 20);
            item.shoot = ProjectileType<StormCoreFriendly>();
            item.shootSpeed = 15f;
            item.UseSound = SoundID.Item15;
            item.noMelee = true;
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += TerraPlayer.ModPlayer(player).stormDamageAdd;
            mult *= TerraPlayer.ModPlayer(player).stormDamageMult;
        }
        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += TerraPlayer.ModPlayer(player).stormKnockback;
        }
        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += TerraPlayer.ModPlayer(player).stormCrit;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " storm " + damageWord;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StormCore>(), 3);
            recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
