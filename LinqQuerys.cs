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
        return collection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));
    }
}