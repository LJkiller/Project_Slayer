using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	//⠀   ⠀   (\__/)
    //        (•ㅅ•)      Don’t talk to
	//	   ＿ノヽ ノ＼＿      me or my son
	//	`/　`/ ⌒Ｙ⌒ Ｙ ヽ     ever again.
	//  ( ( (三ヽ人 /　  |
	//	|　ﾉ⌒＼ ￣￣ヽ ノ
	//	ヽ＿＿＿＞､＿_／
	//       ｜(王 ﾉ〈  (\__/)
	//       /ﾐ`ー―彡\  (•ㅅ•)
	//      / ╰    ╯ \ /    \>



	/// <summary>
	/// Represents the base data for any Entity.
	/// </summary>
	public abstract class Entity : IDrawable {
		//random number generator: rng
		protected Random rng = new Random();

		// __________
		//(👍 ͡❛ ▭ ͡❛)👍 En(tit)y
		protected string mobName;

		protected int strength;
		protected int mana;
		protected int durability;
		protected int agility;

		//Mob and User stats for rng usage in inherited classes (ex Human).
		//Use this as base stat, then calculate the values for mobs and user.
		//(User spawns with rng stats)
		protected int minStat = 5;
		protected int maxStat = 10;

		public Entity(string initialMobName, int initialStrength, int initialMana, int initialDurability, int initialAgility) {
			mobName = initialMobName;
			strength = initialStrength;
			mana = initialMana;
			durability = initialDurability;
			agility = initialAgility;
		}
		public void Draw() {

		}
		/// <summary>
		/// Displays the information of an Entity.
		/// Entity, Strength, Mana, Durability, Agility.
		/// </summary>
		public virtual void DisplayInfo() {
			Console.WriteLine($"Entity: {mobName}");
			Console.WriteLine($"Strength: {strength}, Mana: {mana}, Durability: {durability}, Agility: {agility}");
		}
	}
}

//   ╱|、
//  (` -7
//  |、⁻〵
//  じしˍ,)ノ