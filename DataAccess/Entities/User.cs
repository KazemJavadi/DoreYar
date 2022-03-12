using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        //Relationships
        public List<Deck> Decks { get; set; }
    }
}
