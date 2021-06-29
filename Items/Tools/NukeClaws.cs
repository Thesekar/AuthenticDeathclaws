using Terraria.ID;
using Terraria.ModLoader;

namespace AuthenticDeathclaws.Items.Tools
{
	public class NukeClaws : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("NukeClaws"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Mutated by the destructive power of meteorites & evil!");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 25;
			item.height = 25;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 6000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 60;
			item.axe = 10;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DeathClaws");
			recipe.AddIngredient(ItemID.ShadowScale, 4);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DeathClaws");
			recipe.AddIngredient(ItemID.TissueSample, 4);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}