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
		//To initialize an emptyUser to access methods.
		User emptyUser = new User("");
		#endregion

		#region Race Attributes

		/// <summary>
		/// The Mob's race-name (Name).
		/// </summary>
		public string MobName {
			get { return mobName; }
			set {
				mobName = "Goblin Lord";
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
			get { return strength; }
			set {
				strength = rng.Next((int)(minStat * 1.2*2), (int)(maxStat * 1.2*2));
			}
		}
		/// <summary>
		/// The Mob's mana stat (Magical Attack Power).
		/// </summary>
		public double Mana {
			get { return mana; }
			set {
				mana = rng.Next((int)(minStat * 0.7*1.5), (int)(maxStat * 0.7*1.5));
			}
		}
		/// <summary>
		/// The Mob's durability stat (Maximum Hit Points).
		/// </summary>
		public double Durability {
			get { return durability; }
			set {
				durability = rng.Next((int)(minStat * 6*3), (int)(maxStat * 6*3));
			}
		}
		/// <summary>
		/// The Mob's agiity stat.
		/// </summary>
		public double Agility {
			get { return agility; }
			set {
				agility = rng.Next((int)(minStat * 1.3*1.5), (int)(maxStat * 1.3*1.5));
			}
		}

		/// <summary>
		/// The Mob's Hit Points (Health, HP).
		/// </summary>
		public int HitPoints {
			get { return durability; }
			set {
				if (value > 0) {
					durability = value;
				} else {
					Death();
				}
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
		/// Attacks opponent and inflicts damage. 
		/// Damage is scaled by Strength or Mana.
		/// </summary>
		/// <param name="attackType"></param>
		public override void Attack(string attackType = "physical") {
			Console.WriteLine($"{MobName} has attacked!\nInflicted {Strength} damage!");
		}

		/// <summary>
		/// Method responsible of GoblinLord's death.
		/// </summary>
		public override void Death() {
			base.Death();
			emptyUser.Exp += (int)Math.Round(ExpDrop);
			emptyUser.Coins += (int)Math.Round(CoinDrop);
		}

		#endregion

	}
}
