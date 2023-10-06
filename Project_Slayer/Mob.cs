﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	/// <summary>
	/// Represents the base data for any Mob.
	/// </summary>
	public class Mob : Entity {
		//Additional mob stats, not included in user.
		protected int coinDrop;
		protected int expDrop;

		/// <summary>
		/// Initializes new instance of Mob class.
		/// </summary>
		/// <param name="initialMobName"></param>
		/// <param name="initialCoinDrop"></param>
		/// <param name="initialExpDrop"></param>
		/// <param name="initialStrength"></param>
		/// <param name="initialMana"></param>
		/// <param name="initialDurability"></param>
		/// <param name="initialAgility"></param>
		public Mob(string initialMobName, int initialCoinDrop, int initialExpDrop, int initialStrength, int initialMana, int initialDurability, int initialAgility) 
			: base(initialMobName, initialStrength, initialMana, initialDurability, initialAgility) {

		}
	}
}
