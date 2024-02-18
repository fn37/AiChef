
using AiChef.Server.Services;
using AiChef.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using AiChef.Server.Data;

namespace AiChef.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IOpenAIAPI _openAIservice;

        public RecipeController(IOpenAIAPI openAIservice)
        {
            _openAIservice = openAIservice;
        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
        {

            string mealtime = recipeParms.MealTime;
            List<string> ingredients = recipeParms.Ingredients.Where(x => !string.IsNullOrEmpty(x.Description)).Select(x => x.Description).ToList();

            if (string.IsNullOrEmpty(mealtime))
            {
                mealtime = "Breakfast";
            }

            var ideas = await _openAIservice.CreateRecipeIdeas(mealtime, ingredients);
            return ideas;
            //return SampleData.RecipeIdeas;
        }


        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe?>> GetRecipe(RecipeParms recipeParms)
        {
            //return SampleData.Recipe - testing;
            //API CALL

            List<string> ingredients = recipeParms.Ingredients
                                                  .Where(x => !string.IsNullOrEmpty(x.Description))
                                                  .Select(x => x.Description)
                                                  .ToList();
            string? title = recipeParms.SelectedIdea;

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }

            //call service method

            var recipe = await _openAIservice.CreateRecipe(title, ingredients);
            return recipe;


        }

        [HttpGet, Route("GetRecipeImage")]
        public async Task<RecipeImage> GetRecipeImage(string title)
        {
            //return SampleData.RecipeImage; - sample image for testing

            var recipeImage = await _openAIservice.CreateRecipeImage(title);

            return recipeImage ?? SampleData.RecipeImage; //default image if no image
        }
    }
}




//all endpoints