using Terraria.ModLoader;

namespace AuthenticDeathclaws
{
	public class AuthenticDeathclaws : Mod
	{
		public static AuthenticDeathclaws Instance { get; private set; }
		public override void Load()
		{
			MrPlagueRaces.Core.Loadables.LoadableManager.Autoload(this);
		}
		public override void Unload()
		{
			MrPlagueRaces.Common.Races.RaceLoader.Races.Clear();
			MrPlagueRaces.Common.Races.RaceLoader.RacesByLegacyIds.Clear();
			MrPlagueRaces.Common.Races.RaceLoader.RacesByFullNames.Clear();
		}
	}
}