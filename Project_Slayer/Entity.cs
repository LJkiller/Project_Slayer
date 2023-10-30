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
	public abstract class Entity {
		// __________
		//(👍 ͡❛ ▭ ͡❛)👍 En(tit)y

		#region Setup 
		//To initialize different classes to access methods.
		TextManager textManager = new TextManager();
		private Mob mobInstance;

		/// <summary>
		/// Gets or sets the associated Mob instance for this Entity.
		/// </summary>
		public Mob MobInstance {
			get { return mobInstance; }
			set { mobInstance = value; }
		}
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

		protected string mobName;
		protected int strength;
		protected int mana;
		protected int durability;
		protected int agility;

		/// <summary>
		/// Method responsible of getting mobName.
		/// </summary>
		/// <returns>The Entity's mobName.</returns>
		public string GetMobName() {
			return mobName;
		}
		/// <summary>
		/// Method responsible of getting strength.
		/// </summary>
		/// <returns>The Entity's strength.</returns>
		public int GetStrength() {
			return strength;
		}
		/// <summary>
		/// Method responsible of getting mana.
		/// </summary>
		/// <returns>The Entity's mana.</returns>
		public int GetMana() {
			return mana;
		}
		/// <summary>
		/// Method responsible of getting durability.
		/// </summary>
		/// <returns>The Entity's durability.</returns>
		public int GetDurability() {
			return durability;
		}
		/// <summary>
		/// Method responsible of getting agility.
		/// </summary>
		/// <returns>The Entity's agility.</returns>
		public int GetAgility() {
			return agility;
		}

		/// <summary>
		/// Method responsible of lowering the enemy's health.
		/// </summary>
		/// <param name="damageIncrement">The value of the User's attack. Scaled by either 'strength' or 'mana'.</param>
		/// <returns>The new value of entity's durability/health.</returns>
		public int EnemyDamaged(int damageIncrement) {
			durability -= damageIncrement;
			return durability;
		}

		/// <summary>
		/// Method responsible of getting mob ExpDrop.
		/// </summary>
		/// <param name="mob">The Mob object to be handled in the method.</param>
		/// <returns>experience points drop value.</returns>
		public int GetMobExpDrop() {
			return mobInstance != null ? (int)mobInstance.GetExpDrop() : 0;
		}
		/// <summary>
		/// Method responsible of getting mob CoinDrop.
		/// </summary>
		/// <param name="mob">The Mob object to be handled in the method.</param>
		/// <returns>coin drop value.</returns>
		public int GetMobCoinDrop() {
			return mobInstance != null ? (int)mobInstance.GetCoinDrop() : 0;
		}

		#endregion

		#region Information & Initiator

		/// <summary>
		/// Displays the information of an Entity.
		/// Entity, Strength, Mana, Durability, Agility.
		/// </summary>
		/// <param name="admin">Bool to compare if its an admin execution.</param>
		public virtual void DisplayInfo(bool admin) {
			Console.WriteLine($"{strength,21}: Strength");
			Console.WriteLine($"{mana,21}: Mana");
			Console.WriteLine($"{durability,21}: Durability");
			Console.WriteLine($"{agility,21}: Agility");
		}

		/// <summary>
		/// Initializes new instance of Entity class.
		/// </summary>
		public Entity() {
			mobInstance = null;
		}
		/// <summary>
		/// Initializes new instance of Entity class, associated with Mob instance.
		/// </summary>
		/// <param name="mobInstance">The Mob object to associate with this Entity.</param>
		public Entity(Mob mobInstance) {
			this.mobInstance = mobInstance;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Attacks opponent and inflicts damage. 
		/// Damage is scaled by Strength or Mana.
		/// </summary>
		/// <param name="attackType">String to be compared of what attack is executed.</param>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="entity">The entity object to be handled in the method.</param>
		/// <exception cref="ArgumentException">Thrown when the attackType is not valid. Has to be either 'physical' or 'magical'.</exception>
		public virtual void Attack(string attackType, User user, Entity entity) {
			if (attackType == "physical") {
				user.HitPoints -= (int)Math.Round((double)entity.strength);
				textManager.PrintDamage(entity, attackType);
			} else if (attackType == "magical") {
				user.HitPoints -= (int)Math.Round((double)entity.mana);
				textManager.PrintDamage(entity, attackType);
			} else {
				throw new ArgumentException("Invalid attackType. The attackType must be either 'physical' or 'magical'.");
			}
		}

		/// <summary>
		/// Method responsible of an entity's death.
		/// </summary>
		/// <param name="dead">Bool to compare if the Entity is dead.</param>
		public abstract void End(bool dead = false, User user = null, FileManager fileManager = null);
		
		#endregion

	}
}

//   ╱|、
//  (` -7
//   |、⁻〵
//   じしˍ,)ノ