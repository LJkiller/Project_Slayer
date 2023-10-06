using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	public class User : Entity {
		public string UserName { 
			get { return mobName; }
			set {

			}
		}

		public int Strength {
			get { return strength; }
			set {

			}
		}
		public int Mana {
			get { return mana; }
			set {

			}
		}
		public int Durability {
			get { return durability; }
			set {

			}
		}
		public int Agility {
			get { return agility; }
			set {

			}
		}

		public User(string initialUserName, int initialStrength, int initialMana, int initialDurability, int initialAgility) 
			: base(initialUserName, initialStrength, initialMana, initialDurability, initialAgility){

		}
	}
}
