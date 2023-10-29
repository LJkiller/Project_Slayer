using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {

	/// <summary>
	/// Represents base data for Goblin Class.
	/// </summary>
	class Goblin : Mob {

		#region SetUp
		//To initialize different classes to access methods.
		User emptyUser = new User("");
		#endregion

		#region Race Attributes

		/// <summary>
		/// The Mob's race-name (Name).
		/// </summary>
		public string MobName {
			get { return base.mobName; }
			set {
				base.mobName = "Goblin";
			}
		}

		/// <summary>
		/// The Mob's coin drop value.
		/// </summary>
		public double CoinDrop {
			get { return coinDrop; }
			set {
				coinDrop = rng.Next((int)(minDropStat*1.5), (int)(maxDropStat*1.5));
			}
		}
		/// <summary>
		/// The Mob's exp drop value.
		/// </summary>
		public double ExpDrop {
			get { return expDrop; }
			set {
				expDrop = rng.Next((int)(minDropStat*0.7), (int)(maxDropStat*0.7));
			}
		}

		/// <summary>
		/// The Mob's strength stat (Physical Attack Power).
		/// </summary>
		public double Strength {
			get { return base.strength; }
			set {
				base.strength = rng.Next((int)(minStat * 1.2), (int)(maxStat * 1.2));
			}
		}
		/// <summary>
		/// The Mob's mana stat (Magical Attack Power).
		/// </summary>
		public double Mana {
			get { return base.mana; }
			set {
				base.mana = rng.Next((int)(minStat * 0.7), (int)(maxStat * 0.7));
			}
		}
		/// <summary>
		/// The Mob's durability stat (Maximum Hit Points).
		/// </summary>
		public double Durability {
			get { return base.durability; }
			set {
				base.durability = rng.Next((int)(minStat * 6), (int)(maxStat * 6));
			}
		}
		/// <summary>
		/// The Mob's agiity stat.
		/// </summary>
		public double Agility {
			get { return base.agility; }
			set {
				base.agility = rng.Next((int)(minStat * 1.3), (int)(maxStat * 1.3));
			}
		}

		/// <summary>
		/// The Mob's Hit Points (Health, HP).
		/// </summary>
		public int HitPoints {
			get { return base.durability; }
			set {
				if (value > 0) {
					base.durability = value;
				} else {
					End(true);
				}
			}
		}
		#endregion

		#region Information & Initiator

		/// <summary>
		/// Default attribute holder.
		/// </summary>
		private void SetDefaultAttributes() {
			MobName = "DefaultGoblin";
			CoinDrop = 0;
			ExpDrop = 0;
			Strength = 0;
			Mana = 0;
			Durability = 0;
			Agility = 0;
		}
		/// <summary>
		/// Initializes new instance of Goblin class.
		/// </summary>
		public Goblin() : base() {
			SetDefaultAttributes();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Method responsible of Goblin's death.
		/// </summary>
		public override void End(bool dead = false, User user = null) {
			base.End(dead, user);
			emptyUser.Exp += (int)Math.Round(ExpDrop);
			emptyUser.Coins += (int)Math.Round(CoinDrop);
		}
		#endregion

	}
}