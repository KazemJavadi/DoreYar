using DataAccess.Entities;

namespace Logic
{
    public interface ICardsService
    {
        List<Card> GetAll(int deckId);
    }
}
