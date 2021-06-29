using Terraria.ID;
using Terraria.ModLoader;

namespace AuthenticDeathclaws.Items.Tools
{
	public class LunarClaws : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("LunarClaws"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("To kill a god with your bare hands, is surely to be the envy of the world.");
		}

		public override void SetDefaults() 
		{
			item.damage = 72;
			item.melee = true;
			item.width = 25;
			item.height = 25;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1200000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 225;
			item.axe = 35;
			item.hammer = 150;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "QuantumClaws");
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}