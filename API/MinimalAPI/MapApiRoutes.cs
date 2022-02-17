using API.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.MinimalAPI;

public static class ApiEndpoints
{
  public static IEndpointRouteBuilder MapApiRoutes(this IEndpointRouteBuilder app)
  {
// MINIMAL API TEST
    app.MapGet("/tester", async (AppDbContext db) => await db.Users.ToListAsync())
      .Produces<List<ApplicationUser>>(StatusCodes.Status200OK)
      .WithName("GetTest")
      .WithTags("Tests");


    app.MapGet("/testerOne/{query}", (string query, [FromServices] AppDbContext db) => Results.Ok(query))
      .Produces<string>(StatusCodes.Status200OK)
      .WithName("TestWithQueryOne")
      .WithTags("Tests");

    app.MapGet("/tester/{query}", (string query, AppDbContext db) => Results.Ok(query))
      .Produces<string>(StatusCodes.Status200OK)
      .WithName("TestWithQuery")
      .WithTags("Tests")
      .ExcludeFromDescription(); //Removes from Swagger description

    app.MapPost("/tester", ([FromQuery] int num, string name) =>
      {
        if (string.IsNullOrEmpty(name))
        {
          return Results.Problem("No name added", statusCode: StatusCodes.Status400BadRequest);
        }


        return Results.Ok(name);
      })
      .Produces(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .RequireAuthorization();

    app.MapGet("/testerz/{num:int}/{name}", (int num, string name) =>
      {
        if (string.IsNullOrEmpty(name))
        {
          return Results.Problem("No name added", statusCode: StatusCodes.Status400BadRequest);
        }

        var req = new HttpContextAccessor();
        Console.WriteLine(req.HttpContext?.Request.RouteValues.Values);


        return Results.Ok(new { name = name, num = num });
      })
      .Produces(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .RequireAuthorization();
    return app;
  }
}