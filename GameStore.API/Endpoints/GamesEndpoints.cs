using System.ComponentModel.DataAnnotations;
using GameStore.API.Dtos;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";

    private static readonly List<Dtos.GameDto> Games = [
        new (
            1,
            "The Legend of Zelda: Breath of the Wild",
            "Action-Adventure",
            59.99m,
            new DateOnly(2017, 3, 3)            
        ),
        new (
            2,
            "God of War",
            "Action-Adventure",
            49.99m,
            new DateOnly(2018, 4, 20)            
        ),
        new (
            3,
            "Red Dead Redemption 2",
            "Action-Adventure",
            39.99m,
            new DateOnly(2018, 10, 26)            
        )
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");
        group.MapGet("/", () => Games);

        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = Games.FirstOrDefault(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameEndpointName);


        group.MapPost("/", (CreateGameDtos newGame) =>
        {
           GameDto game = new (
                Games.Max(game => game.Id) + 1,
                newGame.Title,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);
                
            Games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });
        
        group.MapPut("/{id}", (int id, CreateGameDtos updatedGame) =>
        {
            var index = Games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            Games[index] = new GameDto(
                id,
                updatedGame.Title,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );      

            return Results.NoContent();


        });
        
        group.MapDelete("/{id}", (int id) =>
        {
            var index = Games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            Games.RemoveAt(index);

            return Results.NoContent();
        ;
    });

        return group;
    }


    public record CreateGameDtos(
        [Required] string Title,
        [Required] string Genre,
        [Required] decimal Price,
        DateOnly ReleaseDate 
    );
}
