using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	public class Mob : Entity {
		protected int coinDrop;
		protected int expDrop;

		public Mob(string initialMobName, int initialCoinDrop, int initialExpDrop, int initialStrength, int initialMana, int initialDurability, int initialAgility) 
			: base(initialMobName, initialStrength, initialMana, initialDurability, initialAgility) {

		}
	}
}
