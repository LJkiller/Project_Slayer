using System;
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
		public static string gameVersion = "v0.6.9-b";

		static string FileNameInput;
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
		/// <param name="entity"></param>
		static void DisplayEntityInfo(Entity entity) {
			entity.DisplayInfo();
		}

		#endregion

		#region TextInput	

		/// <summary>
		/// A string input arranging into a numerical position.
		/// Input-filtering to a value in order to call different methods.
		/// </summary>
		/// <param name="inputString"></param>
		static void InputArrangement(string inputString) {

			List<string> inputCount = new List<string>();
			string empty = "";

			for (int i = 0; i < inputString.Length; i++) {
				char c = inputString[i];
				if (c == ' ') {
					if (!string.IsNullOrEmpty(empty)) {
						inputCount.Add(empty.ToLower());
						empty = "";
					}
				} 
				else {
					empty += c;
				}
			}
			if (!string.IsNullOrEmpty(empty)) {
				inputCount.Add(empty.ToLower());
			}

			if (inputCount.Count == 0) {
				Console.WriteLine("Invalid input, please try again. If you need help: [HELP]");
			} 

			//Quick functions.
			else if (inputCount.Count == 1) {
				if (inputCount[0] == "save" || inputCount[0] == "s") {
					Console.WriteLine("Which file do you want to save to?");
					fileManager.DisplayAllFiles();
					FileNameInput = Console.ReadLine();
					Console.WriteLine("Are you sure?\n[YES] or[NO]");
					while (run2) {
						string newOpt = Console.ReadLine().ToLower();
						if (newOpt == "yes" || newOpt == "y") {
							Console.Clear();
							fileManager.Save(FileNameInput, user);
							Console.WriteLine("Continuing to game.");
							run2 = false;
						} else if (newOpt == "no" || newOpt == "n") {
							continue;
						} else {
							Console.WriteLine("[YES] or [NO].");
						}
					}
				} 
				else if (inputCount[0] == "help" || inputCount[0] == "h") {
					HelpScreen(false);
				}
				else if (inputCount[0] == "quit" || inputCount[0] == "q") {
					Console.Clear();
					while (run2) {
						Console.WriteLine("File name?");
						fileManager.DisplayAllFiles();
						FileNameInput = Console.ReadLine();
						Console.WriteLine("Are you sure?\n[YES] or [NO]");
						string newOpt = Console.ReadLine().ToLower();
						if (newOpt == "yes" || newOpt == "y") {
							fileManager.Save(FileNameInput, user);
							run1 = false;
							run2 = false;
							run3 = false;
							Console.WriteLine("Press any [KEY] to quit.");
							Console.ReadKey();
						}
						else if (newOpt == "no" || newOpt == "n") {
							Console.Clear();
							continue;
						}
						else {
							Console.WriteLine("[YES] or [NO].");
						}
					}
				} 
				else {
					Console.WriteLine("Invalid input, please try again.");
				}
			} 

			//Functions > 1 input
			else {

			}
		}

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
		/// Initializes the game.
		/// </summary>
		static void InitializeGame() {
			StartScreen(true);
		}

		#region Screens

		/// <summary>
		/// The game's content.
		/// </summary>
		static void GameScreen() {
			Console.WriteLine("Game:");
			while (run1) {
				SetUp();
				Console.WriteLine("Function:");
				string input = Console.ReadLine();
				InputArrangement(input);
			}
		}

		/// <summary>
		/// The game's start screen.
		/// </summary>
		static void StartScreen(bool displayTitle) {
			SetUp();
			if (displayTitle) {
				textManager.PrintTitle();
			}
			Console.WriteLine("Do you want to start a new game?            Write 'S' or 'Start'.");
			Console.WriteLine("Do you want to continue from a save file?   Write 'C' or 'continue'.");
			Console.WriteLine("Do you want help?                           Write 'H' or 'help'.");
			Console.WriteLine("Do you want to quit?                        Write 'Q' or 'quit'.\n");

			while (run1) {
				string setUpInput = Console.ReadLine().ToLower();
				if (setUpInput == "start" || setUpInput == "new game") {
					run1 = false;
					Console.Clear();
					UserCreationScreen(user);
				} 
				else if (setUpInput == "continue" || setUpInput == "load") {
					run1 = false;
					Console.Clear();
					LoadScreen();
				} 
				else if (setUpInput == "help" || setUpInput == "h") {
					Console.Clear();
					HelpScreen(true);
				} 
				else if (setUpInput == "quit" || setUpInput == "q") {
					run1 = false;
					Console.Clear();
				} 
				else if (setUpInput == "cmds-check" || setUpInput == "check") {
					Console.WriteLine();
					user.CheckUserInfo(user, setUpInput);
				} 
				else if (setUpInput == "cmds-test") {
					Console.Clear();
					EntityTesting();
				} 
				else {
					Console.WriteLine("Write an appropiate input: 'start', 'continue', 'help' or 'quit'\n");
				}
			}
		}
		
		/// <summary>
		/// Represents a screen for creating a user by gathering necessary information.
		/// Information is then sent to CreateUser().
		/// </summary>
		/// <param name="user"></param>
		static void UserCreationScreen(User user) {
			while (run2) {
				Console.WriteLine("What do you want to be called? (Max 20 Characters)");
				string userNameInput = Console.ReadLine();

				if (userNameInput.Length > 20) {
					Console.WriteLine($"Max 20 characters ({userNameInput.Length} Characters).");
				} 
				else {
					Console.WriteLine("Are you sure?\n[YES] or [NO]");
					string opt = Console.ReadLine();
					if (opt.ToLower() == "yes" || opt.ToLower() == "y") {
						Console.WriteLine("To which file do you want to save your character?");
						FileNameInput = Console.ReadLine();
						user = new User(userNameInput);
						user.CreateUser(userNameInput, FileNameInput, user);
						Console.WriteLine("Press any [KEY] to continue.");
						Console.ReadKey();
						run1 = false;
						run2 = false;
						GameScreen();
					} else if (opt.ToLower() == "no" || opt.ToLower() == "n") {
						Console.Clear();
						continue;
					} else if (opt.ToLower() == "quit" || opt.ToLower() == "q") {
						Console.Clear();
						run1 = false;
						run2 = false;
					} else {
						Console.WriteLine("[YES] or [NO].");
					}
				}
			}
		}

		/// <summary>
		/// Load Screen.
		/// </summary>
		static void LoadScreen() {
			while (run2) {
				Console.WriteLine("Select your preferred file:");
				fileManager.DisplayAllFiles();
				FileNameInput = Console.ReadLine();

				Console.WriteLine("[CONTINUE] or [CHANGE]?");
				string opt = Console.ReadLine();
				if (opt.ToLower() == "continue") {
					try {
						user = user.GetUserInfo(FileNameInput);
						Console.WriteLine("Recieved data from JSON:\n");
						user.DisplayInfo();
						run1 = false;
						run2 = false;
						Console.WriteLine("Press any [KEY] to continue.");
						Console.ReadKey();
						GameScreen();
					} catch (ArgumentException e) {
						Console.WriteLine($"Slight problem; {e.Message}");
					}
				} 
				else if (opt.ToLower() == "change") {
					Console.Clear();
					continue;
				} else if (opt.ToLower() == "quit" || opt.ToLower() == "q") {
					Console.Clear();
					run1 = false;
					run2 = false;
				}
			}
		}

		/// <summary>
		/// The game's help screens.
		/// </summary>
		static void HelpScreen(bool StartAtGame) {
			SetUp();
			Console.WriteLine("What kind of help do you need?\n[GAME] or [COMMANDS].");
			while (run1) {
				string inputHelp = Console.ReadLine().ToLower();

				if (inputHelp == "game") {
					Console.Clear();
					textManager.PrintGameHelp();
					run2 = true;
				} 
				else if (inputHelp == "commands" || inputHelp == "cmds") {
					Console.Clear();
					textManager.PrintCMDSHelp();
					run2 = true;
				} 
				else {
					Console.WriteLine("[GAME] or [COMMANDS]");
					continue;
				}

				Console.WriteLine("Do you wish to continue to game or check out more?\n[GAME] or [MORE]");
				while (run2) {
					string furtherInput = Console.ReadLine().ToLower();

					if (furtherInput == "game" || furtherInput == "g") {
						if (StartAtGame == true) {
							run1 = false;
							run2 = false;
							Console.Clear();
							Console.WriteLine("New game or continue?\n[START] or [CONTINUE]");
							while (run3) {
								string gameContinuationInput = Console.ReadLine().ToLower();
								if (gameContinuationInput == "start" || gameContinuationInput == "s") {
									run3 = false;
									UserCreationScreen(user);
								} 
								else if (gameContinuationInput == "continue" || gameContinuationInput == "c") {
									run3 = false;
									LoadScreen();
								} 
								else {
									Console.WriteLine("'start' or 'continue'.");
								}
							}
						}
						else if (!StartAtGame == true) {
							run1 = false;
							run2 = false;
							Console.Clear();
							GameScreen();
						}
					} 
					else if (furtherInput == "more" || furtherInput == "m") {
						Console.Clear();
						Console.WriteLine("Available options: [GAME], [COMMANDS]");
						break;
					} 
					else {
						Console.WriteLine("[GAME] or [MORE].");
					}
				}
			}
		}

		#endregion

		#endregion

		#region Sandbox/Debug - Testing

		/// <summary>
		/// Testing RNG value for different races.
		/// </summary>
		static void EntityTesting() {
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

			InitializeGame();

			//Testing
			//Game();

		}
	}
}
