using System;
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

		#region Text Inputs		

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
				if (inputCount[0] == "balls") {
					Console.WriteLine("Balls, it worked");
				}
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
		static void Save(string fileName, User user) {
			try {
				string serialized = JsonSerializer.Serialize(user);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				Console.WriteLine("User data saved successfully.");
			} catch (ArgumentException e) {
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
					Console.WriteLine($"Serialized JSON from file:\n{serializedFromFile}");

					return JsonSerializer.Deserialize<User>(serializedFromFile);
				} else {
					Console.WriteLine($"File not found! Cannot load user.");
					return null;
				}
			} catch (Exception e) {
				Console.WriteLine($"An error occurred while loading user data: {e.Message}");
				return null;
			}
		}
		#endregion

		#endregion

		#region Debugging
		/// <summary>
		/// An error message.
		/// </summary>
		static void Error() {
			Console.WriteLine("(._.)\n   An Error.");
		}
		#endregion

		static void Main(string[] args) {
			Console.WriteLine("File name?");
			string fileNameInput = Console.ReadLine();
			string fileName = $"{fileNameInput}.json";

			User user;

			Console.WriteLine("Save or Load?");
			string opt = Console.ReadLine().ToLower();
			if (opt == "save") {

				Console.WriteLine("What do you want to be called?");
				string userNameInput = Console.ReadLine();
				user = new User(userNameInput, 0, 0, 0, 0); 
				Save(fileName, user);

				List<Entity> entityList = new List<Entity>();
				entityList.Add(user);
				entityList.Add(user);
				entityList.Add(user);
				entityList.Add(new Human());
				entityList.Add(new Goblin());

				Console.WriteLine();
				for (int i = 0; i < entityList.Count; i++) {
					DisplayEntityInfo(entityList[i]);
					Console.WriteLine();
				}

			} else if (opt == "load") {
				User loadedUser = Load(fileName);
				loadedUser.DisplayInfo();
			}




			Console.ReadLine();
		}
	}
}
