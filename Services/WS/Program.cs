using System;
using System.Collections.Generic;
using WebSocketSharp.Server;
using WS.Behaviors;
using WS.Events;
using WS.PartyUpdateHandlers;
using WS.PartyUpdateResponses;
using WS.PartyUpdates;

namespace WS
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            SetupEventHandlers();
            SetupServer();
        }
        
        private static void SetupServer()
        {
            const int port = 8001;
            var wsServer = new WebSocketServer($"ws://localhost:{port}");
            wsServer.AddWebSocketService<PartyBehavior>("/party");
            wsServer.Start();
            Console.WriteLine($"Started web socket server on port {port}");
            Console.ReadKey();
            wsServer.Stop();
        }

        private static void SetupEventHandlers()
        {
            var eventHandlerMap = new Dictionary<EventType, IPartyUpdateHandler>()
            {
                [EventType.MemberJoined] = new MemberJoinedHandler(),
                [EventType.SongAdded] = new SongAddedHandler()
            };

            var partyManager = EventManager<PartyUpdate, PartyUpdateResponse>.GetInstance();
            foreach (var partyUpdateHandler in eventHandlerMap)
            {
                partyManager.AddHandler(partyUpdateHandler.Key, partyUpdateHandler.Value);
            }

        }
    }

}
