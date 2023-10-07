using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {
	//



	/// <summary>
	/// Drawing an object.
	/// If implented to a class, class should provide the Draw() method
	/// with a visual representation.
	/// </summary>
	public interface IDrawable {
		/// <summary>
		/// Method responsible of rendering an object in the game.
		/// </summary>
		void Draw();
	}
}
