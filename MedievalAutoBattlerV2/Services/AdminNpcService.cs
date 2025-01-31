using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MedievalAutoBattlerV2.Services
{
    public class AdminNpcsService
    {
        private readonly ApplicationDbContext _daoDbContext;

        public AdminNpcsService(ApplicationDbContext daoDbContext)
        {
            this._daoDbContext = daoDbContext;
        }

        public async Task<string> Create(AdminNpcsCreateRequest npc)
        {
            if (npc == null)
            {
                return "Error: NPC is null";
            }

            var newNpc = new Npc
            {
                Name = npc.Name,
                Description = npc.Description,
                Deck = new List<DeckEntry>(),
                Level = 0
            };

            var cardsDB = await _daoDbContext.Cards
                                .Where(a => a.IsDeleted == false)
                                .ToListAsync();

            foreach (var cardId in npc.CardsId)
            {
                for (int i = 0; i < cardsDB.Count; i++)
                {
                    if ((cardId == cardsDB[i].Id) == true)
                    {
                        newNpc.Deck.Add(new DeckEntry
                        {
                            Card = cardsDB[i]
                        });
                    }
                }
            }





            this._daoDbContext.Add(newNpc);
            await this._daoDbContext.SaveChangesAsync();

            return "Create action sucessful";
        }

        
    }
}
