using System.Dynamic;

public class Book
{
    public string Ttitle {get; set;} = "";
    public int PageCount {get; set;}
    public string Status {get; set;} = "";
    public DateTime PublishedDate {get; set;}
    public string[] Authors {get; set;} = [];
    public string[] Categories {get; set;} = [];
}