using System;
using Newtonsoft.Json;
using WS.PartyUpdateResponses;
using WS.PartyUpdates;

namespace WS.PartyUpdateHandlers
{
    public class MemberJoinedHandler : IPartyUpdateHandler
    {
        public PartyUpdateResponse Handle(PartyUpdate update)
        {
            var memberJoined = JsonConvert.DeserializeObject<MemberJoined>(update.Payload);
            if (memberJoined != null) Console.WriteLine($"New member joined: {memberJoined.NewMember}");
            var memberJoinedResponse = memberJoined != null ? 
                    new MemberJoinedResponse {NewMember = memberJoined.NewMember} :
                    null;
            return new PartyUpdateResponse { PartyId = update.PartyId, Type = update.Type, Body = JsonConvert.SerializeObject(memberJoinedResponse) };
        }
    }

}