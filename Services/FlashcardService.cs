using Models;
using DataAccess;

namespace Services;

public class FlashcardService
{
    private readonly IRepo _repo;

    public FlashcardService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Flashcard> GetAllFlashcards()
    {

        return _repo.GetAllFlashcards();
    }

    public Flashcard CreateNewFlashcard(Flashcard card)
    {
        return _repo.CreateNewFlashcard(card);
    }

    public bool DeleteFlashcard(int ID)
    {
        return _repo.DeleteFlashcard(ID);
    }

    public Flashcard UpdateFlashcard(Flashcard card)
    {
        return _repo.UpdateFlashcard(card);
    }
    public Flashcard GetFlashcard(int ID)
    {
        return _repo.GetFlashcard(ID);
    }


}