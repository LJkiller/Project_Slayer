﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

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

		static User User;

		#endregion

		#region Information-handling

		#region In-game

		#region Display Information

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
		/// Converting fileNameInput into a file-name.
		/// </summary>
		/// <param name="fileNameInput"></param>
		/// <returns>Converted text to FileName.json</returns>
		static string FileInputConversion(string fileNameInput) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			return fileName;
		}
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

			if (inputCount.Count <= 1) {

				if (inputCount[0].ToLower() == "save") {
					Console.WriteLine("Which file do you want to save to?");
					FileNameInput = Console.ReadLine();
					Save(FileInputConversion(FileNameInput), User);
				} else if (inputCount[0].ToLower() == "quit" || inputCount[0] == "q") {

				} else {

				}

			} else if (inputCount.Count > 1) {

			} else {

			}
		}

		#endregion

		#endregion

		#region File-management

		/// <summary>
		/// Saves the user's data into a json-file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="user"></param>
		static void Save(string fileName, User User) {
			try {
				string serialized = JsonSerializer.Serialize(User);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				Console.WriteLine("User data saved successfully!");
				Console.WriteLine("Saved data:");
				User.DisplayInfo();
				Console.WriteLine(serialized);
			} catch (ArgumentException e) {
				Error();
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}
		/// <summary>
		/// Load User from Json-file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		static User Load(string fileName) {
			try {
				if (File.Exists(fileName)) {
					Console.WriteLine("\nFile found!");
					string serializedFromFile = File.ReadAllText(fileName);
					Console.WriteLine($"Data successfully extracted!\nSerialized JSON from file: " +
						$"{fileName}.\n{serializedFromFile}");

					return JsonSerializer.Deserialize<User>(serializedFromFile);
				} else {
					Console.WriteLine($"File not found! Cannot load user.");
					return null;
				}
			} catch (Exception e) {
				Error();
				Console.WriteLine($"Something went wrong loading the user's data!\n{e.Message}");
				return null;
			}
		}

		/// <summary>
		/// Creates the user and saves the data into a json-file.
		/// </summary>
		/// <param name="usernameInput"></param>
		/// <param name="User"></param>
		static void CreateUser(string usernameInput, string fileName, User User) {
			try {
				string serialized = JsonSerializer.Serialize(User);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				Console.WriteLine("User data saved successfully.\nUser created successfully.");
				Console.WriteLine($"Your data:");
				User.DisplayInfo();
			} catch (ArgumentException e) {
				Error();
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}
		#endregion

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
			User = new User(userNameInput, 0, 0, 0, 0, 0, 0, 0);
			CreateUser(userNameInput, FileInputConversion(FileNameInput), User);
		}

		#endregion

		/// <summary>
		/// Set ups the game's initial configurations.
		/// </summary>
		static void SetUp() {
			GameTitle();
			Console.WriteLine("\nDo you want to start a new game?            Write 'Start'.");
			Console.WriteLine("Do you want to continue from a save file?   Write 'continue'.");
			Console.WriteLine("Do you want help?                           Write 'help'.");
			Console.WriteLine("Do you want to quit?                        Write 'quit'.");

			while (run1) {
				string setUpInput = Console.ReadLine();
				if (setUpInput.ToLower() == "start" || setUpInput.ToLower() == "new game") {
					run1 = false;
					Console.Clear();
					UserCreationScreen(User);
				} else if (setUpInput.ToLower() == "continue" || setUpInput.ToLower() == "load" || 
					setUpInput.ToLower() == "fortsätt") {
					run1 = false;
					Console.Clear();
					Console.WriteLine("kys");
				} else if (setUpInput.ToLower() == "help" || setUpInput.ToLower() == "!help") {

				} else if (setUpInput.ToLower() == "quit" || setUpInput.ToLower() == "q") {
					run1 = false;

				} else {
					Console.WriteLine("Write an appropiate input: 'start', 'continue', 'help' or 'quit'\n");
				}
			}
		}
		/// <summary>
		/// Displays the game's title in a stylized text.
		/// </summary>
		static void GameTitle() {
			Console.WriteLine("███████████████████████████████████████████████████████");
			Console.WriteLine("█─▄─▄─█─█─█▄─▄▄─███─▄▄▄▄█▄─▄████▀▄─██▄─█─▄█▄─▄▄─█▄─▄▄▀█");
			Console.WriteLine("███─███─▄─██─▄█▀███▄▄▄▄─██─██▀██─▀─███▄─▄███─▄█▀██─▄─▄█");
			Console.WriteLine("██▄▄▄██▄█▄█▄▄▄▄▄███▄▄▄▄▄█▄▄▄▄▄█▄▄█▄▄██▄▄▄██▄▄▄▄▄█▄▄█▄▄█");
		}

		#endregion

		#region Debugging

		/// <summary>
		/// An error message.
		/// </summary>
		static void Error() {
			Console.WriteLine("(._.)\n\n    An Error.");
		}
		
		#endregion

		static void Main(string[] args) {

			//Load Test
			/*
			Console.WriteLine("File?");
			string file = Console.ReadLine();
			Console.WriteLine("Load me up");
			string opt = Console.ReadLine();
			if (opt.ToLower() == "load") {
				Load(FileInputConversion(file));
			} else {

			}
			*/

			//Set up Test
			
			SetUp();
			Console.WriteLine("Function:");
			string input = Console.ReadLine();
			InputArrangement(input);
			

			//Entity List
			/*
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
			*/





			Console.ReadLine();
		}
	}
}
