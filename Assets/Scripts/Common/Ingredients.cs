using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.Common
{
    public class Ingredients
    {
        public int IceCount { get; set; } = 0;
        public bool Milk { get; set; } = false;
        public bool RedBean { get; set; } = false;
        public bool StrawberrySyrup { get; set; } = false;
        public bool ChocolateSyrup { get; set; } = false;
        public bool Strawberry { get; set; } = false;
        public bool Berry { get; set; } = false;
        public bool Pineapple { get; set; } = false;
        public bool Mango { get; set; } = false;
        public bool CheeseCube { get; set; } = false;
        public bool IceCream { get; set; } = false;

        public bool GetIngredient(Ingredient ingredient)
        {
            switch (ingredient)
            {
                case Ingredient.Milk:
                    return Milk;
                case Ingredient.RedBean:
                    return RedBean;
                case Ingredient.StrawberrySyrup:
                    return StrawberrySyrup;
                case Ingredient.ChocolateSyrup:
                    return ChocolateSyrup;
                case Ingredient.Strawberry:
                    return Strawberry;
                case Ingredient.Berry:
                    return Berry;
                case Ingredient.Pineapple:
                    return Pineapple;
                case Ingredient.Mango:
                    return Mango;
                case Ingredient.CheeseCube:
                    return CheeseCube;
                case Ingredient.IceCream:
                    return IceCream;
                default:
                    break;
            }

            return Milk;
        }
    }
}