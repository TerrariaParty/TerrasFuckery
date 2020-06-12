using TerrasFuckery.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Tiles
{
	public class DirtManipulatorTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
			Main.tileFrameImportant[TileType<DirtManipulatorTile>()] = true;
			dustType = 7;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dirt Maniplator");
			AddMapEntry(new Color(120, 85, 60), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, ItemType<DirtManipulatorItem>());
		}
	}
}