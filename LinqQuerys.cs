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
}