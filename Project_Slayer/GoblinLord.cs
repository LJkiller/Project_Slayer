using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {

	/// <summary>
	/// Represents base data for GoblinLord Class.
	/// </summary>
	public class GoblinLord : Boss {

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
				base.mobName = "Goblin Lord";
			}
		}

		/// <summary>
		/// The Mob's coin drop value.
		/// </summary>
		public double CoinDrop {
			get { return coinDrop; }
			set {
				coinDrop = rng.Next((int)(minDropStat * 1.5*3), (int)(maxDropStat * 1.5*3));
			}
		}
		/// <summary>
		/// The Mob's exp drop value.
		/// </summary>
		public double ExpDrop {
			get { return expDrop; }
			set {
				expDrop = rng.Next((int)(minDropStat * 0.7*3), (int)(maxDropStat * 0.7*3));
			}
		}

		/// <summary>
		/// The Mob's strength stat (Physical Attack Power).
		/// </summary>
		public double Strength {
			get { return base.strength; }
			set {
				base.strength = rng.Next((int)(minStat * 1.2*2), (int)(maxStat * 1.2*2));
			}
		}
		/// <summary>
		/// The Mob's mana stat (Magical Attack Power).
		/// </summary>
		public double Mana {
			get { return base.mana; }
			set {
				base.mana = rng.Next((int)(minStat * 0.7*1.5), (int)(maxStat * 0.7*1.5));
			}
		}
		/// <summary>
		/// The Mob's durability stat (Maximum Hit Points).
		/// </summary>
		public double Durability {
			get { return base.durability; }
			set {
				base.durability = rng.Next((int)(minStat * 7*3), (int)(maxStat * 7*3));
			}
		}
		/// <summary>
		/// The Mob's agiity stat.
		/// </summary>
		public double Agility {
			get { return base.agility; }
			set {
				base.agility = rng.Next((int)(minStat * 1.3*1.5), (int)(maxStat * 1.3*1.5));
			}
		}

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Default attribute holder.
		/// </summary>
		private void SetDefaultAttributes() {
			MobName = "DefaultGoblinLord";
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
		public GoblinLord() : base() {
			SetDefaultAttributes();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Method responsible of GoblinLord's death.
		/// </summary>
		/// <param name="isDead">Bool to compare if GoblinLord has died.</param>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="fileManager">The FileManager object to be transfering information.</param>
		public override void End(bool isDead, User user = null, FileManager fileManager = null) {
			base.End(isDead);
			if (isDead) {
				int experienceGained = (int)Math.Round(GetExpDrop());
				int coinsGained = (int)Math.Round(GetCoinDrop());
				emptyUser.Exp += experienceGained;
				emptyUser.Coins += coinsGained;
			}
		}

		#endregion

	}
}