using Images_Demo.Models;

namespace Images_Demo;

public interface IImageRepository
{
    public IEnumerable<Picture> GetAllPictures();
    public void InsertPicture(Picture picture);
}
