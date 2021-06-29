using Terraria.ID;
using Terraria.ModLoader;

namespace AuthenticDeathclaws.Items.Tools
{
	public class DeathClaws : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("DeathClaws"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("They're about to catch these hands!");
		}

		public override void SetDefaults() 
		{
			item.damage = 5;
			item.melee = true;
			item.width = 25;
			item.height = 25;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 500;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 35;
			item.axe = 6;
		}
	}
}