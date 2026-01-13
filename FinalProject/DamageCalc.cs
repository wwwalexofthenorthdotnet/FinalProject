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

        //Player Base Stats
        public const int playerHealth = 50;
        public const int playerStrength = 10;
        public const int playerSpeed = 10;

        //Enemy Base Stats
        public const int enemyHealth = 25;
        public const int enemyStrength = 10;
        public const int enemySpeed = 10;

        public static int currentStrength = playerStrength;

        public enum Weapon
        {
            None = 0,
        }

        public static Weapon equippedWeapon = Weapon.None;


        public static int playerMelee(int playerDamageOutput)
        {
            playerDamageOutput = currentStrength / 2 + (int)equippedWeapon;
            return playerDamageOutput;
        }
    }
}
