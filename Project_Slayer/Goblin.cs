﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {

	/// <summary>
	/// Represents base data for Goblin Class.
	/// </summary>
	class Goblin : Mob {

		#region Race Attributes

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
			get { return strength; }
			set {
				strength = rng.Next((int)(minStat*1.2), (int)(maxStat*1.2));
			}
		}
		/// <summary>
		/// The Mob's mana stat (Magical Attack Power).
		/// </summary>
		public double Mana {
			get { return mana; }
			set {
				mana = rng.Next((int)(minStat*0.7), (int)(maxStat*0.7));
			}
		}
		/// <summary>
		/// The Mob's durability stat (Health Points).
		/// </summary>
		public double Durability {
			get { return durability; }
			set {
				durability = rng.Next((int)(minStat*6), (int)(maxStat*6));
			}
		}
		/// <summary>
		/// The Mob's agiity stat.
		/// </summary>
		public double Agility {
			get { return agility; }
			set {
				agility = rng.Next((int)(minStat*1.3), (int)(maxStat*1.3));
			}
		}
		//(int)(minStat), (int)(maxStat)
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
		/// Attacks opponent and inflicts damage. 
		/// Damage is scaled by Strength or Mana.
		/// </summary>
		/// <param name="attackType"></param>
		public override void Attack(string attackType = "physical") {
			Console.WriteLine($"{MobName} has attacked!\nInflicted {Strength} damage!");
		}

		#endregion

	}
}
