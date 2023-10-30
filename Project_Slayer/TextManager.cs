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
				"Each entity you SLAY will let you traverse the tower floor level.\n" +
				"Once you've explored the entirety of current floor by killing 10 entities.\n" +
				"You will feel an uexplainable phenomenom that will decide your new peak level.\n" +
				$"There are currently {Program.availableFloors} floors available as in this version ({Program.gameVersion}).\n" +
				$"Floor 0 to {Program.availableFloors-1}.\n");
		}

		/// <summary>
		/// Displayes the game's commands.
		/// </summary>
		public void PrintCMDSHelp() {
			Console.WriteLine(
				"During game:\n" +
				"Save: 'save' (Saving mid game, consumes health.)\n" +
				"Quit: 'quit' or 'q' (Will lead to save and then quit)\n\n" +
				"Combat-related:\n" +
				"Attack: 'attack + [ATTACKTYPE]' (Physical or magical, if nothing => physical attack)\n" +
				"[ATTACKTYPE] = 'physical' or 'magical' (or 'm')\n" +
				"Dodge: 'dodge' or 'dg' (dodges the enemy's attack, neither user nor enemy take damage).\n" +
				"Escape: 'escape' or 'esc' (Escape from enemy, restores your health.)\n");
		}

		#endregion

		#region Text Changes

		/// <summary>
		/// Method responsible of printing out strings with a different text color.
		/// </summary>
		/// <param name="text">String to be printed.</param>
		/// <param name="color">The color of the text.</param>
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
		/// <param name="number">Int to be printed.</param>
		/// <param name="color">The color of the number.</param>
		public void PrintColoredText(int number, ConsoleColor color) {
			PrintColoredText(number.ToString(), color);
		}
		/// <summary>
		/// Prints doubles with a different text color.
		/// </summary>
		/// <param name="number">Double to be printed.</param>
		/// <param name="color">The color of the number.</param>
		public void PrintColoredText(double number, ConsoleColor color) {
			PrintColoredText(number.ToString(), color);
		}

		#endregion

		#region During Game

		/// <summary>
		/// Method responsible of printing out what mob appears alongside how much HP User has and mob has.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="entity">The Entity object to be handled in the method.</param>
		public void PrintNewMobAppearance(User user, Entity entity) {
			Console.Write($"Entering combat!\nTake heed ");
			PrintColoredText(user.UserName, Program.UserColor);
			Console.Write(", a hostile ");
			PrintColoredText(entity.GetMobName(), Program.EnemyColor);
			Console.Write(" has appeared!\nYou have ");
			PrintColoredText(user.HitPoints, Program.UserHealthColor);
			Console.Write("HP!\nThe ");
			PrintColoredText(entity.GetMobName(), Program.EnemyColor);
			Console.Write(" has ");
			PrintColoredText(entity.GetDurability(), Program.EnemyHealthColor);
			Console.Write("HP!\n");
		}
		/// <summary>
		/// Method responsible of printing out the health of User and Mob after each round.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="entity">The Entity object to be handled in the method.</param>
		public void PrintAfterRound(User user, Entity entity) {
			PrintColoredText(user.UserName, Program.UserColor);
			Console.Write(" has ");
			PrintColoredText(user.HitPoints, Program.UserHealthColor);
			Console.Write("HP!\nThe ");
			PrintColoredText(entity.GetMobName(), Program.EnemyColor);
			Console.Write(" has ");
			PrintColoredText(entity.GetDurability(), Program.EnemyHealthColor);
			Console.Write("HP!\n");
		}
		/// <summary>
		/// Method responsible of printing damage inflicted.
		/// </summary>
		/// <param name="entity">The Entity object to be handled in the method.</param>
		/// <param name="attackType">String to be compared of what attack is executed.</param>
		public void PrintDamage(Entity entity, string attackType) {
			if (attackType == "physical") {
				PrintColoredText(entity.GetMobName(), Program.EnemyColor);
				Console.Write(" has attacked!\nInflicted ");
				PrintColoredText(entity.GetStrength(), Program.DamageColor);
				Console.Write(" damage!\n");
			} else if (attackType == "magical") {
				PrintColoredText(entity.GetMobName(), Program.EnemyColor);
				Console.Write(" has attacked!\nInflicted ");
				PrintColoredText(entity.GetMana(), Program.DamageColor);
				Console.Write(" damage!\n");
			}
		}

		/// <summary>
		/// Method responsible of printing out what the User gets after killing an opponent.
		/// </summary>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="entity">The Entity object to be handled in the method.</param>
		public void PrintLoot(User user, Entity entity) {
			Console.Write("You've conquered the ");
			PrintColoredText(entity.GetMobName(), Program.EnemyColor);
			Console.Write("! You've earned ");
			user.Coins += entity.GetMobCoinDrop();
			user.Exp += entity.GetMobExpDrop();
			PrintColoredText($"{entity.GetMobCoinDrop()} Coins", Program.CoinColor);
			Console.Write(" and ");
			PrintColoredText($"{entity.GetMobExpDrop()} XP", Program.ExpColor);
			Console.Write("!\n");
		}

		#endregion

	}
}
