using System.Security.Cryptography;
using REST.Models;

namespace REST.Services
{
    public interface IMemberService
    {
        Member CreateMember(string name, bool isHost = false);
    }
}