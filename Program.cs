LinqQuerys queries = new LinqQuerys();

// All Books
printValues(queries.allCollection());

// Books published after 2000
printValues(queries.filterYear(2010, "after"));

// Books that have more than 250 pages and the title contains the words "in Action"
printValues(queries.filterPages());



// METHODS
void printValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Date of Publish");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

