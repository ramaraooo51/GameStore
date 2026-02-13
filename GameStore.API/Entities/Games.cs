using System;

namespace GameStore.API.Entities;

public class Games
{
    public int Id { get; set; }
    public required string Name { get; set; }

    /*We need to define an association among name and genre */

    public int GenreId { get; set; }
    public required Genre? Genre { get; set; }

    public decimal Price { get; set; }   
    public DateTime ReleaseDate { get; set; }   

}
