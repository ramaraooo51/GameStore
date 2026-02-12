namespace GameStore.API.Dtos;

public record GameDto(
    int Id,
    string Title,
    string Genre,
    decimal Price,
    DateTime ReleaseDate
)
{
    private int v;
    private string name;
    private DateOnly releaseDate;

    public GameDto(int v, string name, string genre, decimal price, DateOnly releaseDate)
    {
        this.v = v;
        this.name = name;
        Genre = genre;
        Price = price;
        this.releaseDate = releaseDate;
    }
}