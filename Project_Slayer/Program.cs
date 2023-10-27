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

		/// <summary>
		/// Just holding it for the time being.
		/// </summary>
		static void Game() {
			SetUp();
			Console.WriteLine("Game:");
			while (run1) {
				Console.WriteLine("Yes.");
				Console.ReadLine();
			}
		}
		
		/// <summary>
		/// Just holding it for the time being.
		/// </summary>
		static void HelpScreen() {
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
						run1 = false;
						run2 = false;
						Console.Clear();
						Game();
					} else if (furtherInput == "more" || furtherInput == "m") {
						Console.Clear();
						Console.WriteLine("Available options: [GAME], [COMMANDS]");
						break;
					} else {
						Console.WriteLine("[GAME] or [MORE].");
					}
				}
			}
		}

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

		#region Text Input	

		/// <summary>
		/// A string input arranging into a numerical position.
		/// Input-filtering to a value in order to call different methods.
		/// </summary>
		/// <param name="inputString"></param>
		static void InputArrangement(string inputString) {

			List<string> inputCount = new List<String>();
			string empty = "";

			for (int i = 0; i < inputString.Length; i++) {
				if (inputString[i] == ' ') {
					inputCount.Add(empty);
					empty = "";
				} else {
					empty += inputString[i];
				}
			}
			if (empty != "") {
				inputCount.Add(empty);
				empty = "";
			}

			//Change every character to a small letter.
			for (int i = 0; i < inputCount.Count; i++) {
				inputCount[i].ToLower();
			}

			//Quick functions
			if (inputCount.Count <= 1) {

				if (inputCount[0] == "save") {
					Console.WriteLine("Which file do you want to save to?");
					FileNameInput = Console.ReadLine();
					fileManager.Save(FileNameInput, user);
				} 
				else if (inputCount[0] == "quit" || inputCount[0] == "q") {

				} 
				else {
					Console.WriteLine("Invalid input, please try again?");
				}

			} 
			
			else if (inputCount.Count > 1) {
			} 
			else {
				Console.WriteLine("Invalid input, please try again. If you need help: [!HELP]");
			}
		}

		#endregion

		#region SetUp

		#region Screens

		/// <summary>
		/// The game's start screen.
		/// </summary>
		static void StartScreen(bool displayTitle) {
			SetUp();
			if (displayTitle) {
				textManager.PrintTitle();
			}
			Console.WriteLine("Do you want to start a new game?            Write 'Start'.");
			Console.WriteLine("Do you want to continue from a save file?   Write 'continue'.");
			Console.WriteLine("Do you want help?                           Write 'help'.");
			Console.WriteLine("Do you want to quit?                        Write 'quit'.\n");

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
				else if (setUpInput == "help" || setUpInput == "!help") {
					Console.Clear();
					HelpScreen();
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
					EntityListTest();
				} else {
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
						Game();
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
						Game();
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

		#endregion

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

		#endregion

		#region Sandbox - Testing

		/// <summary>
		/// Testing the StartScreen & SetUp in the beginning.
		/// </summary>
		static void SetUpTest() {
			StartScreen(true);
			Console.WriteLine("Function:");
			string input = Console.ReadLine();
			InputArrangement(input);
		}

		/// <summary>
		/// Testing RNG value for different races.
		/// </summary>
		static void EntityListTest() {
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

			SetUp();
			//EntityListTest();

			SetUpTest();
			//LoadScreen();

			Console.ReadLine();
		}
	}
}
