
using Models;
using System.Data.SqlClient;

namespace DataAccess;

public class DBRepo : IRepo
{
    public Flashcard CreateNewFlashcard(Flashcard card)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("INSERT INTO Flashcards VALUES (@q, @a)", connection);
            command.Parameters.AddWithValue("@q", card.Question);
            command.Parameters.AddWithValue("@a", card.Answer);

            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            throw e;
        }

        return card;
    }

    public bool DeleteFlashcard(int ID)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("DELETE FROM Flashcards WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            throw e;
        }

        return true;
    }

    public List<Flashcard> GetAllFlashcards()
    {
        List<Flashcard> cards = new List<Flashcard>();
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("SELECT * FROM Flashcards", connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cards.Add(new Flashcard()
                {
                    ID = (int)reader["ID"],
                    Question = (string)reader["Question"],
                    Answer = (string)reader["Answer"]
                });
            }
        }
        catch (SqlException e)
        {
            throw e;
        }

        return cards;
    }

    public Flashcard GetFlashcard(int ID)
    {
        Flashcard card = new Flashcard();
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("SELECT * FROM Flashcards WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", ID);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                card.ID = (int)reader["ID"];
                card.Question = (string)reader["Question"];
                card.Answer = (string)reader["Answer"];
            }
        }
        catch (SqlException e)
        {
            throw e;
        }

        return card;
    }

    public Flashcard UpdateFlashcard(Flashcard card)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("UPDATE Flashcards SET Question = @q, Answer = @a WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@q", card.Question);
            command.Parameters.AddWithValue("@a", card.Answer);
            command.Parameters.AddWithValue("@ID", card.ID);
            command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            throw e;
        }

        return card;
    }
}