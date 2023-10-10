using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Slayer {

	/// <summary>
	/// Data class to invoke methods in order to manage files.
	/// </summary>
	public class FileManager {

		/// <summary>
		/// Saves the user's data into a json-file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="user"></param>
		public  void Save(string fileName, User User) {
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
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}
		public User Load() {
			return null;
		}
		public void DisplayAllFiles() {

		}
	}
}
