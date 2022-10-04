namespace BingsuTycoon.Common
{
    public enum Ingredient
    {
        Milk,
        RedBean,
        StrawberrySyrup,
        ChocolateSyrup,
        Strawberry,
        Berry,
        Pineapple,
        Mango,
        CheeseCube,
        IceCream
    }

    public class Recipe
    {
        public int IceCount { get; set; }
        public bool NeedSyrup { get; set; }

        public Ingredient[] Included { get; set; }
        public Ingredient[] Excluded { get; set; }

        public Recipe(int iceCount, bool needSyrup, Ingredient[] included, Ingredient[] excluded)
        {
            IceCount = iceCount;
            NeedSyrup = needSyrup;
            Included = included;
            Excluded = excluded;
        }

        public int GetWrongNumber(Ingredients ingredients)
        {
            int result = 0;

            if (ingredients.IceCount <= 0) return 5;

            if (IceCount != ingredients.IceCount) result++;

            foreach (var item in Included)
            {
                if (ingredients.GetIngredient(item) == false) result++;
            }

            foreach (var item in Excluded)
            {
                if (ingredients.GetIngredient(item) == true) result++;
            }

            return result;
        }
    }
}