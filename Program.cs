LinqQuerys queries = new LinqQuerys();

// All Books
// printValues(queries.allCollection());

// // Books published after 2000
// printValues(queries.filterYear(2010, "after"));

// // Books that have more than 250 pages and the title contains the words "in Action"
// printValues(queries.filterPages());

// // Books that have the category "Python"
// printValues(queries.filterCategories("Python"));

// // Order Books
// printValues(queries.orderBooks("Java"));

// // Order Books by Page Count Descending
// printValues(queries.orderBooksByPageCountDescending("Java"));

// // Take the first 3 books ordered by published date
// printValues(queries.initialBooksOrderedByPublishedDate(3, "Java"));

// // Take 3 books ordered by published date
// printValues(queries.skipBooksOrderedByPublishedDate(4, 2));

// // Select the first 10 books
// printValues(queries.selectDataInBooks(10));

// // Count the number of books
// Console.WriteLine($"El número de libros entre 200 y 500 páginas es: {queries.countBooks()}");

// // Min date published
// Console.WriteLine($"Fecha de publicación mínima: {queries.minDatePublished()}");

// // Max date published
// Console.WriteLine($"Fecha de publicación máxima: {queries.maxDatePublished()}");

// // Max page count
// Console.WriteLine($"\nMáximo número de páginas: {queries.maxPageCount()}");

// // Max page count books
// printValues(queries.maxPageCountBooks());

// // All Books have a status
// Console.WriteLine($"Todos los libros tienen Status? {queries.allBooksHaveStatus()}");

// // Books published after 2000
// Console.WriteLine($"Hay libros publicados después de 2020? {queries.isPublishedAfter(2020)}");

// // Books published in 2000
// Console.WriteLine($"Hay libros publicados en 2003? {queries.isPublishedIn(2003)}");

// // Min page count books
// var minPageCount = queries.minPageCountBooks();
// Console.WriteLine($"Title: {minPageCount.Title}");
// Console.WriteLine($"Page Count: {minPageCount.PageCount}");
// Console.WriteLine($"Published Date: {minPageCount.PublishedDate.ToShortDateString()}");

// // Newest book
// var newestBook = queries.newestBook();
// Console.WriteLine($"Title: {newestBook.Title}");
// Console.WriteLine($"Page Count: {newestBook.PageCount}");
// Console.WriteLine($"Published Date: {newestBook.PublishedDate.ToShortDateString()}");

// // Add of pages
// Console.WriteLine($"Suma de páginas: {queries.addOfPages()}");

// // Book Titles
// Console.Write($"- {queries.bookTitles()}\n");

// // Average pages
// Console.WriteLine($"Media de páginas: {queries.averageBookPages()}");

// // Group books by year
// printGroupValues(queries.groupBooksByYear());

// // Lookup books by title
//printDictionaryValues(queries.lookUpBooks(), 'J');

printValues(queries.joinCollections(2005, 500));

// METHODS
void printValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", "Title", "Pages | ", " Date of Publish");
    Console.WriteLine("--------------------------------------------------------------------------------------------------");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60} {1, 11} {2, 16}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void printGroupValues(IEnumerable<IGrouping<int, Book>> bookList)
{
    foreach(var group in bookList)
    {
        Console.WriteLine("");
        Console.WriteLine($"Group: {group.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", "Title", "Pages | ", " Date of Publish");
        Console.WriteLine("--------------------------------------------------------------------------------------------------");
        foreach(var item in group)
        {
            Console.WriteLine("{0, -60} {1, 11} {2, 16}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
        Console.WriteLine($"Books Quantity: {group.Count()}");
        
    }
}

void printDictionaryValues(ILookup<char, Book> bookList, char letter)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}", "Title", "Pages | ", " Date of Publish");
    Console.WriteLine("--------------------------------------------------------------------------------------------------");
    foreach(var item in bookList[letter])
    {
        Console.WriteLine("{0, -60} {1, 11} {2, 16}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}


