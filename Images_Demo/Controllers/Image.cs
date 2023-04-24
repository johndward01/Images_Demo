using Images_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Images_Demo.Controllers;
public class Image : Controller
{
    private readonly IImageRepository _imageRepo;

    public Image(IImageRepository imageRepository)
    {
        _imageRepo = imageRepository;
    }

    public IActionResult Index()
    {
        var pictures = _imageRepo.GetAllPictures();
        return View(pictures);
    }

    [HttpGet]
    public IActionResult Upload()
    {
        var model = new ImageViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Upload(ImageViewModel model)
    {
        byte[]? data = null;
        using (var ms = new MemoryStream())
        {
            model.Data.CopyToAsync(ms);
            data = ms.ToArray();
        }

        var picture = new Picture()
        {
            Name = model.Name,
            Image = data
        };

        _imageRepo.InsertPicture(picture);

        return RedirectToAction("Index", "Image");
    }


}
