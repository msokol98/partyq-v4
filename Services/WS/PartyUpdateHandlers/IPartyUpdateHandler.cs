using WS.Events;
using WS.PartyUpdateResponses;
using WS.PartyUpdates;

namespace WS.PartyUpdateHandlers
{
    public interface IPartyUpdateHandler : IEventHandler<PartyUpdate, PartyUpdateResponse>
    {
        
    }
}