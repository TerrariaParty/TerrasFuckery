using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.Projectiles.Storm
{
	public class StormCoreFriendly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energized Storm");
		}

		public override void SetDefaults()
		{
			projectile.aiStyle = 0;
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.alpha = 70;
			projectile.tileCollide = true;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			// Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
			if (Main.expertMode)
			{
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
				{
					damage /= 5;
				}
			}
		}
		public override void AI()
		{
			Dust.NewDust(projectile.Center, 26, 26, DustID.Vortex, 0, 0, 50);
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item15, projectile.position);
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Vortex, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Vortex, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			for (int g = 0; g < 2; g++)
			{
				int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/StormCoreFriendly_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					projectile.position.X - Main.screenPosition.X, 
					projectile.position.Y - Main.screenPosition.Y
				),
				Color.White
				);
		}
	}
}
