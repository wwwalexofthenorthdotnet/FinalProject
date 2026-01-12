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
        const int strength = 10;
        const int speed = 10;

        public static int currentStrength = strength;

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
