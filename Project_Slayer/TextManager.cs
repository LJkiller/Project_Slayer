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

		#region Screen Related

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
				$"There are currently {Program.availableFloors} floors available as in this version ({Program.gameVersion}).\n" +
				$"Floor 0 to {Program.availableFloors-1}.\n");
		}

		/// <summary>
		/// Displayes the game's commands.
		/// </summary>
		public void PrintCMDSHelp() {
			Console.WriteLine(
				"During game:\n" +
				"Save: 'save' or 'save' (Saving mid game)\n" +
				"Quit: 'quit' or 'q' (Will lead to save and then quit)\n\n" +
				"Combat-related:\n" +
				"Attack: 'attack + [ATTACKTYPE]' (Physical or magical, if nothing => physical attack)\n" +
				"[ATTACKTYPE] = 'physical' or 'magical' (or 'm')\n" +
				"Escape: 'escape' or 'esc' (Escape from enemy, restores your health.)\n\n" +
				"Leveling: 'level + [STAT]' (Levels up your specific stat with something between 1 and 5)\n" +
				"[STAT] = 'strength', 'mana', 'durability', 'agility'\n");
		}

		#endregion

		#region Text Changes

		/// <summary>
		/// Method responsible of printing out strings with a different text color.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="color"></param>
		/// <remarks>
		/// This method is able to handle numerical values as input, because this is an overloaded method.
		/// </remarks>
		public void PrintColoredText(object text, ConsoleColor color) {
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ResetColor();
		}
		/// <summary>
		/// Prints intergers with a different text color.
		/// </summary>
		/// <param name="number"></param>
		/// <param name="color"></param>
		public void PrintColoredText(int number, ConsoleColor color) {
			PrintColoredText(number.ToString(), color);
		}
		/// <summary>
		/// Prints doubles with a different text color.
		/// </summary>
		/// <param name="number"></param>
		/// <param name="color"></param>
		public void PrintColoredText(double number, ConsoleColor color) {
			PrintColoredText(number.ToString(), color);
		}

		#endregion

		#region During Game

		/// <summary>
		/// Method responsible of printing out what mob appears alongside how much HP User has and mob has.
		/// </summary>
		/// <param name="user"></param>
		/// <param name="entity"></param>
		public void PrintNewMobAppearance(User user, Entity entity) {
			Console.Write($"Entering combat!\nTake heed ");
			PrintColoredText(user.UserName, Program.UserColor);
			Console.Write(", a hostile ");
			PrintColoredText(entity.MobName, Program.EnemyColor);
			Console.Write(" has appeared!\nYou have ");
			PrintColoredText(user.HitPoints, Program.UserHealthColor);
			Console.Write("HP!\nThe ");
			PrintColoredText(entity.MobName, Program.EnemyColor);
			Console.Write(" has ");
			PrintColoredText(entity.GetDurability(), Program.EnemyHealthColor);
			Console.Write("HP!\n");
		}
		/// <summary>
		/// Method responsible of printing out the health of User and Mob after each round.
		/// </summary>
		/// <param name="user"></param>
		/// <param name="entity"></param>
		public void PrintAfterRound(User user, Entity entity) {
			PrintColoredText(user.UserName, Program.UserColor);
			Console.Write(" has ");
			PrintColoredText(user.HitPoints, Program.UserHealthColor);
			Console.Write("HP!\nThe ");
			PrintColoredText(entity.MobName, Program.EnemyColor);
			Console.Write(" has ");
			PrintColoredText(entity.GetDurability(), Program.EnemyHealthColor);
			Console.Write("HP!\n");
		}
		/// <summary>
		/// Method responsible of printing damage inflicted
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="attackType"></param>
		public void PrintDamage(Entity entity, string attackType) {
			if (attackType == "physical") {
				PrintColoredText(entity.MobName, Program.EnemyColor);
				Console.Write(" has attacked!\nInflicted ");
				PrintColoredText(entity.Strength, Program.DamageColor);
				Console.Write(" damage!\n");
			} else if (attackType == "magical") {
				PrintColoredText(entity.MobName, Program.EnemyColor);
				Console.Write(" has attacked!\nInflicted ");
				PrintColoredText(entity.Mana, Program.DamageColor);
				Console.Write(" damage!\n");
			}
		}

		#endregion

	}
}
