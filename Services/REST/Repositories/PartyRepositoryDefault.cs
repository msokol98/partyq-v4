using System.Collections.Generic;
using System.Linq;
using REST.Models;

namespace REST.Repositories
{
    public class PartyRepositoryDefault : IPartyRepository
    {
        private static readonly Dictionary<int, Party> Parties = new ();
        private static int _lastPartyId;
        public Party FindParty(int id)
        {
            return id < 1 ? null : Parties[id];
        }

        public IEnumerable<Party> GetAllParties()
        {
            return new List<Party>(Parties.Values);
        }

        public IEnumerable<Party> FindActiveParties()
        {
            return GetAllParties().Where(party => party != null).ToList();
        }

        public Party AddParty(Party party)
        {
            var partyId = ++_lastPartyId;
            party.Id = partyId;
            Parties.Add(partyId, party);
            return party;
        }

        public bool DeleteParty(int id)
        {
            var party = FindParty(id);
            if (party == null)
            {
                return false;
            }
            Parties.Add(id, null);
            return true;
        }
    }
}