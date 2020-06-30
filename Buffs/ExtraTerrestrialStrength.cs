using Terraria;
using Terraria.ModLoader;

namespace TerrasFuckery.Buffs
{
    public class ExtraTerrestrialStrength : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Extra Terrestrial Strength");
			Description.SetDefault("Melee speed is increased");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TerraPlayer modPlayer = player.GetModPlayer<TerraPlayer>();
            modPlayer.MLWhipBuff = true;
			player.meleeSpeed += 0.5f;
		}
	}
}
