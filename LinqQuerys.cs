public class LinqQuerys
{
    private List<Book> collection = new List<Book>();
    public LinqQuerys()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
#pragma warning disable CS8601 // Posible asignación de referencia nula
            this.collection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
#pragma warning restore CS8601 // Posible asignación de referencia nula
        }
        
    }

    public IEnumerable<Book> allCollection()
    {
        return collection;
    }

    public IEnumerable<Book> filterYear(int year, string reference)
    {
        if(reference == "after")
        {
            return collection.Where(book => book.PublishedDate.Year > year);
        }
        else if(reference == "before")
        {
            return collection.Where(book => book.PublishedDate.Year < year);
        }
        else{
            return [];
        }
        
    }

    public IEnumerable<Book> filterPages()
    {
        return collection
        .Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));
    }

    public bool allBooksHaveStatus()
    {
        return collection.All(book => book.Status != string.Empty);
    }

    public bool isPublishedAfter(int year)
    {
        return collection.Any(book => book.PublishedDate.Year > year);
    }

    public bool isPublishedIn(int year)
    {
        return collection.Any(book => book.PublishedDate.Year == year);
    }

    public IEnumerable<Book> filterCategories(string category)
    {
        return collection
        .Where(book => book.Categories
        .Contains(category));
    }

    public IEnumerable<Book> orderBooks(string category)    
    {
        return collection
        .Where(book => book.Categories.Contains(category) && book.PageCount > 0)
        .OrderBy(book => book.Title);
    } 

    public IEnumerable<Book> orderBooksByPageCountDescending(string category = "all")
    {
        if(category == "all" || category == "")
        {
            return collection
            .Where(book => book.PageCount > 450)
            .OrderByDescending(book => book.PageCount);
        }
        else    
        {
            return collection
            .Where(book => book.Categories
            .Contains(category) && book.PageCount > 450)
            .OrderByDescending(book => book.PageCount);
        }
    }

    public IEnumerable<Book> initialBooksOrderedByPublishedDate(int quantity, string category = "all")
    {
        if(category == "all" || category == "")
        {
            return collection
            .Where(book => book.PageCount > 0)
            .OrderByDescending(book => book.PublishedDate)
            .Take(quantity);
        }
        else    
        {
            return collection
            .Where(book => book.Categories.Contains(category) && book.PageCount > 0)
            .OrderByDescending(book => book.PublishedDate)
            .Take(quantity);
        }
    }

    public IEnumerable<Book> skipBooksOrderedByPublishedDate(int taken, int skipped, string category = "all")
    {
        if(category == "all" || category == "")
        {
            return collection
            .Where(book => book.PageCount > 400)
            .OrderByDescending(book => book.PublishedDate)
            .Take(taken)
            .Skip(skipped);
        }
        else    
        {
            return collection
            .Where(book => book.Categories.Contains(category) && book.PageCount > 400)
            .OrderByDescending(book => book.PublishedDate)
            .Take(taken)
            .Skip(skipped);
        }
    }

    public IEnumerable<Book> selectDataInBooks(int taken)
    {
        return collection
        .Where(book => book.PageCount > 0)
        .OrderByDescending(book => book.PageCount)
        .Take(taken)
        .Select(book => new Book() {
            Title = book.Title,
            PageCount = book.PageCount,
            PublishedDate = book.PublishedDate
        });
    }

    public int countBooks()
    {
        return collection.Count(book => book.PageCount >= 200 && book.PageCount <= 500);
    }

    public DateTime minDatePublished()
    {
        return collection
        .Min(book => book.PublishedDate);
    }

    public DateTime maxDatePublished()
    {
        return collection
        .Max(book => book.PublishedDate);
    }

    public int maxPageCount()
    {
        return collection
        .Max(book => book.PageCount);
    }

    public IEnumerable<Book> maxPageCountBooks()
    {
        return collection
        .Where(book => book.PageCount == maxPageCount());
    }

    public Book minPageCountBooks()
    {
        return collection
        .Where(book => book.PageCount > 0)
        .MinBy(book => book.PageCount);
    }

    public Book newestBook()
    {
        return collection
        .MaxBy(book => book.PublishedDate);
    }

    public int addOfPages()
    {
        return collection
        .Where(book => book.PageCount > 0 && book.PageCount <= 500)
        .Sum(book => book.PageCount);
    }

    public string bookTitles()
    {
        return collection
        .Where(book => book.PublishedDate.Year > 1997 && book.PublishedDate.Year < 2015)
        .Select(book => book.Title)
        .Aggregate((current, next) => current + "\n- "  + next);
    }

    public double averageBookPages()
    {
        return collection
        .Where(book => book.PageCount > 0)
        .Average(book => book.PageCount);
    }

    public IEnumerable<IGrouping<int, Book>> groupBooksByYear()
    {
        return collection
        .Where(book => book.PublishedDate.Year > 2000 && book.PageCount > 0)
        .GroupBy(book => book.PublishedDate.Year);
    }

    // Implementar funcion lookup que devuelva un diccionario con los libros dependiendo de la letra de inicio del titulo
    public ILookup<char, Book> lookUpBooks()
    {
        return collection
        .Where(book => book.PageCount > 0)
        .ToLookup(book => book.Title[0], book => book);
    }

    public IEnumerable<Book> joinCollections(int year, int pages)
    {
        var booksFrom = collection.Where(book => book.PublishedDate.Year >= year);
        var booksPages = collection.Where(book => book.PageCount >= pages);
        return booksFrom
       .Join(booksPages, x => x.Title, y => y.Title, (x, y) => x);
    }

}