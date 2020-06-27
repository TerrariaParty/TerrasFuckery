using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TerrasFuckery.Items.Cubes;
using TerrasFuckery.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TerrasFuckery.NPCs.Cannon
{
    [AutoloadBossHead]
    public class Cannon : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 55000;
            npc.damage = 95;
            npc.defense = 18;
            npc.knockBackResist = 0f;
            npc.width = 38;
            npc.height = 48;
            npc.value = Item.buyPrice(0, 8, 50, 0);
            npc.boss = true;
            npc.scale = 1.25f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath14;
            //music = MusicID.Title;
            //musicPriority = MusicPriority.BossHigh; 
            //bossBag = ItemType<CannonTreasureBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 110000;
            npc.defense = 18;
            npc.damage = 135;
        }
        public override void NPCLoot()
        {
            //Item.NewItem(npc.getRect(), ItemType<OddlyShapedGun>(), 1);
            //Item.NewItem(npc.getRect(), ItemType<CannonPiece>(), Main.rand.Next(2,6));
            if (Main.rand.Next(6) == 0)
            {
                Item.NewItem(npc.getRect(), ItemType<WhiteCubeStaff>(), 1);
            }
            if (!TerraWorld.downedCannon)
            {
                TerraWorld.downedCannon = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
        }
        int Speed = 4;
        int DashSpeed = 18;
        float offsetX = 160;
        int Phase1Timer = 0;
        int DashTimer = 0;
        int DashDuration = 45;
        bool BulletsOrDash;
        int Phase2Timer = 0;
        bool ChangedPhase1ToPhase2;
        public override void AI()
        {
            npc.TargetClosest(true);

            if (npc.life > (npc.lifeMax / 3) * 2)
            {
                Phase1Timer++;
                if(Phase1Timer % 35 == 0)
                {
                    Phase1Timer = 0;
                    Projectile.NewProjectile(npc.Center, npc.DirectionTo(Main.player[npc.target].Center) * 8, ProjectileType<CannonShot>(), Main.player[npc.target].statLifeMax / 6, 1f);
                }
                npc.rotation = npc.target;
                Vector2 GoTo = Main.player[npc.target].Center;
                GoTo += new Vector2(offsetX, -360);
                if (Vector2.Distance(npc.Center, GoTo) < 10f)
                {
                    offsetX *= -1f; //this flips the direction, so instead of 160 to the right it's 160 to the left and vise versa
                    GoTo = Main.player[npc.target].Center;
                    GoTo += new Vector2(offsetX, -360);
                }
                npc.velocity = npc.DirectionTo(GoTo) * Speed;
            }
            if (npc.life > (npc.lifeMax / 3) && npc.life < (npc.lifeMax / 3) * 2)
            {
                if (ChangedPhase1ToPhase2 == false)
                {
                    npc.frameCounter += 1;
                    //Gore.NewGore(npc.Center, new Vector2(6, 6).RotatedByRandom(120), ModGore<CannonGore1>());
                    //Gore.NewGore(npc.Center, new Vector2(6, 6).RotatedByRandom(120), ModGore<CannonGore2>());
                    //Gore.NewGore(npc.Center, new Vector2(6, 6).RotatedByRandom(120), ModGore<CannonGore3>());
                    //Gore.NewGore(npc.Center, new Vector2(6, 6).RotatedByRandom(120), ModGore<CannonGore4>());
                    ChangedPhase1ToPhase2 = true;
                    npc.velocity = Vector2.Zero;
                }
                if (BulletsOrDash)
                {
                    DashTimer++;
                    DashDuration--;
                    if (++DashTimer % 75 == 0)
                    {
                        if (DashDuration < 0)
                        {
                            DashDuration = 45;
                            Main.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), npc.Center);
                            npc.velocity = npc.DirectionTo(Main.player[npc.target].Center) * DashSpeed;
                        }
                    }
                    if (DashTimer > 0 && DashDuration == 0)
                    {
                        npc.velocity = Vector2.Zero;
                        BulletsOrDash = false;
                    }
                }
                else
                {
                    Phase2Timer++;
                    if (Phase2Timer % 2 == 0) //spiral bullet attack
                    {
                        npc.rotation += (float)0.5;
                        Projectile.NewProjectile(npc.Center, new Vector2(12, 0).RotatedBy(npc.rotation), ProjectileType<CannonShot>(), Main.player[npc.target].statLifeMax / 6, 1f);
                    }
                    if (Phase2Timer >= 300)
                    {
                        BulletsOrDash = true;
                        Phase2Timer = 0;
                    }
                }
            }
            if (npc.life < (npc.lifeMax / 3))
            {

            }
        }
    }
}
