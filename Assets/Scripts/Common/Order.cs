namespace BingsuTycoon.Common
{
    public class Order
    {
        public Recipe OrderRecipe { get; set; }
        public string[] OrderTextArray { get; set; }

        public Order(Recipe recipe, string[] orderTextArray)
        {
            OrderRecipe = recipe;
            OrderTextArray = orderTextArray;
        }
    }
}