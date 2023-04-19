namespace DataAccess;

internal class Secrets
{
    private const string connection = "Server=tcp:flashcardserver.database.windows.net,1433;Initial Catalog=FlashCardDB;Persist Security Info=False;User ID=pinkgodzilla;Password=Iconalar1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public static string getConnectionString() => connection;
}