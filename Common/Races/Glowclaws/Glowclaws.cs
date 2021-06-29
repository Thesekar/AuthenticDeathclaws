using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;
using Redemption.Buffs;

namespace AuthenticDeathclaws.Common.Races.Glowclaws
{
	public class Glowclaws : Race
	{
        //display name, used to override the race's displayed name. By default, a race will use its class name
        public override string RaceDisplayName => "Glowing Deathclaw";
        //decides if the race has a custom hurt sound (prevents default hurt sound from playing)
        public override bool UsesCustomHurtSound => true;
        //decides if the race has a custom death sound (prevents default death sound from playing)
        public override bool UsesCustomDeathSound => true;
		//decides if the race has a custom female hurt sound (by default, the race will play the male/default hurt sound for both genders)
        public override bool HasFemaleHurtSound => true;

        //textures for the race's display background in the UI
		public override string RaceEnvironmentIcon => ($"MrPlagueRaces/Common/UI/RaceDisplay/Environment/Environment_Mushroom");

		//information for the race's textures and lore in the UI
		public override string RaceSelectIcon => ($"AuthenticDeathclaws/Common/UI/RaceDisplay/GlowclawSelect");
		public override string RaceDisplayMaleIcon => ($"AuthenticDeathclaws/Common/UI/RaceDisplay/GlowclawDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"AuthenticDeathclaws/Common/UI/RaceDisplay/GlowclawDisplayFemale");
		public override string RaceLore1 => "Mutated from" + "\ntheir Deathclaw" + "\nsiblings, now" + "\nthey truly shine.";
        public override string RaceLore2 => "What was only immunity" + "\nto radiation has now turned" + "\ninto a gift of brilliance.";
		//"\n" is normally used to move to the next line, but it conflicts with colored text so I split the ability and additional notes into several lines
		public override string RaceAbilityName => "Natural Glow";
		public override string RaceAbilityDescription1 => "You passively glow as your body processes radiation differently than normal Deathclaws";
		public override string RaceAbilityDescription2 => "";
		public override string RaceAbilityDescription3 => "";
		public override string RaceAbilityDescription4 => "";
		public override string RaceAbilityDescription5 => "";
        public override string RaceAbilityDescription6 => "";
		public override string RaceAdditionalNotesDescription1 => "☢ You start the game able to use your claws for combat & digging";
		public override string RaceAdditionalNotesDescription2 => "☢ If you are playing with Mod of Redemption, you're immune to radiation";
		public override string RaceAdditionalNotesDescription3 => "☢ Deathclaws are dangerous, but so is the world, so expect a tougher experience";
		public override string RaceAdditionalNotesDescription4 => "";
		public override string RaceAdditionalNotesDescription5 => "";
        public override string RaceAdditionalNotesDescription6 => "";

		//makes the race's display background in the UI appear darker, can be used to make it look like it is night
		public override bool DarkenEnvironment => false;

		//stat info for the UI's stat display. 34EB93 is the green text, FF4F64 is the red text
		public override string RaceHealthDisplayText => "";
		public override string RaceRegenerationDisplayText => "";
		public override string RaceManaDisplayText => "[c/34EB93:+25%]";
		public override string RaceManaRegenerationDisplayText => "";
		public override string RaceDefenseDisplayText => "[c/34EB93:+4]";
		public override string RaceDamageReductionDisplayText => "";
		public override string RaceThornsDisplayText => "[c/34EB93:+10%]";
		public override string RaceLavaResistanceDisplayText => "";
        public override string RaceMeleeDamageDisplayText => "";
		public override string RaceRangedDamageDisplayText => "[c/FF4F64:-20%]";
		public override string RaceMagicDamageDisplayText => "";
		public override string RaceSummonDamageDisplayText => "";
		public override string RaceMeleeSpeedDisplayText => "[c/34EB93:+5%]";
		public override string RaceArmorPenetrationDisplayText => "";
		public override string RaceBulletDamageDisplayText => "";
		public override string RaceRocketDamageDisplayText => "";
		public override string RaceManaCostDisplayText => "[c/FF4F64:+10%]";
		public override string RaceMinionKnockbackDisplayText => "";
		public override string RaceMinionsDisplayText => "";
		public override string RaceSentriesDisplayText => "";
		public override string RaceMeleeCritChanceDisplayText => "";
		public override string RaceRangedCritChanceDisplayText => "";
		public override string RaceMagicCritChanceDisplayText => "";
		public override string RaceMiningSpeedDisplayText => "";
		public override string RaceBuildingSpeedDisplayText => "";
		public override string RaceBuildingWallSpeedDisplayText => "";
        public override string RaceBuildingRangeDisplayText => "";
		public override string RaceArrowDamageDisplayText => "";
		public override string RaceMovementSpeedDisplayText => "[c/34EB93:+5%]";
		public override string RaceJumpSpeedDisplayText => "[c/FF4F64:-33%]";
		public override string RaceFallDamageResistanceDisplayText => "";
		public override string RaceAllDamageDisplayText => "[c/34EB93:+10%]";
		public override string RaceFishingSkillDisplayText => "";
		public override string RaceAggroDisplayText => "[c/FF4F64:+250]";
		public override string RaceRunSpeedDisplayText => "[c/34EB93:+5%]";
        public override string RaceRunAccelerationDisplayText => "[c/34EB93:+5%]";

		//race environment info (CURRENTLY COSMETIC)
		public override string RaceGoodBiomesDisplayText => "Wasteland";
		public override string RaceBadBiomesDisplayText => "Tundra";

		//custom hurt sounds would normally be put in PreHurt, but they conflict with Godmode in other mods so I made a custom system to avoid the confliction
		public override bool PreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			return true;
		}

        public override bool PreKill(Player player, Mod mod, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			//death sound
			var AuthenticDeathclaws = ModLoader.GetMod("AuthenticDeathclaws");
			Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, AuthenticDeathclaws.GetSoundSlot(SoundType.Custom, "Sounds/Deathclaw_Killed"));
            return true;
        }

		//things that affect the player's stats should be put in ResetEffects
        public override void ResetEffects(Player player)
        {
            //RaceStats is a bool in MrPlagueRaces that decides whether the player's racial changes are enabled or not. Make sure to put gameplay-affecting racial changes in an 'if statement' that detects if RaceStats is true
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            if (modPlayer.RaceStats)
            {
				player.statManaMax2 += (player.statManaMax2 / 4);
                player.statDefense += 4;
                player.thorns += 0.1f;
                player.rangedDamage -= .3f;
                player.meleeSpeed += 1f;
                player.manaCost += 0.1f;
                player.moveSpeed += 0.1f;
                player.jumpSpeedBoost -= 0.33f;
				player.allDamage += 0.1f;
                player.aggro += 250;
                player.maxRunSpeed += 0.1f;
                player.runAcceleration += 0.1f;
				player.AddBuff(BuffID.Shine, 1);
			}
        }

		public override void ProcessTriggers(Player player, Mod mod)
		{
		}

		public override void PreUpdate(Player player, Mod mod)
		{
			//hurt sounds and any additional features of the race (abilities, etc) go here
			//custom hurt sounds would normally be put in PreHurt, but they conflict with Godmode in other mods so I made a custom system to avoid the confliction
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			var _MrPlagueRaces = ModLoader.GetMod("MrPlagueRaces");
			var AuthenticDeathclaws = ModLoader.GetMod("AuthenticDeathclaws");
			if (player.HasBuff(_MrPlagueRaces.BuffType("DetectHurt")) && (player.statLife != player.statLifeMax2))
			{
					Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Dragonkin_Hurt"));
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				if (modPlayer.RaceStats)
				{
					player.buffImmune[ModContent.BuffType<RadioactiveFalloutDebuff>()] = true;

				}
			}
		}

		public override void PostItemCheck(Player player, Mod mod)
		{
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
			if (!modPlayer.GotRaceItems)
			{
				player.QuickSpawnItem(Mod.ItemType("DeathClaws"));
			}
		}
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			//editing spawn rate
			spawnRate *= (int)((double)0.2);
			maxSpawns += (int)((float)1);
		}

		public override void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo)
        {
			//custom race's default color values and clothing styles go here
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Item familiarshirt = new Item();
            familiarshirt.SetDefaults(ItemID.FamiliarShirt);
            Item familiarpants = new Item();
            familiarpants.SetDefaults(ItemID.FamiliarPants);
            if (modPlayer.resetDefaultColors)
            {
				player.skinVariant = 3;
				if (player.armor[1].type < ItemID.IronPickaxe && player.armor[2].type < ItemID.IronPickaxe)
				{
					player.armor[1] = familiarshirt;
					player.armor[2] = familiarpants;
				}
			}
		}

		public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
		{
			//applying the racial textures
			var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();

			bool hideChestplate = modPlayer.hideChestplate;
			bool hideLeggings = modPlayer.hideLeggings;

			Main.playerTextures[0, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[0, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[0, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[0, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
			}
			else
			{
				Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Kobold/Kobold_Shirt_1");
			}
			else
			{
				Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
			}
			else
			{
				Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[0, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[0, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
			}
			else
			{
				Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1_2");
			}
			else
			{
				Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1_2");
			}
			else
			{
				Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[1, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[1, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[1, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
			}
			else
			{
				Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
			}
			else
			{
				Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
			}
			else
			{
				Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[1, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[1, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
			}
			else
			{
				Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2_2");
			}
			else
			{
				Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2_2");
			}
			else
			{
				Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[2, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[2, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[2, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
			}
			else
			{
				Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
			}
			else
			{
				Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
			}
			else
			{
				Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[2, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[2, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
			}
			else
			{
				Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3_2");
			}
			else
			{
				Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3_2");
			}
			else
			{
				Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[3, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[3, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[3, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
			}
			else
			{
				Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
			}
			else
			{
				Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
			}
			else
			{
				Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[3, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[3, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
			}
			else
			{
				Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4_2");
			}
			else
			{
				Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4_2");
			}
			else
			{
				Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[8, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[8, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[8, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
			}
			else
			{
				Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
			}
			else
			{
				Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
			}
			else
			{
				Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[8, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[8, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
			}
			else
			{
				Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9_2");
			}
			else
			{
				Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9_2");
			}
			else
			{
				Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[4, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[4, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[4, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
			}
			else
			{
				Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
			}
			else
			{
				Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
			}
			else
			{
				Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[4, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[4, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
			}
			else
			{
				Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5_2");
			}
			else
			{
				Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5_2");
			}
			else
			{
				Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[5, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[5, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[5, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
			}
			else
			{
				Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
			}
			else
			{
				Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
			}
			else
			{
				Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[5, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[5, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
			}
			else
			{
				Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6_2");
			}
			else
			{
				Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6_2");
			}
			else
			{
				Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[6, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[6, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[6, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
			}
			else
			{
				Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
			}
			else
			{
				Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
			}
			else
			{
				Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[6, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[6, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
			}
			else
			{
				Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7_2");
			}
			else
			{
				Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7_2");
			}
			else
			{
				Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[7, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[7, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[7, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
			}
			else
			{
				Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
			}
			else
			{
				Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
			}
			else
			{
				Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[7, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[7, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
			}
			else
			{
				Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8_2");
			}
			else
			{
				Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8_2");
			}
			else
			{
				Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 0] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Head");
			Main.playerTextures[9, 1] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes_2");
			Main.playerTextures[9, 2] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Eyes");
			Main.playerTextures[9, 3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Dragonkin/Dragonkin_Torso");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
			}
			else
			{
				Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 5] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hands");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
			}
			else
			{
				Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 7] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Arm");

			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
			}
			else
			{
				Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}

			Main.playerTextures[9, 9] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Hand");
			Main.playerTextures[9, 10] = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Legs");

			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
			}
			else
			{
				Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10_2");
			}
			else
			{
				Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10_2");
			}
			else
			{
				Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
			}
			for (int i = 0; i < 51; i++)
			{
				Main.playerHairTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Dragonkin/Hair/Dragonkin_Hair_{i + 1}");
				Main.playerHairAltTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Dragonkin/Hair/Dragonkin_Hair_{i + 1}");
			}
			for (int i = 51; i < 133; i++)
			{
				Main.playerHairTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Blank");
				Main.playerHairAltTexture[i] = ModContent.GetTexture($"MrPlagueRaces/Content/RaceTextures/Blank");
			}
			Main.ghostTexture = ModContent.GetTexture("AuthenticDeathclaws/Content/RaceTextures/Deathclaw/Deathclaw_Ghost");
		}
	}
}