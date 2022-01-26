using Domain.Entities;
using Infrastucture.Data;
using System.Collections.Generic;
using System.Linq;

namespace XWork.Seeders
{
    public class RoleSeeder
    {
        private readonly Context context;

        public RoleSeeder(Context context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if(context.Database.CanConnect())
            {
                if(!context.Role.Any())
                {
                    var roles = GetRoles();
                    context.Role.AddRange(roles);
                    context.SaveChanges();
                }
            }
        }
        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                }
            };

            return roles;
        }
    }
}
