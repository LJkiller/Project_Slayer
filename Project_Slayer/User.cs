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

		#region Setup 
		//To initialize different classes to access methods.
		TextManager textManager = new TextManager();
		FileManager fileManager = new FileManager();
		#endregion

		#region User Attributes

		/// <summary>
		/// The User's name.
		/// </summary>
		[JsonPropertyName("UserName")]
		public string UserName { get; set; }


		/// <summary>
		/// The User's Hit Points (Health, HP).
		/// </summary>
		[JsonPropertyName("HP")]
		public int HitPoints { get; set; }

		/// <summary>
		/// The User's strength stat (Physical Attack Power).
		/// </summary>
		[JsonPropertyName("Strength")]
		public int Strength { get; set; }
		/// <summary>
		/// The User's mana stat (Magical Attack Power).
		/// </summary>
		[JsonPropertyName("Mana")]
		public int Mana { get; set; }
		/// <summary>
		/// The User's durability stat (Health Points).
		/// </summary>
		[JsonPropertyName("Durability")]
		public int Durability { get; set; }
		/// <summary>
		/// The User's agility stat.
		/// </summary>
		[JsonPropertyName("Agility")]
		public int Agility { get; set; }
		
		/// <summary>
		/// The User's amount of coins.
		/// </summary>
		[JsonPropertyName("Coins")]
		public int Coins { get; set; }
		/// <summary>
		/// The User's amount of exp.
		/// </summary>
		[JsonPropertyName("Exp")]
		public int Exp { get; set; }

		/// <summary>
		/// Method reponsible of checking if the User is dead.
		/// </summary>
		/// <param name="HP"></param>
		/// <returns></returns>
		public bool CheckIfDead(int HP) {
			if (HP>0) {
				return false;
			} else {
				return true;
			}

		}
		/// <summary>
		/// Compares CheckIfDead() method is true or false, then takes acition.
		/// </summary>
		/// <param name="HP"></param>
		public void IsDead(int HP) {
			if (HP <= 0) {
				End(true);
			} else {
				textManager.PrintColoredText(UserName, Program.UserColor);
				Console.Write(" is still standing!\n");
			}
		}

		#endregion

		#region Floor - Enemies - Combat

		#region Floor
		private int floorLevel;

		/// <summary>
		/// The User's current floor-level. 0 to 1 (by the current version).
		/// </summary>
		[JsonPropertyName("FloorLevel")]
		public int FloorLevel {
			get { return floorLevel; }
			set {
				if (MobCount % 10 == 0 && MobCount > 0) {
					floorLevel = value;
					FloorChange(floorLevel);
				}
			}
		}

		/// <summary>
		/// Method responsible for changing floors.
		/// </summary>
		/// <param name="floorLevel"></param>
		public void FloorChange(int newFloorLevel) {
			floorLevel = newFloorLevel;
		}

		/// <summary>
		/// Method responsible of getting floorLevel.
		/// </summary>
		/// <returns></returns>
		public int GetFloorLevel() {
			return floorLevel;
		}

		#endregion

		#region Enemies
		private int mobCount;
		private int bossCount;

		/// <summary>
		/// The number of User's slain enemies.
		/// </summary>
		[JsonPropertyName("MobCount")]
		public int MobCount {
			get { return mobCount; }
			private set {
				mobCount = value;
			}
		}
		/// <summary>
		/// The number of User's slain bosses.
		/// </summary>
		[JsonPropertyName("BossCount")]
		public int BossCount {
			get { return bossCount; }
			private set {
				bossCount = value;
			}
		}

		/// <summary>
		/// The number of enemy slain, increases by 1.
		/// </summary>
		public void MobSlain() {
			mobCount++;
			if (mobCount % 10 == 0) {
				floorLevel++;
			}
		}
		/// <summary>
		/// The number of bosses slain, increases by 1.
		/// </summary>
		public void BossSlain() {
			bossCount++;
			FloorLevel++;
		}

		/// <summary>
		/// Method responsible of getting MobCount from User.
		/// </summary>
		/// <returns></returns>
		public int GetMobCount() {
			return mobCount;
		}
		/// <summary>
		/// Method responsible of getting BossCount from User.
		/// </summary>
		/// <returns></returns>
		public int GetBossCount() {
			return bossCount;
		}

		/// <summary>
		/// Method responsible of restoring User's health.
		/// </summary>
		/// <param name="health"></param>
		public void RestoreHealth(int health) {
			HitPoints += health;
		}

		#endregion

		#region Combat
		private int dodgeCount;
		private int physicalAttackCount;
		private int magicalAttackCount;

		/// <summary>
		/// The number of times the user has dodged.
		/// </summary>
		[JsonPropertyName("DodgeCount")]
		public int DodgeCount {
			get { return dodgeCount; }
			set { dodgeCount = value; }
		}

		/// <summary>
		/// The number of times the user has magically attacker.
		/// </summary>
		[JsonPropertyName("PhysicalAttackCount")]
		public int PhysicalAttackCount {
			get { return physicalAttackCount; }
			set { physicalAttackCount = value; }
		}
		/// <summary>
		/// The number of times the user has magically attacker.
		/// </summary>
		[JsonPropertyName("MagicalAttackCount")]
		public int MagicalAttackCount {
			get { return magicalAttackCount; }
			set { magicalAttackCount = value; }
		}


		#endregion

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of the User. 
		/// Entity, Strength, Mana, Durability, Agility.
		/// Additional info: UserName, MobCount, FloorLevel.
		/// </summary>
		public override void DisplayInfo(bool admin) {
			Console.WriteLine($"{UserName,21}: Username");
			Console.WriteLine($"{Strength,21}: Strength");
			Console.WriteLine($"{Mana,21}: Mana");
			Console.WriteLine($"{Durability,21}: Durability");
			Console.WriteLine($"{Agility,21}: Agility");
			Console.WriteLine($"{Coins,21}: Coins");
			Console.WriteLine($"{Exp,21}: Exp");
			Console.WriteLine($"{MobCount,21}: MobCount\n");

			if (admin) {
				Console.WriteLine($"{BossCount,21}: BossCount");
				Console.WriteLine($"{FloorLevel,21}: FloorLevel");
				Console.WriteLine($"{DodgeCount,21}: DodgeCount\n");

				Console.WriteLine($"{PhysicalAttackCount,21}: PhysicalAttackCount");
				Console.WriteLine($"{MagicalAttackCount,21}: MagicalAttackCount\n");
			}

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
		public void CreateUser(string usernameInput, string fileNameInput, User user) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				//RNG stats:
				int durHP = rng.Next((int)(minStat * 10), (int)(maxStat * 10));

				user.UserName = usernameInput;
				user.Strength = rng.Next(minStat, maxStat);
				user.Mana = rng.Next(minStat, maxStat);
				user.Durability = durHP;
				user.HitPoints = durHP;
				user.Agility = rng.Next(minStat, maxStat);

				user.MobCount = 0;
				user.BossCount = 0;
				user.FloorLevel = 0;

				string serialized = JsonSerializer.Serialize(user);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				File.WriteAllText(backupFileName, serialized);

				Console.WriteLine("User data saved successfully.\nUser created successfully.\nYour data:\n");
				user.DisplayInfo(false);
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		/// <summary>
		/// Get User info (load user) from Json-file.
		/// </summary>
		/// <param name="fileNameInput"></param>
		/// <returns>The user information loaded from the JSON file.</returns>
		public User GetUserInfo(string fileNameInput) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			string serializedData = null;

			if (File.Exists(fileName)) {
				Console.WriteLine("\nFile found!");
				serializedData = File.ReadAllText(fileName);
			} else if (File.Exists(backupFileName)) {
				Console.WriteLine("\nFile not found. Using backup!");
				serializedData = File.ReadAllText(backupFileName);
			} else {
				Console.WriteLine("File not found! Cannot load user.");
				return null;
			}

			try {
				return JsonSerializer.Deserialize<User>(serializedData);
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
						Console.WriteLine($"{user.MobCount,21}: MobCount");
						Console.WriteLine($"{user.MobCount,21}: BossCount");
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
		public override void Attack(string attackType, User user, Entity entity) {
			switch (attackType) {
				case "physical":
				case "phy":
				case "p":
					physicalAttackCount++;
					entity.EnemyDamaged(user.Strength);
					textManager.PrintColoredText(user.UserName, Program.UserColor);
					Console.Write(" has attacked!\nInflicted ");
					textManager.PrintColoredText(user.Strength, Program.DamageColor);
					Console.Write(" damage!\n\n");
					break;
				case "magical":
				case "magic":
				case "m":
					magicalAttackCount++;
					entity.EnemyDamaged(user.Mana);
					textManager.PrintColoredText(user.UserName, Program.UserColor);
					Console.Write(" has attacked!\nInflicted ");
					textManager.PrintColoredText(user.Strength, Program.DamageColor);
					Console.Write(" damage!\n\n");
					break;
				default:
					Console.WriteLine("You've failed your attack.");
					break;
			}
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
			Console.WriteLine("You've escaped!\nHealth is restored!\n");
		}

		/// <summary>
		/// Method responsible of User's death.
		/// </summary>
		public override void End(bool dead = false) {
			Console.Clear();
			if (dead) {
				Console.Write("The fearless adventurer ");
				textManager.PrintColoredText(UserName, Program.UserColor) ;
				Console.Write(" has met their demise, and the tower remains unconquered.\nYour journey ends here.\n");
			} 
			else {
				Console.Write("The fearless adventurer ");
				textManager.PrintColoredText(UserName, Program.UserColor);
				Console.Write(" has conquered the tower and stands atop of the world.\nYour journey ends here.\n");
			}

			Console.Write("As you lived out your legendary journey, other the people referred to you as the '");
			if ((PhysicalAttackCount > MagicalAttackCount) && (DodgeCount >= 50)) {
				if (PhysicalAttackCount >= 50) {
					textManager.PrintColoredText("Conqueror", ConsoleColor.DarkMagenta);
				} else {
					textManager.PrintColoredText("Martial Artist", ConsoleColor.Red);
				}
			} 
			else if (PhysicalAttackCount > MagicalAttackCount) {
				if (PhysicalAttackCount >= 50) {
					textManager.PrintColoredText("Berserker", ConsoleColor.DarkRed);
				} else {
					textManager.PrintColoredText("Brawler", ConsoleColor.Red);
				}
			}
			else if ((MagicalAttackCount > PhysicalAttackCount) && (DodgeCount >= 50)) {
				if (MagicalAttackCount >= 50) {
					textManager.PrintColoredText("Seer", ConsoleColor.Green);
				} else {
					textManager.PrintColoredText("Clairvoiant", ConsoleColor.Blue);
				}
			}
			else if (MagicalAttackCount > PhysicalAttackCount) {
				if (MagicalAttackCount >= 50) {
					textManager.PrintColoredText("Archmage", ConsoleColor.DarkMagenta);
				} else {
					textManager.PrintColoredText("Conjurer", ConsoleColor.Blue);
				}
			} 
			else if (DodgeCount >= 50) {
				textManager.PrintColoredText("Zephyr", ConsoleColor.Yellow);
			}
			else {
				textManager.PrintColoredText("Ordinary", ConsoleColor.DarkMagenta);
			}
			Console.Write("'.\n");

			if (dead) {
				string savedFileName = fileManager.GetSavedFileName();
				string backupFileName = fileManager.GetBackupFileName();

				if (!string.IsNullOrEmpty(savedFileName)) {
					WipeData(savedFileName);
					Console.WriteLine("Just as life is, people do not get a second change.");
					//Send to new function, wiping data.
				} else if (!string.IsNullOrEmpty(backupFileName)) {
					Console.WriteLine("Just as life is, people do not get a second change.");
					WipeData(backupFileName);
				} else {
					Console.WriteLine("In the absence of records, a new story is born. One that is unrecorded of your presence.");
				}

			} else {
				Console.WriteLine("Your legendary journey has ended, but your journey as a person has only begun.");
			}
			Console.WriteLine("Press any [KEY] to quit.");
			Console.ReadKey();
		}

		public void WipeData(string fileName) {
			Console.WriteLine($"This is the FileName : {fileName}");
			try {
				if (File.Exists(fileName)) {
					File.WriteAllText(fileName, "{}");

					Console.WriteLine($"Your journey '{fileName}' has ended");
				} else {
					Console.WriteLine($"In the absence of records, a new story is born. One that is unrecorded of your presence");
				}
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		#endregion

	}
}
