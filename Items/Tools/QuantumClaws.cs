using Terraria.ID;
using Terraria.ModLoader;

namespace AuthenticDeathclaws.Items.Tools
{
	public class QuantumClaws : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("QuantumClaws"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("These absurd mutations are getting out of ha- uhh, in your hand.");
		}

		public override void SetDefaults() 
		{
			item.damage = 36;
			item.melee = true;
			item.width = 25;
			item.height = 25;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 600000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.pick = 200;
			item.axe = 25;
			item.hammer = 120;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "HellfireClaws");
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ItemID.SpectreBar, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}