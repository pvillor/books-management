namespace BooksManagement.Utils;

public class IdGenerator
{
    private static int _id = 0;

    public static int GenerateId()
    {
        _id++;

        return _id;
    }
}
