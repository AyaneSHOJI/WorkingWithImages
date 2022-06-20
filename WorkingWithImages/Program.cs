using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Reflection;
using static System.Console;

string imagesFolder = Path.Combine(Environment.CurrentDirectory, "images");
string path = AppDomain.CurrentDomain.BaseDirectory;
string dir = Environment.CurrentDirectory;
string? dir2 = Directory.GetParent(dir).Parent.FullName;
string? dir3 = Directory.GetParent(dir).Parent.Parent.FullName;
string? pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);

foreach(string imagePath in images)
{
    string thumbnailPath = Path.Combine(Environment.CurrentDirectory, "../../../images", Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));
    
    using (Image image = Image.Load(imagePath))
    {
        image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
        image.Mutate(x => x.Grayscale());
        image.Save(thumbnailPath);
    }
}
WriteLine("Image processsing complete. View the image folder.");
