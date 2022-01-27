using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class LocationRepo : IRLocation
    {
        private readonly Context context;
        public LocationRepo(Context context)
        {
            this.context = context; 
        }

        public Location GetById(int id)
            => context.Location.SingleOrDefault(x => x.Id == id);

        public void Update(Location location)
        {
            context.Location.Update(location);
            context.SaveChanges();
        }
    }
}
