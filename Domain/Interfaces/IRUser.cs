using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRUser
    {
        int Post(User user);
        string GetJwt(User user);
    }
}
