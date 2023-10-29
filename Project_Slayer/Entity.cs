using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
	/// Represents the base data for Entity Class.
	/// </summary>
	public abstract class Entity : IDrawable {
		// __________
		//(👍 ͡❛ ▭ ͡❛)👍 En(tit)y

		#region Setup 
		//To initialize different classes to access methods.
		TextManager textManager = new TextManager();
		#endregion

		#region RNG
		//Mob and User stats for rng usage in inherited classes (ex Human).
		//Use this as base stat, then calculate the values for mobs and user.
		//(User spawns with rng stats)
		protected int minStat = 5;
		protected int maxStat = 10;
		protected static Random rng = new Random();
		#endregion

		#region Entity Attributes

		[JsonIgnore]
		public string mobName { get; protected set; }
		[JsonIgnore]
		public int strength { get; protected set; }
		[JsonIgnore]
		public int mana { get; protected set; }
		protected int durability { get; set; }
		[JsonIgnore]
		public int agility { get; protected set; }

		/// <summary>
		/// Method responsible of getting durability.
		/// </summary>
		/// <returns></returns>
		public int GetDurability() {
			return durability;
		}
		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of an Entity.
		/// Entity, Strength, Mana, Durability, Agility.
		/// </summary>
		public virtual void DisplayInfo() {
			Console.WriteLine($"{strength,21}: Strength");
			Console.WriteLine($"{mana,21}: Mana");
			Console.WriteLine($"{durability,21}: Durability");
			Console.WriteLine($"{agility,21}: Agility");
		}

		/// <summary>
		/// Initializes new instance of Entity class.
		/// </summary>
		public Entity() {

		}

		#endregion

		#region Methods

		/// <summary>
		/// Method responsible of rendering the Entity in the game.
		/// A "Square".
		/// </summary>
		public void Draw() {
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					Console.Write('*');
				}
				Console.WriteLine();
			}
		}

		/// Attacks opponent and inflicts damage. 
		/// Damage is scaled by Strength or Mana.
		/// </summary>
		/// <param name="attackType"></param>
		public virtual void Attack(string attackType, User user, Entity entity) {
			if (attackType == "physical") {
				user.HitPoints -= (int)Math.Round((double)entity.strength);
				textManager.PrintDamage(entity, attackType);
			} else if (attackType == "magical") {
				user.HitPoints -= (int)Math.Round((double)entity.mana);
				textManager.PrintDamage(entity, attackType);
			}
		}

		/// <summary>
		/// Method responsible of an entity's death.
		/// </summary>
		public abstract void End(bool dead);
		#endregion

	}
}

//   ╱|、
//  (` -7
//   |、⁻〵
//   じしˍ,)ノ