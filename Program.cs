LinqQuerys queries = new LinqQuerys();

// All Books
//printValues(queries.allCollection());

// Books published after 2000
//printValues(queries.filterYear(2010, "after"));

// Books that have more than 250 pages and the title contains the words "in Action"
//printValues(queries.filterPages());

// Books that have the category "Python"
//printValues(queries.filterCategories("Python"));

// Order Books
//printValues(queries.orderBooks("Java"));

// Order Books by Page Count Descending
//printValues(queries.orderBooksByPageCountDescending("Java"));

// Take the first 10 books ordered by published date
//printValues(queries.initialBooksOrderedByPublishedDate(3, "Java"));

// Take 3 books ordered by published date
//printValues(queries.skipBooksOrderedByPublishedDate(4, 2));

// Select the first 10 books
printValues(queries.selectDataInBooks(5));

// All Books have a status
//Console.WriteLine($"Todos los libros tienen Status? {queries.allBooksHaveStatus()}");

// Books published after 2000
//Console.WriteLine($"Hay libros publicados después de 2020? {queries.isPublishedAfter(2020)}");

// Books published in 2000
//Console.WriteLine($"Hay libros publicados en 2003? {queries.isPublishedIn(2003)}");

// METHODS
void printValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Date of Publish");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

