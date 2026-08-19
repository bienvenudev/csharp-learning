class Program
{
  // Initial method to load recipe details
  public static async Task LoadRecipeDetailsAsync(Recipe recipe, CancellationToken cancellationToken = default)
  {
    Console.WriteLine($"Loading details for {recipe}...");

    Task<List<string>> ingredientsTask = RecipeAPI.GetIngredientsAsync(recipe.Id, cancellationToken);

    Task<List<string>> instructionsTask = RecipeAPI.GetInstructionsAsync(recipe.Id, cancellationToken);

    await Task.WhenAll(ingredientsTask, instructionsTask);
    
    Console.WriteLine($"Loaded ingredients for {recipe}");
    Console.WriteLine($"Loaded instructions for {recipe}");

    recipe.Ingredients = ingredientsTask.Result;
    recipe.Instructions = instructionsTask.Result;
  }

  public static async Task<Recipe> FetchRecipeAsync(int id, CancellationToken cancellationToken = default)
  {
    Console.WriteLine($"Fetching recipe-{id}...");
    try 
    {
      Recipe result = await RecipeAPI.GetRecipeAsync(id, cancellationToken);
      Console.WriteLine($"Success fetching recipe-{id}...");
      return result;
    }
    catch(Exception e)
    {
      Console.WriteLine(e.Message);

      return new Recipe();
    }
  }

  public static async Task Main(string[] args)
  {
    Console.WriteLine("Starting Recipe Application...");

    CancellationTokenSource tokensource = new CancellationTokenSource(1000);

    int recipeId = 1;

    Task<Recipe> recipeTask = FetchRecipeAsync(recipeId, tokensource.Token);

    try
    {
      Recipe recipe = await recipeTask;
      Console.WriteLine(recipeTask.Result);
    }
    catch (Exception e)
    {
      Console.WriteLine($"Recipe {recipeId} fetch was canceled");
      Console.WriteLine(e.Message);
    }

    try
    {
      Recipe recipe = await recipeTask;
      await LoadRecipeDetailsAsync(recipe, tokensource.Token);
      recipe.Display();
    }
    catch (Exception e)
    {
      Console.WriteLine($"Loading details for recipe {recipeId} was cancelled");
      Console.WriteLine(e.Message);
    }

    int recipeId2 = 2;

    Task<Recipe> recipeTask2 = FetchRecipeAsync(recipeId2, tokensource.Token);

    try
    {
      Recipe recipe = await recipeTask2;
      await LoadRecipeDetailsAsync(recipe, tokensource.Token);
      recipe.Display();
    }
    catch (Exception e)
    {
      Console.WriteLine($"Loading details for recipe {recipeId2} was cancelled");
      Console.WriteLine(e.Message);
    }

  }
}