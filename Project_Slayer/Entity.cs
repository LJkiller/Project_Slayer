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
		// __________
		//(👍 ͡❛ ▭ ͡❛)👍 En(tit)y
		protected string mobName;

		protected int strength;
		protected int mana;
		protected int durability;
		protected int agility;

		public Entity(string initialMobName, int initialStrength, int initialMana, int initialDurability, int initialAgility) {

		}
		public void Draw() {

		}
	}
}

//  ╱|、
// (` -7
//  |、⁻〵
//  じしˍ,)ノ