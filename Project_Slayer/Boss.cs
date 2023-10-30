using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠤⠴⠒⠒⠒⠲⠤⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣚⡉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠲⢄⡀⠀⠀⠀⠀
	//⣶⡀⠀⠀⢀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠖⠋⠉⠁⠀⠈⠉⠉⠉⠓⠒⠤⣄⠀⠀⠀⠀⠀⠀⠀⠙⢦⡀⠀⠀
	//⠘⢷⣶⡾⠿⠭⣙⠻⢶⣄⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⠀⠀⠀⠀⠀⠀⠀⠱⡄⠀
	//⠀⠀⠀⠀⠀⠀⠀⠙⣄⠙⡆⠀⠀⠀⠀⠀⠀⠈⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠀⠀⠀⠀⠀⠀⠀⠀⢹⡀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠘⡆⢹⡀⠀⠀⠀⠀⢀⠞⠁⠈⠑⠢⠤⣀⣀⡀⠀⠀⠀⠀⣀⠴⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡀⢳⠀⠀⠀⢠⣯⢴⣶⣖⣺⣿⢲⣦⡬⣍⡉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⣈⢧⡀⠀⠸⣷⣾⣡⣿⣇⣼⣏⣨⡷⢛⣯⠿⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠷⣯⣓⠂⣼⡿⢷⣾⣉⣀⣉⠉⠳⠟⣿⠴⡿⢻⠷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠃
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⣻⣷⣶⠤⣄⠀⠉⠙⣲⢄⠀⠀⠻⣿⣿⣿⡜⣷⠀⠀⠀⠀⠀⠀⠀⢠⣇⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣴⣿⣿⣿⠀⠀⠉⠲⣤⣼⣾⣷⡄⠀⠈⠁⢈⣇⣁⠀⠀⠀⠀⠀⠀⣰⠋⠈⣳
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣾⡟⠻⣿⡿⣆⢀⣄⢀⣼⠿⣟⠛⠛⡄⠀⠀⣸⡏⣹⠀⠀⠀⠀⢀⡴⠁⠀⣰⠏
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠛⣦⡙⠒⠻⣄⡽⡏⣻⡟⢻⣿⢻⣤⠻⣿⣾⣿⣿⢁⣿⡆⠀⠀⣠⡞⠁⢀⣾⠋⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠈⠛⠿⠶⣾⣤⣿⣧⣟⣎⣉⣉⢙⣶⣿⣿⡿⠹⣾⣿⣿⡆⠀⢻⠀⢠⡿⠁⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠛⠛⠋⠉⠁⠀⠀⠀⠀⠛⠛⠃⢰⠋⠀⣾⠁⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠘⠁⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⢀⡟⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠙⠲⢤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡟⠁⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠉⢹⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀
	//⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠈⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⢱⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀Sus.
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠀⢸⡄⠀⠘⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠤⣀⡀⠀⠀⠀⣀⡼⠁⠀⠀⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠀⠀⠀⠀⠀⠈⢧⡀⠀⠀⠀⠀⠀⣠⠞⠁⠀⠀⠀⠀⠀⠀
	//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀

	/// <summary>
	/// Easier pathway to understand the code structure.
	/// </summary>
	public class Boss : Mob {

		#region SetUp
		//To initialize an emptyUser to access methods.
		User emptyUser = new User("");
		#endregion

		/// <summary>
		/// Initializes new instance of Boss class.
		/// </summary>
		public Boss() {

		}

		/// <summary>
		/// Method responsible of a Boss's End.
		/// </summary>
		/// <param name="dead">Bool to compare if the Boss has died.</param>
		/// <param name="isDead">Bool to compare if Goblin has died.</param>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <param name="fileManager">The FileManager object to be transfering information.</param>
		public override void End(bool dead = false, User user = null, FileManager fileManager = null) {
			if (dead == true) {
				emptyUser.BossSlain();
			}
		}
	
	}
}
