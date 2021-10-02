using System.Collections.Generic;

namespace REST.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Code { get; init; }
        public string Token { get; init; }
        public List<Member> Members { get; } = new();

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            Members.Remove(member);
        }
    }
}