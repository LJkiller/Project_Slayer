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
		private int hitPoints;

		/// <summary>
		/// The User's name.
		/// </summary>
		[JsonPropertyName("UserName")]
		public string UserName { get; set; }

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
		/// The User's Hit Points (Health, HP).
		/// </summary>
		[JsonIgnore]
		public int HitPoints {
			get { return durability; }
			set {
				if (value <= 0)
					Death();
				else
					hitPoints = value;
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
			private set {
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

		#endregion

		#region Combat
		private int dodgeCount;

		/// <summary>
		/// The number of times the user has dodged.
		/// </summary>
		[JsonPropertyName("DodgeCount")]
		public int DodgeCount {
			get { return dodgeCount; }
			set { dodgeCount = value; }
		}

		#endregion

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of the User. 
		/// Entity, Strength, Mana, Durability, Agility.
		/// Additional info: UserName, MobCount, FloorLevel.
		/// </summary>
		public override void DisplayInfo() {
			Console.WriteLine($"{UserName,21}: Username");
			Console.WriteLine($"{Strength,21}: Strength");
			Console.WriteLine($"{Mana,21}: Mana");
			Console.WriteLine($"{Durability,21}: Durability");
			Console.WriteLine($"{Agility,21}: Agility");
			Console.WriteLine($"{Coins,21}: Coins");
			Console.WriteLine($"{Exp,21}: Exp");
			Console.WriteLine($"{MobCount,21}: MobCount\n");

			/* No Public Displaying.
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

			HitPoints = 0;

			MobCount = 20;
			BossCount = 0;
			FloorLevel = 1;
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
		public void CreateUser(string usernameInput, string fileNameInput, User user) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				// Initialize the user object with random stats
				user.UserName = usernameInput;
				user.Strength = rng.Next(minStat, maxStat);
				user.Mana = rng.Next(minStat, maxStat);
				user.Durability = rng.Next((int)(minStat * 10), (int)(maxStat * 10));
				user.Agility = rng.Next(minStat, maxStat);

				string serialized = JsonSerializer.Serialize(user);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				File.WriteAllText(backupFileName, serialized);

				Console.WriteLine("User data saved successfully.\nUser created successfully.\nYour data:\n");
				user.DisplayInfo();
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
			Console.WriteLine("You've escaped!\nHealth is restored!\nA new encounter begins.");
		}

		/// <summary>
		/// Method responsible of User's death.
		/// </summary>
		public override void Death() {
			Console.WriteLine($"The fearless adventurer {UserName} has met their demise, and the tower remains unconquered.\n" +
				$"Your journey ends here.");
			Console.ReadLine();
		}

		#endregion

	}
}
