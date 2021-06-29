using Terraria.ID;
using Terraria.ModLoader;

namespace AuthenticDeathclaws.Items.Tools
{
	public class HellfireClaws : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("HellfireClaws"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Scraped through the molten slag of hell, then sharpened on a legendary hammer!");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.melee = true;
			item.width = 25;
			item.height = 25;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 150000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 100;
			item.axe = 17;
			item.hammer = 80;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "NukeClaws");
			recipe.AddIngredient(ItemID.Pwnhammer, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}