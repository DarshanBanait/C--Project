using GameStore.DTOS;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDTO> games = [
    new (
        1,
        "Assassin's Creed",
        "Action",
        59.99m,
        new DateOnly(2021, 10, 12)
    ),
    new (
        2,
        "FIFA 22",
        "Sports",
        69.99m,
        new DateOnly(2021, 10, 1)
    ),
    new (
        3,
        "Forza Horizon 5",
        "Racing",
        79.99m,
        new DateOnly(2021, 11, 9)
    ),
    new (
        4,
        "Red Dead Redemption 2",
        "Action",
        99.99m,
        new DateOnly(2021, 10, 12)
    ),
    new (
        5,
        "Grand Theft Auto V",
        "Action",
        129.99m,
        new DateOnly(2021, 10, 12)
    )
];

// GET /games
app.MapGet("/games", () => games);

//GET /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName("GetGameById");

// POST /games
app.MapPost("/games", (CreateGameDTO newgame) => {
    GameDTO game = new 
    (
        games.Count + 1,
        newgame.Name,
        newgame.Genre,
        newgame.Price,
        newgame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
});

// PUT /games/1
app.MapPut("/games/{id}", (int id, UpdateGameDTO updatedgame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    games[index] = new GameDTO
    (
        id,
        updatedgame.Name,
        updatedgame.Genre,
        updatedgame.Price,
        updatedgame.ReleaseDate
    );

    return Results.NoContent();
}); 

// DELETE /games/1
app.MapDelete("/games/{id}", (int id) => {
    GameDTO game = games.Find(game => game.Id == id);
    games.Remove(game);

    return Results.NoContent();
});

app.Run();
