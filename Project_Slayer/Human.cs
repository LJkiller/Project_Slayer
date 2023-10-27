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

		#region Race Attributes

		/// <summary>
		/// The Mob's race-name (Name).
		/// </summary>
		public string MobName {
            get { return mobName; }
            set {
                mobName = "Human";
            }
        }

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
        /// The Mob's strength stat (Physical Attack Power).
        /// </summary>
        public double Strength {
            get { return strength; }
            set {
                strength = rng.Next(minStat, maxStat);
            }
        }
        /// <summary>
        /// The Mob's mana stat (Magical Attack Power).
        /// </summary>
        public double Mana {
            get { return mana; }
            set {
                mana = rng.Next(minStat, maxStat);
            }
        }
        /// <summary>
        /// The Mob's durability stat (Maximum Hits Points).
        /// </summary>
        public double Durability {
            get { return durability; }
            set {
                durability = rng.Next((int)(minStat*10), (int)(maxStat*10));
            }
        }
        /// <summary>
        /// The Mob's agility stat.
        /// </summary>
        public double Agility {
            get { return agility; }
            set {
                agility = rng.Next(minStat, maxStat);
            }
        }

        /// <summary>
        /// The Mob's Hit Points (Health, HP).
        /// </summary>
        public double HitPoints {
            get { return Durability; }
            set {
                if (value > 0) {
                    HitPoints = value;
                } else {
                    Death();
                }
            }
        }
        #endregion

        #region Information & Initiator

        /// <summary>
        /// Default attribute holder.
        /// </summary>
        private void SetDefaultAttributes() {
            MobName = "DefaultHuman";
            CoinDrop = 0;
            ExpDrop = 0;
            Strength = 0;
            Mana = 0;
            Durability = 0;
            Agility = 0;
        }
        /// <summary>
        /// Initializes new instance of Human class.
        /// </summary>
        public Human() : base() {
            SetDefaultAttributes();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attacks opponent and inflicts damage. 
        /// Damage is scaled by Strength or Mana.
        /// </summary>
        /// <param name="attackType"></param>
        public override void Attack(string attackType = "physical") {
            Console.WriteLine($"{MobName} has attacked!\nInflicted {Strength} damage!");
		}

		#endregion

	}
}