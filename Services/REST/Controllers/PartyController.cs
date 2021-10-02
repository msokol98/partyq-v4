using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST.Models;
using REST.Requests;
using REST.Services;

namespace REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _partyService;
        private readonly ILogger<PartyController> _logger;
        
        public PartyController(IPartyService partyService, ILogger<PartyController> logger)
        {
            _partyService = partyService;
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<Party> Get()
        {
            return _partyService.GetAllParties();
        }
        
        [Route("{id:int}")]
        [HttpGet]
        public Party GetById(int id)
        {
            return _partyService.FindParty(id);
        }
        
        [HttpPost]
        public Party Post([FromBody] NewParty party)
        {
            return _partyService.CreateParty(party);
        }
        
        [Route("{id:int}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _partyService.DeleteParty(id);
        }
        
        [Route("{partyId:int}/member")]
        [HttpPost]
        public Party PostMember(int partyId, [FromQuery] string name)
        {
            return _memberService.CreateMember(party, name);
        }
    }
}
