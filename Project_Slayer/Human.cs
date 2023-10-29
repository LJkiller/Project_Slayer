using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Slayer {

    /// <summary>
    /// Represents base data for Human Class.
    /// </summary>
	class Human : Mob {

        #region SetUp
        //To initialize different classes to access methods.
        User emptyUser = new User("");
        #endregion

        #region Race Attributes

        /// <summary>
        /// The Mob's coin drop value.
        /// </summary>
        public double CoinDrop {
            get { return coinDrop; }
            set {
                coinDrop = rng.Next(minDropStat, maxDropStat);
            }
        }
        /// <summary>
        /// The Mob's exp drop value.
        /// </summary>
        public double ExpDrop {
            get { return expDrop; }
            set {
                expDrop = rng.Next(minDropStat, maxDropStat);
            }
        }

        /// <summary>
        /// The Mob's Hit Points (Health, HP).
        /// </summary>
        public int HitPoints {
            get { return base.Durability; }
            set {
                if (value > 0) {
                    base.Durability = value;
                } else {
                    End(true, null);
                }
            }
        }

        #endregion

        #region Information & Initiator

        /// <summary>
        /// Initializes new instance of Human class.
        /// </summary>
        public Human() {
            MobName = "Human";
            Random rng = new Random();

            Strength = rng.Next(minStat, maxStat);
            Mana = rng.Next(minStat, maxStat);
            Durability = rng.Next((int)(minStat * 10), (int)(maxStat * 10));
            Agility = rng.Next(minStat, maxStat); 

            CoinDrop = rng.Next(minDropStat, maxDropStat);
            ExpDrop = rng.Next(minDropStat, maxDropStat);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method responsible of Human's death.
        /// </summary>
		public override void End(bool dead, User user) {
			base.End(dead, user);
            user.Exp += (int)Math.Round(ExpDrop);
            user.Coins += (int)Math.Round(CoinDrop);
        }

		#endregion

	}
}