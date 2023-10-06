using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	public abstract class Entity {
		protected string mobName;

		protected int strength;
		protected int mana;
		protected int durability;
		protected int agility;

		public Entity(string initialMobName, int initialStrength, int initialMana, int initialDurability, int initialAgility) {

		}
	}
}
