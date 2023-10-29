using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {

	/// <summary>
	/// Easier pathway to understand the code structure.
	/// </summary>
	public class Boss : Mob {

		#region SetUp
		//To initialize an emptyUser to access methods.
		User emptyUser = new User("");
		#endregion

		/// <summary>
		/// Method responsible of a Boss's End.
		/// </summary>
		public override void End(bool dead = false) {
			if (dead == true) {
				emptyUser.BossSlain();
			} else {

			}
		}
	}
}
