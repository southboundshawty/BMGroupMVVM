using BMGroupMVVM.Commands;
using BMGroupMVVM.Models;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BMGroupMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Books = new ObservableCollection<IBook>()
            {
                new Book((BitmapImage)FromResources("JohnBookImage"), "C#. Программирование для профессионалов", "Джон Скит"),
                new Book((BitmapImage)FromResources("CrlBookImage"), "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5", "Рихтер Джеффри"),
                new Book((BitmapImage)FromResources("JavaKettleBookImage"), "Java для чайников", "Барри Берд"),
                new Book((BitmapImage)FromResources("Java8BookImage"), "Java 8. Руководство для начинающих", "Герберт Шилдт"),
                new Book((BitmapImage)FromResources("JavaBegginersBookImage"), "Java для начинающих. Объектно-ориентированный подход", "Эйми Бэкил"),
                new Book((BitmapImage)FromResources("PythonBookImage"), "Изучаем Python", "Марк Луцт"),
                new Book((BitmapImage)FromResources("Python2BookImage"), "Программируем игры на Python", "Эирк Мэтиз"),
                new Book((BitmapImage)FromResources("Python3BookImage"), "Python для сложных задач", "Вандер Плас")
            };

            BooksCollectionView = CollectionViewSource.GetDefaultView(Books);
        }

        #region Properties

        private ICollectionView booksCollectionView;

        public ICollectionView BooksCollectionView
        {
            get => booksCollectionView;
            set
            {
                booksCollectionView = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IBook> books;

        public ObservableCollection<IBook> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }

        private string filterText;

        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand booksFilterCommand;
        public ICommand BooksFilterCommand =>
            booksFilterCommand ??= new RelayCommand(obj =>
                {
                    BooksCollectionView.Filter = FilterBooks;

                    if (BooksCollectionView.IsEmpty)
                    {
                        MessageBox.Show("Нет элементов элементов, удовлетворяющих условиям поиска.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });

        #endregion

        #region Private methods

        private bool FilterBooks(object obj)
        {
            if (obj is IBook book)
            {
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    string normalizedFilterText = FilterText.ToLower();

                    if (!(book.Name.ToString().ToLower().Contains(normalizedFilterText) ||
                        book.Author.ToLower().Contains(normalizedFilterText)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object FromResources(string resouceName)
        {
            return Application.Current.Resources[resouceName];
        }

        #endregion
    }
}
