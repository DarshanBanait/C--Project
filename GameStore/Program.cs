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
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id));

app.Run();
