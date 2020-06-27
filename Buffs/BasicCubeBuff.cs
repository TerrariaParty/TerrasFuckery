using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Buffs
{
	public class BasicCubeBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Basic Cube");
			Description.SetDefault("The basic cube will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TerraPlayer modPlayer = player.GetModPlayer<TerraPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Cubes.BasicCube>()] > 0)
			{
				modPlayer.cubeBasic = true;
			}
			if (!modPlayer.cubeBasic)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}