using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Dtos.Response;
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

            return "Create sucessful";
        }

        public async Task<(List<AdminNpcsReadResponse>, string)> Read()
        {
            var npcsDB = await _daoDbContext.Npcs.ToListAsync();

            var response = new List<AdminNpcsReadResponse>();

            foreach (var npc in npcsDB)
            {
                if (npc.IsDeleted == false)
                {
                    response.Add(new AdminNpcsReadResponse
                    {
                        Id = npc.Id,
                        Name = npc.Name,
                        Description = npc.Description,
                        Deck = npc.Deck,
                        Level = npc.Level
                    });
                }
            }
            return (response, "Read successful!");
        }

        public async Task<string> Delete(int id)
        {
            var npcdDB = await _daoDbContext.Npcs
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            npcdDB.IsDeleted = true;

            await this._daoDbContext.SaveChangesAsync();

            return "Delete successful";
        }
    }
}
