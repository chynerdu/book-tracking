
using System.ComponentModel.DataAnnotations;
namespace newWebAppA00272195.Models;

public class Book
{
    public int Id { get; set; }

   [Required]
    public string Isbn { get; set; }

    [Required]
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public string Author { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int SelectedCategoryId { get; set; }
    public List<Category> Categories 
    { 
        get
        { return new List<Category>
          {
            new Category { Id = 1, NameToken = "Thriller", Description = "Thriller Descr", CategoryType = 1 },
            new Category { Id = 2, NameToken = "Comedy", Description = "Comedy Descr", CategoryType = 2 },
            new Category { Id = 3, NameToken = "Action", Description = "Action Descr", CategoryType = 3 },
            new Category { Id = 4, NameToken = "Drama", Description = "Drama Descr", CategoryType = 4 },
            new Category { Id = 5, NameToken = "Kids", Description = "Kids Descr", CategoryType = 5 },
            new Category { Id = 6, NameToken = "Crime", Description = "Crime Descr", CategoryType = 6 }
          };
         }
    }
    public List<Book> BookList { get; set; }
    
    private static List<Book> _instances = new List<Book>() { };

  // Create a book catalogue
    public static void CreateBook(Book record)
    {
       Book thisBook = new Book();
       thisBook.Isbn = record.Isbn;
       thisBook.Title = record.Title;
       thisBook.CategoryId = record.SelectedCategoryId;
       thisBook.Author = record.Author;
       thisBook.CreatedDate = DateTime.Now;
       thisBook.Id = _instances.Count + 1;
      _instances.Add(thisBook);
     
    }

    // Get all book catalogue
    public static List<Book> GetAll()
    {
        return _instances;
    }

   // Clear all book catalogue
    public static void ClearAll()
    {
      _instances.Clear();
    }
}
