using Services;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly FlashcardService _service;

    public CardController(FlashcardService service)
    {
        _service = service;
    }

    [HttpGet("Flashcards")]
    public ActionResult<List<Flashcard>> GetAllFlashcards()
    {
        return Created("/cards", _service.GetAllFlashcards());
    }

    [HttpGet("Flashcard")]
    public ActionResult<List<Flashcard>> GetFlashcard([FromQuery] int ID)
    {
        return Created("/cards/{id}", _service.GetFlashcard(ID));
    }

    [HttpPost("Flashcards")]
    public ActionResult<Flashcard> CreateNewFlashcard([FromBody] Flashcard card)
    {
        return Created("/create", _service.CreateNewFlashcard(card));
    }
    [HttpDelete("Delete")]
    public ActionResult<bool> DeleteFlashcard([FromQuery] int ID)
    {
        return Created("/cards/delete", _service.DeleteFlashcard(ID));
    }
    [HttpPut("Update")]
    public ActionResult<Flashcard> UpdateFlashcard([FromBody] Flashcard card)
    {
        return Created("/cards/update", _service.UpdateFlashcard(card));
    }
}