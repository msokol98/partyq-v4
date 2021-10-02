using System.Collections.Generic;
using REST.Models;
using REST.Requests;

namespace REST.Services
{
    public interface IPartyService
    {
        IEnumerable<Party> GetAllParties();
        Party FindParty(int id);
        Party CreateParty(NewParty party);
        bool DeleteParty(int id);
    }
}