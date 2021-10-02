using System;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
using WS.Events;
using WS.PartyUpdateResponses;
using WS.PartyUpdates;

namespace WS.Behaviors
{
    public class PartyBehavior : WebSocketBehavior
    {
        private EventManager<PartyUpdate, PartyUpdateResponse> _partyManager;

        protected override void OnOpen()
        {
            _partyManager = EventManager<PartyUpdate, PartyUpdateResponse>.GetInstance();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var partyUpdate = JsonConvert.DeserializeObject<PartyUpdate>(e.Data);
            if (partyUpdate == null)
            {
                return;
            }

            var isEnumParsed = Enum.TryParse(partyUpdate.Type, true, out EventType eventType);

            if (isEnumParsed)
            {
                var response = _partyManager.Handle(eventType, partyUpdate);
                Send(JsonConvert.SerializeObject(response));
            }
        }
    }
}