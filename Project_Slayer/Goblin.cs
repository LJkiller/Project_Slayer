using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	class Goblin : Mob {
		/// <summary>
		/// The Mob's race-name (Name).
		/// </summary>
		public string MobName {
			get { return mobName; }
			set {
				mobName = "Goblin";
			}
		}

		/// <summary>
		/// The Mob's coin drop value.
		/// </summary>
		public int CoinDrop {
			get { return coinDrop; }
			set {
				coinDrop = rng.Next(minDropStat, maxDropStat);
			}
		}
		/// <summary>
		/// The Mob's exp drop value.
		/// </summary>
		public int ExpDrop {
			get { return expDrop; }
			set {
				expDrop = rng.Next(minDropStat, maxDropStat);
			}
		}

		/// <summary>
		/// The Mob's strength stat (Physical Attack Power).
		/// </summary>
		public int Strength {
			get { return strength; }
			set {
				strength = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The Mob's mana stat (Magical Attack Power).
		/// </summary>
		public int Mana {
			get { return mana; }
			set {
				mana = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The Mob's durability stat (Health Points).
		/// </summary>
		public int Durability {
			get { return durability; }
			set {
				durability = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The Mob's agiity stat.
		/// </summary>
		public int Agility {
			get { return agility; }
			set {
				agility = rng.Next(minStat, maxStat);
			}
		}

		public Goblin(string initialMobName, int initialCoinDrop, int initialExpDrop, int initialStrength, int initialMana, int initialDurability, int initialAgility)
			: base(initialMobName, initialCoinDrop, initialExpDrop, initialStrength, initialMana, initialDurability, initialAgility) {
			MobName = initialMobName;
			CoinDrop = initialCoinDrop;
			ExpDrop = initialExpDrop;
			Strength = initialStrength;
			Mana = initialMana;
			Durability = initialDurability;
			Agility = initialAgility;
		}
	}
}
