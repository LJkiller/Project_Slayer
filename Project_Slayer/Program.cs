﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Slayer {

	//░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░██╗░░░██╗███╗░░░███╗  ████████╗░█████╗░  ███╗░░██╗██╗░██████╗░██╗░░██╗████████╗
	//░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██║░░░██║████╗░████║  ╚══██╔══╝██╔══██╗  ████╗░██║██║██╔════╝░██║░░██║╚══██╔══╝
	//░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░░██║██╔████╔██║  ░░░██║░░░██║░░██║  ██╔██╗██║██║██║░░██╗░███████║░░░██║░░░
	//░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░░██║██║╚██╔╝██║  ░░░██║░░░██║░░██║  ██║╚████║██║██║░░╚██╗██╔══██║░░░██║░░░
	//░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚██████╔╝██║░╚═╝░██║  ░░░██║░░░╚█████╔╝  ██║░╚███║██║╚██████╔╝██║░░██║░░░██║░░░
	//░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝  ░░░╚═╝░░░░╚════╝░  ╚═╝░░╚══╝╚═╝░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░

	//░█████╗░██╗████████╗██╗░░░██╗
	//██╔══██╗██║╚══██╔══╝╚██╗░██╔╝
	//██║░░╚═╝██║░░░██║░░░░╚████╔╝░
	//██║░░██╗██║░░░██║░░░░░╚██╔╝░░
	//╚█████╔╝██║░░░██║░░░░░░██║░░░
	//░╚════╝░╚═╝░░░╚═╝░░░░░░╚═╝░░░



	class Program {

		#region Variables

		public static int availableFloors = 2;
		public static string gameVersion = "v0.69.420-b";

		public static ConsoleColor UserColor = ConsoleColor.Blue;
		public static ConsoleColor EnemyColor = ConsoleColor.Red;
		public static ConsoleColor UserHealthColor = ConsoleColor.Green;
		public static ConsoleColor EnemyHealthColor = ConsoleColor.DarkYellow;
		public static ConsoleColor DamageColor = ConsoleColor.DarkRed;
		public static ConsoleColor CoinColor = ConsoleColor.Yellow;
		public static ConsoleColor ExpColor = ConsoleColor.Green;

		public static string FileNameInput;
		static bool run1;
		static bool run2;
		static bool run3;

		private static TextManager textManager;
		private static FileManager fileManager;
		public static User user;

		#endregion

		#region Information-handling

		/// <summary>
		/// Displays information about an Entity by calling its DisplayInfo-method.
		/// </summary>
		/// <param name="entity">The entity objekt to be handled in the method.</param>
		static void DisplayEntityInfo(Entity entity) {
			entity.DisplayInfo(false);
		}

		/// <summary>
		/// A string input arranging into a numerical position.
		/// Input-filtering to a value in order to call different methods.
		/// </summary>
		/// <param name="inputString">The string input to be handled in the method.</param>
		static void InputArrangement(string inputString, User user, Entity entity, int healthRestoration) {
			//Takes the inputString and convers it into a list to be handled easier.
			List<string> inputCount = inputString.ToLower().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

			if (inputCount.Count == 0) {
				Console.WriteLine("Invalid input, please try again. If you need help: [HELP]");
			} 
			
			//Quick Methods
			else if (inputCount.Count == 1) {
				string input = inputCount[0];
				switch (input) {
					case "save":
					case "s":
						Console.Clear();
						SaveFile(user);
						user.RestoreHealth(healthRestoration);
						break;
					case "attack":
						user.Attack("physical",user, entity);
						break;
					case "help":
					case "h":
						HelpScreen(false, user);
						break;
					case "quit":
					case "q":
						QuitGame(user);
						run1 = false;
						run2 = false;
						run3 = false;
						break;
					case "check":
						user.CheckUserInfo(user, "");
						break;
					case "forcedeath":
						user.HitPoints = 0;
						break;
					case "forceend":
						user.End(false);
						break;
					default:
						Console.WriteLine("Your move has been forfeited, enemy attacks. If you need help type 'HELP'.");
						break;
				}
			} 

			//Longer methods
			else {
				if (inputCount[0] == "attack") {
					user.Attack(inputCount[1], user, entity);
				}
				//Commands that can be executed as admins.
				else if (inputCount[0] == "admin") {
					if (inputCount[1] == "kill") {
						entity.End(true);
						entity.EnemyDamaged(entity.GetDurability());
					}
				} 
				else if (inputCount[0] == "check" && inputCount[1] == "admin") {
					user.CheckUserInfo(user, inputCount[1]);
				}
			}
		}

		#region Quick Methods

		/// <summary>
		/// Method responsible for saving the User's information to a desired file.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		static void SaveFile(User user) {
			Console.WriteLine("Which file do you want to save to?");
			fileManager.DisplayAllFiles();
			FileNameInput = Console.ReadLine();
			Console.WriteLine("Are you sure?\n[YES] or [NO]");

			//Proceed or not.
			while (run2) {
				string newOpt = Console.ReadLine().ToLower();
				if (newOpt == "yes" || newOpt == "y") {
					Console.Clear();
					fileManager.Save(FileNameInput, user);
					fileManager.SaveFileName(FileNameInput);
					Console.WriteLine("Continuing to the game.");
					run2 = false;
				} else if (newOpt == "no" || newOpt == "n") {
					continue;
				} else {
					Console.WriteLine("[YES] or [NO].");
				}
			}
		}

		/// <summary>
		/// Method responsible for quitting the game.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		static void QuitGame(User user) {
			Console.Clear();
			while (run2) {
				Console.WriteLine("File name?");
				fileManager.DisplayAllFiles();
				FileNameInput = Console.ReadLine();
				Console.WriteLine("Are you sure?\n[YES] or [NO]");

				//Proceed or not.
				string newOpt = Console.ReadLine().ToLower();
				if (newOpt == "yes" || newOpt == "y") {
					fileManager.Save(FileNameInput, user);
					fileManager.SaveFileName(FileNameInput);
					run1 = false;
					run2 = false;
					run3 = false;
					Console.WriteLine("Press any [KEY] to quit.");
					Console.ReadKey();
				} else if (newOpt == "no" || newOpt == "n") {
					Console.Clear();
					continue;
				} else {
					Console.WriteLine("[YES] or [NO].");
				}
			}
		}

		#endregion

		#endregion

		#region Game Components

		/// <summary>
		/// Set ups the game's initial configuration.
		/// </summary>
		static void SetUp() {
			textManager = new TextManager();
			fileManager = new FileManager();
			user = new User("DefaultUsername");
			run1 = true;
			run2 = true;
			run3 = true;
		}

		/// <summary>
		/// Initializes the game instance.
		/// </summary>
		static void InitializeGame() {
			StartScreen(true);
		}

		#region Screens

		#region Game Screen

		/// <summary>
		/// The game's content.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		static void GameScreen(User user) {
			SetUp();
			//Creates a list to make handling enemies easier.
			List<Entity> entityCombat = new List<Entity>();
			int previousFloorLevel = 0;
			Console.Clear();

			while (run1) {
				int currentFloorLevel = user.GetFloorLevel();
				int healthRestoration = (user.Durability - user.HitPoints);

				//Checks if there is any mob, if no mob, creates one.
				if (entityCombat.Count < 1) {
					//Check if game should end.
					if (user.MobCount >= 20 && user.FloorLevel > 1) {
						user.End(false);
						run1 = false;
						run2 = false;
						run3 = false;
						break;
					}

					//Restores health. Makes it obselete for HP to be saved with JsonFile.
					user.RestoreHealth(healthRestoration);
					//Adds mob.
					entityCombat.Add(SpawnMob(user.FloorLevel, user.MobCount));

					//Leveling Roundabout.
					if (currentFloorLevel > previousFloorLevel) {
						user.LevelUpOnNewFloor(user);
						previousFloorLevel = currentFloorLevel;
					}

					//Use to check if somehting actually happens.
					Console.WriteLine($"FloorLevel: {user.GetFloorLevel()}, MobCount: {user.GetMobCount()}");

					textManager.PrintNewMobAppearance(user, entityCombat[0]);
				} 
				else {
					//Checks the entity's durability, if it's dead or not.
					if (entityCombat[0].GetDurability() <= 0) {
						user.MobSlain();
						Console.Clear();
						//Coins and EXP doesn't work.
						//textManager.PrintLoot(user, entityCombat[0]);
						//Making a roundabout.
						entityCombat.RemoveAt(0);
						continue;
					} 
					else {
						//Checks if user is dead, proceeds.
						if (user.CheckIfDead(user.HitPoints)) {
							run1 = false;
							run2 = false;
							run3 = false;
							user.IsDead(user.HitPoints);
							break;
						} 
						else if (user.CheckIfDead(user.HitPoints) == false) {
							user.IsDead(user.HitPoints);
						}
						textManager.PrintAfterRound(user, entityCombat[0]);
					}
				}
				Console.WriteLine("Your move, brave soul!");

				//User input is then distributed for functions that change the attack order.
				string input = Console.ReadLine();
				Console.WriteLine();
				if (input.ToLower() == "dodge" || input.ToLower() == "dg") {
					user.Dodge();
				} else if (input.ToLower() == "escape" || input.ToLower() == "esc") {
					Console.Clear();
					user.Escape();
					entityCombat.RemoveAt(0);
				} else {
					//Function that does not disturb the attack order, will proceed as turn-based combat.
					InputArrangement(input, user, entityCombat[0], healthRestoration);
					entityCombat[0].Attack("physical", user, entityCombat[0]);
				}
			}
		}

		/// <summary>
		/// Method responsible of creating an entity.
		/// </summary>
		/// <param name="floorLevel">The User's floorLevel</param>
		/// <param name="mobCount">The User's mobCount</param>
		/// <returns>Returns a new entity instance, or returns null.</returns>
		static Entity SpawnMob(int floorLevel, int mobCount) {

			//Use this as debug, to be certain about the conditions.
			//Console.WriteLine($"Floor: {floorLevel}, Mob Count: {mobCount}, Required Mob Count: 19");

			if (floorLevel == 0) {
				return new Human();
			} else if (floorLevel == 1) {
				if (mobCount+1 == 20) {
					return new GoblinLord();
				} else {
					return new Goblin();
				}
			}
			return null;
		}

		#endregion

		#region Start Screen

		/// <summary>
		/// Displays the start screen and processes user input for starting, continuing, getting help, or quitting the game.
		/// </summary>
		/// <param name="displayTitle">Bool to be compared if it should display the game's title.</param>
		static void StartScreen(bool displayTitle) {
			SetUp();
			if (displayTitle) {
				textManager.PrintTitle();
			}

			Console.WriteLine("Do you want to start a new game?            Write 'S' or 'Start'.");
			Console.WriteLine("Do you want to continue from a save file?   Write 'C' or 'Continue'.");
			Console.WriteLine("Do you want help?                           Write 'H' or 'Help'.");
			Console.WriteLine("Do you want to quit?                        Write 'Q' or 'Quit'.\n");

			//These two should not be displayed at the current moment.
			//Each of these displayed methods are still usable, just hidden.
			//Console.WriteLine("Check user info?                            Write 'U' or 'Check'.");
			//Console.WriteLine("Run entity testing?                         Write 'T' or 'Test'.\n");

			while (run1) {
				string setUpInput = Console.ReadLine().ToLower();
				ProcessStartInput(setUpInput);
			}
		}

		/// <summary>
		/// Method responsible of processing user input at the start of the game.
		/// </summary>
		/// <param name="userInput">String to be compared of what proceeding action should be taken.</param>
		static void ProcessStartInput(string userInput) {
			switch (userInput) {
				case "start":
				case "s":
					run1 = false;
					Console.Clear();
					UserCreationScreen();
					break;
				case "continue":
				case "c":
					run1 = false;
					Console.Clear();
					LoadScreen();
					break;
				case "help":
				case "h":
					Console.Clear();
					HelpScreen(true, user);
					break;
				case "quit":
				case "q":
					run1 = false;
					Console.Clear();
					break;
				case "test":
				case "t":
					Console.Clear();
					EntityTesting();
					break;
				default:
					Console.WriteLine("Write an appropriate input: 'start', 'continue', 'help', 'quit', 'check', or 'test'\n");
					break;
			}
		}

		#endregion

		#region User Create Screen

		/// <summary>
		/// Represents a screen for creating a user by gathering necessary information.
		/// Information is then sent to CreationFileScreen().
		/// </summary>
		static void UserCreationScreen() {
			while (true) {
				Console.WriteLine("What do you want to be called? (Max 20 Characters)");
				string userNameInput = Console.ReadLine();

				if (userNameInput.Length > 20) {
					Console.WriteLine($"Max 20 characters ({userNameInput.Length} Characters).\n");
					continue;
				}

				Console.WriteLine("Are you sure?\n[YES] or [NO]?");
				while (true) {
					string opt = Console.ReadLine().ToLower();

					if (opt == "yes" || opt == "y") {
						CreationFileScreen(userNameInput);
					} 
					else if (opt == "no" || opt == "n") {
						Console.Clear();
						break;
					} 
					else if (opt == "quit" || opt == "q") {
						Console.Clear();
						run1 = false;
						run2 = false;
						break;
					} 
					else {
						Console.WriteLine("[YES] or [NO].");
					}
				}
			}
		}

		/// <summary>
		/// Represents a screen for selecting a file to save a user's character.
		/// Information is then sent to CreateUser();
		/// </summary>
		/// <param name="userNameInput">String to be handled as the User's username.</param>
		static void CreationFileScreen(string userNameInput) {
			while (true) {
				Console.Clear();
				Console.WriteLine("To which file do you want to save your character to?");
				string FileNameInput = Console.ReadLine();
				Console.WriteLine("Are you sure?\n[YES] or [NO]?");
				while (true) {
					string newOpt = Console.ReadLine().ToLower();
					if (newOpt == "yes" || newOpt == "y") {
						user = new User(userNameInput);
						user.CreateUser(userNameInput, FileNameInput, user);
						fileManager.SaveFileName(FileNameInput);
						fileManager.BackupFileName(FileNameInput);
						Console.WriteLine("Press any [KEY] to continue.");
						Console.ReadKey();
						GameScreen(user);
						break;
					} 
					else if (newOpt == "no" || newOpt == "n") {
						break;
					} 
					else {
						Console.WriteLine("[YES] or [NO].");
					}
				}
			}
		}

		#endregion

		#region Load Screen

		/// <summary>
		/// Load user info screen and allows the user to select a file to load from.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when file is not found or has invalid data.</exception>
		static void LoadScreen() {
			while (run2) {
				Console.WriteLine("Select your preferred file:");
				fileManager.DisplayAllFiles();
				FileNameInput = Console.ReadLine();

				//Proceed or not.
				Console.WriteLine("Are you sure?\n[YES] or [NO]?"); 
				if (FileNameInput.ToLower() == "quit" || FileNameInput.ToLower() == "q") {
					Console.Clear();
					run1 = false;
					run2 = false;
					run3 = false;
				}
				while (run3) {
					string opt = Console.ReadLine().ToLower();

					//Proceed or not.
					if (opt == "yes" || opt == "y") {
						try {
							user = user.GetUserInfo(FileNameInput);
							fileManager.SaveFileName(FileNameInput);
							fileManager.BackupFileName(FileNameInput);
							Console.WriteLine("Received data from JSON:\n");
							user.DisplayInfo(false);
							Console.WriteLine("Press any [KEY] to continue.");
							Console.ReadKey();
							run1 = false;
							run2 = false;
							run3 = false;
							GameScreen(user);
							break;
						} catch (ArgumentException e) {
							Console.WriteLine($"An issue occurred: {e.Message}");
						}
					} 
					else if (opt == "no" || opt == "n") {
						Console.Clear();
						break;
					} 
					else if (opt == "quit" || opt == "q") {
						Console.Clear();
						run1 = false;
						run2 = false;
						run3 = false;
					} 
					else {
						Console.WriteLine("[YES] or [NO].");
					}
				}
			}
		}

		#endregion

		#region HelpScreen 

		/// <summary>
		/// Help screen allows the user to get game or commands help.
		/// </summary>
		/// <param name="startAtGame">Bool to be compared if HelpScreen is called from the start of the gaem or during game.</param>
		/// <param name="user">The User object transfering information across game.</param>
		static void HelpScreen(bool startAtGame, User user = null) {
			SetUp();
			Console.WriteLine("What kind of help do you need?\n[GAME] or [COMMANDS].");

			//Options
			while (run2) {
				string inputHelp = Console.ReadLine().ToLower();

				if (inputHelp == "game") {
					Console.Clear();
					textManager.PrintGameHelp();
					ShowGameOrMore(startAtGame, user);
					break;
				} else if (inputHelp == "commands" || inputHelp == "cmds") {
					Console.Clear();
					textManager.PrintCMDSHelp();
					ShowGameOrMore(startAtGame, user);
				}
				else {
					Console.WriteLine("[GAME] or [COMMANDS]");
				}
			}
		}

		/// <summary>
		/// Option to continue to game or more help.
		/// </summary>
		/// <param name="startAtGame">Bool to be compared if HelpScreen is called from the start of the gaem or during game.</param>
		static void ShowGameOrMore(bool startAtGame, User user) {
			Console.WriteLine("Do you wish to continue to the game or check out more?\n[GAME] or [MORE]");

			//Options
			while (true) {
				string furtherInput = Console.ReadLine().ToLower();

				if (furtherInput == "game" || furtherInput == "g") {
					Console.Clear();
					if (startAtGame) {
						StartOrContinueGame();
					} else {
						GameScreen(user);
						break;
					}
					break;
				} 
				else if (furtherInput == "more" || furtherInput == "m") {
					Console.Clear();
					HelpScreen(false, user);
				} 
				else {
					Console.WriteLine("[GAME] or [MORE].");
				}
			}
		}

		/// <summary>
		/// Option to start a new game or continue.
		/// </summary>
		static void StartOrContinueGame() {
			Console.WriteLine("New game or continue?\n[START] or [CONTINUE]");

			//Options
			while (true) {
				string gameContinuationInput = Console.ReadLine().ToLower();
				if (gameContinuationInput == "start" || gameContinuationInput == "s") {
					UserCreationScreen();
					break;
				} 
				else if (gameContinuationInput == "continue" || gameContinuationInput == "c") {
					LoadScreen();
					break;
				} 
				else {
					Console.WriteLine("'start' or 'continue'.");
				}
			}
		}
		#endregion

		#endregion

		#endregion

		#region Sandbox/Debug - Testing

		/// <summary>
		/// Testing RNG value for different races.
		/// </summary>
		static void EntityTesting() {
			//Creates a list of entities.
			List<Entity> entityList = new List<Entity>();
			entityList.Add(new Human());
			entityList.Add(new Human());
			entityList.Add(new Human());
			entityList.Add(new Goblin());
			entityList.Add(new Goblin());
			entityList.Add(new Goblin());
			entityList.Add(new GoblinLord());


			Console.WriteLine();
			for (int i = 0; i < entityList.Count; i++) {
				DisplayEntityInfo(entityList[i]);
				Console.WriteLine();
			}
		}

		#endregion

		static void Main(string[] args) {

			//ColorTesting();

			InitializeGame();
		}
	}
}






















	//███████╗██╗░░░██╗░█████╗░██╗░░██╗  ██╗████████╗  ░██╗░░░░░░░██╗███████╗  ██████╗░░█████╗░██╗░░░░░██╗░░░░░
	//██╔════╝██║░░░██║██╔══██╗██║░██╔╝  ██║╚══██╔══╝  ░██║░░██╗░░██║██╔════╝  ██╔══██╗██╔══██╗██║░░░░░██║░░░░░
	//█████╗░░██║░░░██║██║░░╚═╝█████═╝░  ██║░░░██║░░░  ░╚██╗████╗██╔╝█████╗░░  ██████╦╝███████║██║░░░░░██║░░░░░
	//██╔══╝░░██║░░░██║██║░░██╗██╔═██╗░  ██║░░░██║░░░  ░░████╔═████║░██╔══╝░░  ██╔══██╗██╔══██║██║░░░░░██║░░░░░
	//██║░░░░░╚██████╔╝╚█████╔╝██║░╚██╗  ██║░░░██║░░░  ░░╚██╔╝░╚██╔╝░███████╗  ██████╦╝██║░░██║███████╗███████╗
	//╚═╝░░░░░░╚═════╝░░╚════╝░╚═╝░░╚═╝  ╚═╝░░░╚═╝░░░  ░░░╚═╝░░░╚═╝░░╚══════╝  ╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝