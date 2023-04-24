using Dapper;
using Images_Demo.Models;
using System.Data;

namespace Images_Demo;

public class ImageRepository : IImageRepository
{
    private readonly IDbConnection _conn;

    public ImageRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Picture> GetAllPictures()
    {
        return _conn.Query<Picture>("SELECT * FROM images;");
    }

    public void InsertPicture(Picture picture)
    {
        _conn.Execute("INSERT INTO images (Name, Image) VALUES (@name, @image);", 
            new {name = picture.Name, image = picture.Image});
    }
}
