using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Slayer {

	//██╗██╗████████╗██╗░░██╗███████╗░██████╗███████╗  ██████╗░░█████╗░██╗░░░░░██╗░░░░░░██████╗  ░█████╗░██████╗░███████╗  ███╗░░░███╗░█████╗░██████╗░███████╗  ███████╗░█████╗░██████╗░  ██╗░░░██╗░█████╗░██╗░░░██╗██╗██╗  
	//╚█║╚█║╚══██╔══╝██║░░██║██╔════╝██╔════╝██╔════╝  ██╔══██╗██╔══██╗██║░░░░░██║░░░░░██╔════╝  ██╔══██╗██╔══██╗██╔════╝  ████╗░████║██╔══██╗██╔══██╗██╔════╝  ██╔════╝██╔══██╗██╔══██╗  ╚██╗░██╔╝██╔══██╗██║░░░██║╚█║╚█║  
	//░╚╝░╚╝░░░██║░░░███████║█████╗░░╚█████╗░█████╗░░  ██████╦╝███████║██║░░░░░██║░░░░░╚█████╗░  ███████║██████╔╝█████╗░░  ██╔████╔██║███████║██║░░██║█████╗░░  █████╗░░██║░░██║██████╔╝  ░╚████╔╝░██║░░██║██║░░░██║░╚╝░╚╝  
	//░░░░░░░░░██║░░░██╔══██║██╔══╝░░░╚═══██╗██╔══╝░░  ██╔══██╗██╔══██║██║░░░░░██║░░░░░░╚═══██╗  ██╔══██║██╔══██╗██╔══╝░░  ██║╚██╔╝██║██╔══██║██║░░██║██╔══╝░░  ██╔══╝░░██║░░██║██╔══██╗  ░░╚██╔╝░░██║░░██║██║░░░██║░░░░░░  
	//░░░░░░░░░██║░░░██║░░██║███████╗██████╔╝███████╗  ██████╦╝██║░░██║███████╗███████╗██████╔╝  ██║░░██║██║░░██║███████╗  ██║░╚═╝░██║██║░░██║██████╔╝███████╗  ██║░░░░░╚█████╔╝██║░░██║  ░░░██║░░░╚█████╔╝╚██████╔╝░░░░░░  
	//░░░░░░░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═════╝░╚══════╝  ╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═════╝░╚══════╝  ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝  ░░░╚═╝░░░░╚════╝░░╚═════╝░░░░░░░  


	//░░░░░░  ███████╗███████╗███╗░░██╗██╗░░░██╗░█████╗░████████╗████████╗░█████╗░
	//░░░░░░  ╚════██║██╔════╝████╗░██║╚██╗░██╔╝██╔══██╗╚══██╔══╝╚══██╔══╝██╔══██╗
	//█████╗  ░░███╔═╝█████╗░░██╔██╗██║░╚████╔╝░███████║░░░██║░░░░░░██║░░░███████║
	//╚════╝  ██╔══╝░░██╔══╝░░██║╚████║░░╚██╔╝░░██╔══██║░░░██║░░░░░░██║░░░██╔══██║
	//░░░░░░  ███████╗███████╗██║░╚███║░░░██║░░░██║░░██║░░░██║░░░░░░██║░░░██║░░██║
	//░░░░░░  ╚══════╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚═╝░░╚═╝░░░╚═╝░░░░░░╚═╝░░░╚═╝░░╚═╝



	/// <summary>
	/// Represents the base data for User.
	/// </summary>
	public class User : Entity {

		/// <summary>
		/// The User's name.
		/// </summary>
		public string UserName { 
			get { return mobName; }
			set {
				mobName = value;
			}
		}

		/// <summary>
		/// The User's strength stat (Physical Attack Power).
		/// </summary>
		public int Strength {
			get { return strength; }
			set {
				strength = rng.Next(minStat, maxStat);
			}
		}
		
		/// <summary>
		/// The User's mana stat (Magical Attack Power).
		/// </summary>
		public int Mana {
			get { return mana; }
			set {
				mana = rng.Next(minStat, maxStat);
			}
		}
		
		/// <summary>
		/// The User's durability stat (Health Points).
		/// </summary>
		public int Durability {
			get { return durability; }
			set {
				durability = rng.Next(minStat, maxStat);
			}
		}
		
		/// <summary>
		/// The User's agility stat.
		/// </summary>
		public int Agility {
			get { return agility; }
			set {
				agility = rng.Next(minStat, maxStat);
			}
		}

		/// <summary>
		/// Initializes new instance of User class.
		/// </summary>
		/// <param name="initialUserName"></param>
		/// <param name="initialStrength"></param>
		/// <param name="initialMana"></param>
		/// <param name="initialDurability"></param>
		/// <param name="initialAgility"></param>
		public User(string initialUserName, int initialStrength, int initialMana, int initialDurability, int initialAgility) 
			: base(initialUserName, initialStrength, initialMana, initialDurability, initialAgility) {
			UserName = initialUserName;
			Strength = initialStrength;
			Mana = initialMana;
			Durability = initialDurability;
			Agility = initialAgility;
		}
		/// <summary>
		/// Displays the information of the User. 
		/// Entity, Strength, Mana, Durability, Agility.
		/// Additional info: UserName.
		/// </summary>
		public override void DisplayInfo() {
			Console.WriteLine($"UserName: {mobName}");
			base.DisplayInfo();
		}
	}
}
