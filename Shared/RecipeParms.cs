using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiChef.Shared
{
    public class RecipeParms
    {
        //server backend  - sending this to WebAPI

        public string? MealTime { get; set; } = "Breakfast";
        public List<Ingredient> Ingredients { get; set; } = new();

        public string? SelectedIdea { get; set; }
    }

}
