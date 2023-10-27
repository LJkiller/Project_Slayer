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
	/// Data class to invoke methods in order to manage text.
	/// </summary>
	public class TextManager {

		/// <summary>
		/// Displays an error message.
		/// </summary>
		public void PrintError() {
			Console.WriteLine("(._.)\n\n    An Error.");
		}

		/// <summary>
		/// Displays the game's title in a stylized text.
		/// </summary>
		public void PrintTitle() {
			Console.WriteLine("███████████████████████████████████████████████████████");
			Console.WriteLine("█─▄─▄─█─█─█▄─▄▄─███─▄▄▄▄█▄─▄████▀▄─██▄─█─▄█▄─▄▄─█▄─▄▄▀█");
			Console.WriteLine("███─███─▄─██─▄█▀███▄▄▄▄─██─██▀██─▀─███▄─▄███─▄█▀██─▄─▄█");
			Console.WriteLine("██▄▄▄██▄█▄█▄▄▄▄▄███▄▄▄▄▄█▄▄▄▄▄█▄▄█▄▄██▄▄▄██▄▄▄▄▄█▄▄█▄▄█\n");
		}

		/// <summary>
		/// Displayes the game's introduction and basic information for the game.
		/// </summary>
		public void PrintGameHelp() {
			PrintTitle();
			Console.WriteLine(
				"Slayer is a console-based game with an impleted ideal turn-based combat.\n" +
				"Your goal is to climb tower-levels, floors, and reach the top. You start at floor 0.\n" +
				"There are 10 entities per floor, with a stronger variation of a creature, a named creature, a boss.\n" +
				"The bosses appears every second floor, the first one is on floor 1.\n" +
				"Each entity you SLAY you'll gain coins and exp in order to level up your attributes in order to advance the game\n" +
				"as you continue climbing.\n" +
				$"There are currently {Program.availableFloors} floors available as in this version ({Program.gameVersion}).\n");
		}

		/// <summary>
		/// Displayes the game's commands.
		/// </summary>
		public void PrintCMDSHelp() {
			Console.WriteLine(
				"During game:\n" +
				"Save: 'save' or 's' (Saving mid game)\n" +
				"Quit: 'quit' or 'q' (Will lead to save and then quit)\n\n" +
				"Combat-related:\n" +
				"Attack: 'attack + [ATTACKTYPE]' (Physical or magical, if nothing => physical attack)\n" +
				"[ATTACKTYPE] = 'physical' or 'magical' (or 'm')\n" +
				"Escape: 'escape' or 'esc' (Escape from enemy, restores your health.)\n\n" +
				"Leveling: 'level + [STAT]' (Levels up your specific stat with something between 1 and 5)\n" +
				"[STAT] = 'strength', 'mana', 'durability', 'agility'\n");
		}

	}
}
