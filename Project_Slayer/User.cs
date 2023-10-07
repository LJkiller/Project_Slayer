using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;

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

		#region User Attributes

		/// <summary>
		/// The User's name.
		/// </summary>
		[JsonPropertyName("UserName")]
		public string UserName { 
			get { return mobName; }
			set {
				mobName = value;
			}
		}

		/// <summary>
		/// The User's strength stat (Physical Attack Power).
		/// </summary>
		[JsonPropertyName("Strength")]
		public int Strength {
			get { return strength; }
			set {
				strength = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The User's mana stat (Magical Attack Power).
		/// </summary>
		[JsonPropertyName("Mana")]
		public int Mana {
			get { return mana; }
			set {
				mana = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The User's durability stat (Health Points).
		/// </summary>
		[JsonPropertyName("Durability")]
		public int Durability {
			get { return durability; }
			set {
				durability = rng.Next(minStat, maxStat);
			}
		}
		/// <summary>
		/// The User's agility stat.
		/// </summary>
		[JsonPropertyName("Agility")]
		public int Agility {
			get { return agility; }
			set {
				agility = rng.Next(minStat, maxStat);
			}
		}

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of the User. 
		/// Entity, Strength, Mana, Durability, Agility.
		/// Additional info: UserName.
		/// </summary>
		public override void DisplayInfo() {
			Console.WriteLine($"Username: {mobName}");
			base.DisplayInfo();
		}
		/// <summary>
		/// Default attribute holder.
		/// </summary>
		private void SetDefaultAttributes() {
			UserName = "DefaultEntity";
			Strength = 0;
			Mana = 0;
			Durability = 0;
			Agility = 0;
		}
		/// <summary>
		/// Initializes new instance of User class.
		/// </summary>
		/// <param name="initialUserName"></param>
		[JsonConstructor]
		public User(string UserName, int Strength, int Mana, int Durability, int Agility) {
			this.UserName = UserName;
			this.Strength = Strength;
			this.Mana = Mana;
			this.Durability = Durability;
			this.Agility = Agility;
		}


		#endregion

		#region Methods

		/// <summary>
		/// Attacks opponent and inflicts damage. 
		/// Damage is scaled by Strength or Mana.
		/// </summary>
		/// <param name="attackType"></param>
		public override void Attack(string attackType = "physical") {
			Console.WriteLine($"Whazaa, a {attackType} attack!");
		}
		/// <summary>
		/// Perfectly dodges your opponent's incoming attack.
		/// </summary>
		public void Dodge() {
			Console.WriteLine("You're fast enough to outmaneuver your enemy!");
		}
		/// <summary>
		/// Escapes from the current opponent, resores your health to 100%.
		/// </summary>
		public void Escape() {
			Console.WriteLine("You've escaped!");
		}

		#endregion

	}
}
