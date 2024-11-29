namespace EntityFramework_Library.Classes;

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }
    public int AvailableCopies { get; set; }
}

public class NonFiction : Item { }
public class Novel : Item { }
public class Textbook : Item { }
public class Biography : Item { }
public class ScienceFiction : Item { }
public class Fantasy : Item { }
public class Mystery : Item { }