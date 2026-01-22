using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{ 

    internal static class DamageCalc
    {

        private static Random generator = new Random();

        //Player Base Stats
        public const int playerHealth = 30;
        public const int playerStrength = 10;
        public const int playerSpeed = 10;

        //Enemy Base Stats
        public const int enemyHealth = 25;
        public const int enemyStrength = 10;
        public const int enemySpeed = 10;

        public static int currentPlayerStrength = playerStrength;


        public enum Weapon
        {
            None = 0,
            knightSword = 2,
        }

        public static Weapon equippedWeapon = Weapon.None;
        public static Weapon enemyWeapon = Weapon.knightSword;



        public static int PlayerMelee(int damageOutput)
        {
            damageOutput = generator.Next(1, currentPlayerStrength) + (int)equippedWeapon;
            return damageOutput;
        }

        public static int KnightMelee(int damageOutput)
        {
            damageOutput = generator.Next(2, enemyStrength) + (int)equippedWeapon;
            return damageOutput;
        }
    }
}
