using Models;

namespace DataAccess;

public interface IRepo
{
    List<Flashcard> GetAllFlashcards();
    Flashcard GetFlashcard(int ID);
    Flashcard UpdateFlashcard(Flashcard card);
    Flashcard CreateNewFlashcard(Flashcard card);
    bool DeleteFlashcard(int ID);


}