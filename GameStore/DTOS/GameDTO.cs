namespace GameStore.DTOS;

public record class GameDTO
(int Id,
string Name,
string Genre,
decimal price,
DateOnly ReleaseDate);

