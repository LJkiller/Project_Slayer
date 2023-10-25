using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
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
	/// Represents the base data for User Class.
	/// </summary>
	public class User : Entity {

		#region User Attributes
		private int coins;
		private int exp;

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
				strength = value;
			}
		}
		
		/// <summary>
		/// The User's mana stat (Magical Attack Power).
		/// </summary>
		[JsonPropertyName("Mana")]
		public int Mana {
			get { return mana; }
			set {
				mana = value;
			}
		}
		
		/// <summary>
		/// The User's durability stat (Health Points).
		/// </summary>
		[JsonPropertyName("Durability")]
		public int Durability {
			get { return durability; }
			set {
				durability = value;
			}
		}
		
		/// <summary>
		/// The User's agility stat.
		/// </summary>
		[JsonPropertyName("Agility")]
		public int Agility {
			get { return agility; }
			set {
				agility = value;
			}
		}



		/// <summary>
		/// The User's amount of coins.
		/// </summary>
		[JsonPropertyName("Coins")]
		public int Coins {
			get { return coins; }
			set {
				coins = value;
			}
		}

		/// <summary>
		/// The User's amount of exp.
		/// </summary>
		[JsonPropertyName("Exp")]
		public int Exp {
			get { return exp; }
			set {
				exp = value;
			}
		}

		#endregion

		#region Floor - Enemies - Combat
		private int enemyCount;
		private int dodgeCount;
		private int bossCount;

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
		/// The number of enemy slain, increases by 1.
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

		/// <summary>
		/// The number of bosses slain, increases by 1.
		/// </summary>
		public void BossSlain() {
			bossCount++;
		}
		/// <summary>
		/// The number of User's slain bosses.
		/// </summary>
		[JsonPropertyName("BossCount")]
		public int BossCount {
			get { return bossCount; }
			set {
				bossCount = value;
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
			Console.WriteLine($"{UserName,21}: Username");
			base.DisplayInfo();
			Console.WriteLine($"{Coins,21}: Coins");
			Console.WriteLine($"{Exp,21}: Exp");
			Console.WriteLine($"{EnemyCount,21}: EnemyCount\n");

			/* Information that should not be displayed.
			Console.WriteLine($"{BossCount,21}: BossCount");
			Console.WriteLine($"{FloorLevel,21}: FloorLevel");
			Console.WriteLine($"{DodgeCount,21}: DodgeCount\n");
			*/
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
			Coins = 0;
			Exp = 0;

			EnemyCount = 0;
			BossCount = 0;
			FloorLevel = 0;
			DodgeCount = 0;
		}
		
		/// <summary>
		/// Initializes new instance of User class.
		/// </summary>
		/// <param name="initialUserName"></param>
		[JsonConstructor]
		public User(string userName) {
			this.UserName = userName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Creates the user and saves the data into a json-file.
		/// </summary>
		/// <param name="usernameInput"></param>
		/// <param name="fileNameInput"></param>
		/// <param name="User"></param>
		public void CreateUser(string usernameInput, string fileNameInput, User User) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				User.strength = rng.Next(minStat, maxStat);
				User.mana = rng.Next(minStat, maxStat);
				User.durability = rng.Next((int)(minStat * 10), (int)(maxStat * 10));
				User.agility = rng.Next(minStat, maxStat);

				string serialized = JsonSerializer.Serialize(User);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				File.WriteAllText(backupFileName, serialized);

				Console.WriteLine("User data saved successfully.\nUser created successfully.");
				Console.WriteLine($"Your data:\n");
				User.DisplayInfo();
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		/// <summary>
		/// Get User info (load user) from Json-file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public User GetUserInfo(string fileNameInput) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				if (File.Exists(backupFileName)) {
					if (File.Exists(fileName)) {
						Console.WriteLine("\nFile found!");
						string serializedFromFile = File.ReadAllText(fileName);
						return JsonSerializer.Deserialize<User>(serializedFromFile);
					} else {
						Console.WriteLine("\nFile found!");
						string serializedBackupFromFile = File.ReadAllText(fileName);
						return JsonSerializer.Deserialize<User>(serializedBackupFromFile);
					}					
				} else {
					Console.WriteLine($"File not found! Cannot load user.");
					return null;
				}
			} catch (Exception e) {
				Console.WriteLine($"An error occurred while loading user data: {e.Message}");
				return null;
			}
		}

		/// <summary>
		/// Method resonsible of checking a user's stats.
		/// </summary>
		/// <param name="user"></param>
		public void CheckUserInfo(User user, string input) {

			try {
				if (user != null) {
					Console.WriteLine($"{user.UserName,21}: UserName");
					Console.WriteLine($"{user.Strength,21}: Strength");
					Console.WriteLine($"{user.Mana,21}: Mana");
					Console.WriteLine($"{user.Durability,21}: Durability");
					Console.WriteLine($"{user.Agility,21}: Agility");
					Console.WriteLine($"{user.Coins,21}: Coins");
					Console.WriteLine($"{user.Exp,21}: Exp");
					Console.WriteLine($"{user.FloorLevel,21}: FloorLevel\n");

					if (input == "cmds-check") {
						Console.WriteLine($"{user.EnemyCount,21}: EnemyCount");
						Console.WriteLine($"{user.EnemyCount,21}: BossCount");
						Console.WriteLine($"{user.DodgeCount,21}: DodgeCount\n");
					}

				} else {
					Console.WriteLine("The user object is not initialized.");
				}
			} catch (ArgumentException e) {
				Console.WriteLine($"Something went wrong! {e.Message}");
			}
		}

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
