namespace GameStore.API.Dtos;

public record CreateGameDtos(
    string Title,
    string Genre,
    decimal Price,
    DateTime ReleaseDate
);

