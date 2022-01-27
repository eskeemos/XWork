using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class ZusStatementRepo : IRZusStatement
    {
        private readonly Context context;
        public ZusStatementRepo(Context context)
        {
            this.context = context;
        }
        public ZusStatement GetById(int id)
        {
            return context.ZusStatement.SingleOrDefault(x => x.Id == id);
        }

        public void Update(ZusStatement zusStatement)
        {
            context.ZusStatement.Update(zusStatement);
            context.SaveChanges(); 
        }
    }
}
