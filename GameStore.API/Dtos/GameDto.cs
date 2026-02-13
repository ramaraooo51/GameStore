namespace GameStore.API.Dtos;

public record GameDto
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public string Genre { get; init; } = "";
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }

    public GameDto(int id, string title, string genre, decimal price, DateOnly releaseDate)
        => (Id, Title, Genre, Price, ReleaseDate) = (id, title, genre, price, releaseDate);
}
