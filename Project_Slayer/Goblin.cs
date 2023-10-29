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
		/// The Mob's Hit Points (Health, HP).
		/// </summary>
		public int HitPoints {
			get { return base.Durability; }
			set {
				if (value > 0) {
					base.Durability = value;
				} else {
					End(true);
				}
			}
		}
		#endregion

		#region Information & Initiator

		/// <summary>
		/// Initializes new instance of Goblin class.
		/// </summary>
		public Goblin() : base() {
			MobName = "Goblin";
			Random rng = new Random();

			Strength = rng.Next((int)(minStat * 1.2), (int)(maxStat * 1.2));
			Mana = rng.Next((int)(minStat * 0.7), (int)(maxStat * 0.7));
			Durability = rng.Next((int)(minStat * 6), (int)(maxStat * 6));
			Agility = rng.Next((int)(minStat * 1.3), (int)(maxStat * 1.3));

			CoinDrop = rng.Next(minDropStat, maxDropStat);
			ExpDrop = rng.Next(minDropStat, maxDropStat);
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