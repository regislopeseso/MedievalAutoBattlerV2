using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Entities;

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
                Deck = null,
                Level = 0
            };

            this._daoDbContext.Add(newNpc);
            await this._daoDbContext.SaveChangesAsync();

            return "Create action sucessful";
        }
    }
}
