using System.Windows.Media;

namespace BMGroupMVVM.Models
{
    public interface IBook
    {
        public ImageSource Image { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
