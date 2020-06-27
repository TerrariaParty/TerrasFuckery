using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerrasFuckery
{
    class TerraWorld : ModWorld
    {
        public static bool downedCannon;
        public override void Initialize()
        {
            downedCannon = false;
        }
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedCannon)
			{
				downed.Add("cannon");
			}
			return new TagCompound
			{
				["downed"] = downed,
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedCannon = downed.Contains("shaoyin");
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedCannon = flags[0];
			}
			else
			{
				mod.Logger.WarnFormat("Terra's Fuckery: Unknown loadVersion: {0}", loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			//only goes up to flags[7], flags[8] is nonsense
			var flags = new BitsByte();
			flags[0] = downedCannon;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedCannon = flags[0];
		}
	}
}
