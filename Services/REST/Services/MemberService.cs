using REST.Models;

namespace REST.Services
{
    public class MemberService : IMemberService
    {
        private static int _lastMemberId = 0;
        
        public Member CreateMember(string name, bool isHost = false)
        {
            return new Member {Id = ++_lastMemberId, Name = name, IsHost = isHost};
        }
    }
}