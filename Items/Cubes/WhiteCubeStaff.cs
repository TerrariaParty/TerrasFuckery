﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Projectiles.Cubes;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Items.Cubes
{
    public class WhiteCubeStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a basic cube to fight for you\nThere can only be one");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item44;
			item.shoot = ProjectileType<BasicCube>();
			item.buffType = BuffType<Buffs.BasicCubeBuff>(); //The buff added to player after used the item
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}

	}
}
