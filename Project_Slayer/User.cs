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
				durability = rng.Next((int)(minStat*10), (int)(maxStat*10));
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

		#region Floor - Enemies - Combat
		private int enemyCount;
		private int dodgeCount;

		#region Floor

		/// <summary>
		/// The User's current floor-level. 0 to 5.
		/// </summary>
		[JsonPropertyName("FloorLevel")]
		public int FloorLevel {
			get { return EnemyCount / 10; }
			set {
				if (EnemyCount % 10 == 0 && EnemyCount > 0) {
					FloorLevel++;
					FloorChange(FloorLevel);
				}
			}
		}

		/// <summary>
		/// Method responsible of changing floors.
		/// </summary>
		/// <param name="floorLevel"></param>
		public void FloorChange(int floorLevel) {

		}

		#endregion

		#region Enemies

		/// <summary>
		/// The number of enemy slain increases by 1.
		/// </summary>
		public void EnemySlain() {
			enemyCount++;
		}
		/// <summary>
		/// The number of User's slain enemies.
		/// </summary>
		[JsonPropertyName("EnemyCount")]
		public int EnemyCount {
			get { return enemyCount; }
			set {
				enemyCount = value;
			}
		}

		#endregion

		#region Combat

		/// <summary>
		/// The number of times the user has dodged.
		/// </summary>
		[JsonPropertyName("DodgeCount")]
		public int DodgeCount {
			get { return dodgeCount; }
			set { }
		}

		#endregion

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of the User. 
		/// Entity, Strength, Mana, Durability, Agility.
		/// Additional info: UserName, EnemyCount, FloorLevel.
		/// </summary>
		public override void DisplayInfo() {
			Console.WriteLine($"Username: {UserName}");
			base.DisplayInfo();
			Console.WriteLine($"EnemyCount: {EnemyCount}");
			Console.WriteLine($"FloorLevel: {FloorLevel}");
			Console.WriteLine($"DodgeCount: {DodgeCount}");
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

			EnemyCount = 0;
			FloorLevel = 0;
			DodgeCount = 0;
		}
		/// <summary>
		/// Initializes new instance of User class.
		/// </summary>
		/// <param name="initialUserName"></param>
		[JsonConstructor]
		public User(string userName, int strength, int mana, int durability, int agility, int enemyCount, int floorLevel, int dodgeCount) {
			this.UserName = userName;
			this.Strength = strength;
			this.Mana = mana;
			this.Durability = durability;
			this.Agility = agility;

			this.EnemyCount = enemyCount;
			this.FloorLevel = floorLevel;
			this.DodgeCount = dodgeCount;
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
			dodgeCount++;
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
