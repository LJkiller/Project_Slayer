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

		static string FileNameInput;
		static bool run1 = true;
		static bool run2 = true;
		static bool run3 = true;

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

			//Quick functions
			if (inputCount.Count <= 1) {

				if (inputCount[0].ToLower() == "save") {
					Console.WriteLine("Which file do you want to save to?");
					FileNameInput = Console.ReadLine();
					fileManager.Save(FileNameInput, user);
				} else if (inputCount[0].ToLower() == "quit" || inputCount[0] == "q") {

				} else {
					Console.WriteLine("Invalid input, please try again?");
				}

			} 
			else if (inputCount.Count > 1) {
			} 
			else {
				Console.WriteLine("Invalid input, please try again?");
			}
		}

		#endregion

		#region SetUp

		#region Screens

		/// <summary>
		/// Represents a screen for creating a user by gathering necessary information.
		/// Information is then sent to CreateUser().
		/// </summary>
		/// <param name="user"></param>
		static void UserCreationScreen(User user) {
			Console.WriteLine("What do you want to be called?");
			string userNameInput = Console.ReadLine();
			Console.WriteLine("To which file do you want to save your character?");
			FileNameInput = Console.ReadLine();
			Program.user = new User(userNameInput);
			Program.user.CreateUser(userNameInput, FileNameInput, Program.user);
		}

		/// <summary>
		/// The game's start screen.
		/// </summary>
		static void StartScreen(bool displayTitle) {
			SetUp();
			if (displayTitle) {
				textManager.PrintTitle();
			}
			Console.WriteLine("\nDo you want to start a new game?            Write 'Start'.");
			Console.WriteLine("Do you want to continue from a save file?   Write 'continue'.");
			Console.WriteLine("Do you want help?                           Write 'help'.");
			Console.WriteLine("Do you want to quit?                        Write 'quit'.\n");

			while (run1) {
				string setUpInput = Console.ReadLine();
				if (setUpInput.ToLower() == "start" || setUpInput.ToLower() == "new game") {
					run1 = false;
					Console.Clear();
					UserCreationScreen(user);
				} 
				else if (setUpInput.ToLower() == "continue" || setUpInput.ToLower() == "load" ||
					setUpInput.ToLower() == "fortsätt") {
					run1 = false;
					Console.Clear();
					LoadTest();
				} 
				else if (setUpInput.ToLower() == "help" || setUpInput.ToLower() == "!help") {
					run1 = false;
					Console.Clear();
					Console.WriteLine("kys");

				} 
				else if (setUpInput.ToLower() == "quit" || setUpInput.ToLower() == "q") {
					run1 = false;
					Console.Clear();
				} 
				else if (setUpInput.ToLower() == "cmds-check") {
					user.CheckUserInfo(user);
				}
				else {
					Console.WriteLine("Write an appropiate input: 'start', 'continue', 'help' or 'quit'\n");
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
		/// Testing the loading function.
		/// </summary>
		static void LoadTest() {
			Console.WriteLine("File?");
			fileManager.DisplayAllFiles();
			FileNameInput = Console.ReadLine();
			Console.WriteLine("Load me up");
			string opt = Console.ReadLine();
			if (opt.ToLower() == "load") {
				try {
					user = user.GetUserInfo(FileNameInput);
					StartScreen(false);
				} catch (ArgumentException e) {
					Console.WriteLine($"Slight problem; {e}");
				}
			} else {

			}
		}

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


			Console.WriteLine();
			for (int i = 0; i < entityList.Count; i++) {
				DisplayEntityInfo(entityList[i]);
				Console.WriteLine();
			}
		}

		#endregion

		static void Main(string[] args) {

			SetUp();
			//SetUpTest();
			LoadTest();
			//EntityListTest();

			Console.ReadLine();
		}
	}
}
