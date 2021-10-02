using System.Collections.Generic;
using REST.Models;

namespace REST.Repositories
{
    public interface IPartyRepository
    {
        Party FindParty(int id);
        IEnumerable<Party> GetAllParties();
        IEnumerable<Party> FindActiveParties();
        Party AddParty(Party party);
        bool DeleteParty(int id);
    }
}