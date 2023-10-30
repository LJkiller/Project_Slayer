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
        /// The Mob's race-name (Name).
        /// </summary>
        public string MobName {
            get { return base.mobName; }
            set {
                base.mobName = "Human";
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
            get { return base.strength; }
            set {
                base.strength = rng.Next(minStat, maxStat);
            }
        }
        /// <summary>
        /// The Mob's mana stat (Magical Attack Power).
        /// </summary>
        public double Mana {
            get { return base.mana; }
            set {
                base.mana = rng.Next(minStat, maxStat);
            }
        }
        /// <summary>
        /// The Mob's durability stat (Maximum Hits Points).
        /// </summary>
        public double Durability {
            get { return base.durability; }
            set {
                base.durability = rng.Next((int)(minStat * 10), (int)(maxStat * 10));
                if (value > 0) {
                    durability = (int)value;
                } else {
                    End(true);
                }
            }
        }
        /// <summary>
        /// The Mob's agility stat.
        /// </summary>
        public double Agility {
            get { return base.agility; }
            set {
                base.agility = rng.Next(minStat, maxStat);
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
        /// Method responsible of Human's death.
        /// </summary>
        public override void End(bool isDead) {
            base.End(isDead);
            if (isDead) {
                int experienceGained = (int)Math.Round(GetExpDrop());
                int coinsGained = (int)Math.Round(GetCoinDrop());
                emptyUser.Exp += experienceGained;
                emptyUser.Coins += coinsGained;
            }
        }

        #endregion

    }
}