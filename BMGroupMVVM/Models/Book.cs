using System.Windows.Media;

namespace BMGroupMVVM.Models
{
    public class Book : IBook
    {
        public Book() { }

        public Book(ImageSource image, string name, string author)
        {
            Image = image;
            Name = name;
            Author = author;
        }

        public ImageSource Image { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
