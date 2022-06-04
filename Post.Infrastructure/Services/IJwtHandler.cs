using System;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}