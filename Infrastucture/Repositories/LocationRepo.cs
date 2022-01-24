using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public class LocationRepo : IRLocation
    {
        private readonly Context context;
        public LocationRepo(Context context)
        {
            this.context = context;
        }

        public Location Add(Location location)
        {
            context.Location.Add(location);
            context.SaveChanges();
            return location;
        }

        public Location GetById(int id)
            => context.Location.SingleOrDefault(x => x.Id == id);

        public void Remove(int id)
        {
            var location = GetById(id);
            context.Location.Remove(location);
            context.SaveChanges();
        }

        public void Update(Location location)
        {
            context.Location.Update(location);
            context.SaveChanges();
        }
    }
}
