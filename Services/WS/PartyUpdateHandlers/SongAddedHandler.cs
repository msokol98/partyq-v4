using System;
using Newtonsoft.Json;
using WS.PartyUpdateResponses;
using WS.PartyUpdates;

namespace WS.PartyUpdateHandlers
{
    public class SongAddedHandler : IPartyUpdateHandler
    {
        public PartyUpdateResponse Handle(PartyUpdate update)
        {
            var newSong = JsonConvert.DeserializeObject<SongAdded>(update.Payload);
            if (newSong != null) Console.WriteLine($"New song: {newSong.NewSong}");
            
            var songAddedResponse = newSong != null ? 
                new SongAddedResponse {SongName = newSong.NewSong, SongChooser = "Jane"} :
                null;
            return new PartyUpdateResponse { PartyId = update.PartyId, Type = update.Type, Body = JsonConvert.SerializeObject(songAddedResponse) };
        }
    }
}