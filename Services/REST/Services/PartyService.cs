using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using REST.Models;
using REST.Repositories;
using REST.Requests;

namespace REST.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;
        private readonly IMemberService _memberService;
        
        public PartyService(IPartyRepository partyRepository, IMemberService memberService)
        {
            _partyRepository = partyRepository;
            _memberService = memberService;
        }

        public IEnumerable<Party> GetAllParties()
        {
            return _partyRepository.GetAllParties();
        }

        public Party FindParty(int id)
        {
            return _partyRepository.FindParty(id);
        }

        public Party CreateParty(NewParty newParty)
        {
            var code = GeneratePartyCode();
            var party = new Party
            {
                Token = newParty.Token,
                Code = code,
                Members = { _memberService.CreateMember(newParty.Host, true) }
            };
            return _partyRepository.AddParty(party);
        }

        private string GeneratePartyCode()
        {
            var usedCodes = _partyRepository.FindActiveParties().Select(x => x.Code);
            string code = null;
            var usedCodesEnumerable = usedCodes.ToList();
            do
            {
                var r = new Random();
                var randNum = r.Next(1000000);
                code = randNum.ToString("D6");
            } while (usedCodesEnumerable.Contains(code));
            return code;
        }

        public bool DeleteParty(int id)
        {
            return _partyRepository.DeleteParty(id);
        }
    }
}