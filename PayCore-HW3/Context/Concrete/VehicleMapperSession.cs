using NHibernate;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Context
{
    public class VehicleMapperSession : IMapperSession<Vehicle>
    {
        private readonly ISession session;
        private ITransaction transaction;

        public VehicleMapperSession(ISession session)
        {
            this.session = session;
        }
        public IQueryable<Vehicle> Entities => session.Query<Vehicle>();

        public void BeginTranstaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Delete(Vehicle entity)
        {
            session.Delete(entity);
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Vehicle entity)
        {
            session.Save(entity);
        }
        public void Update(Vehicle entity)
        {
            session.Update(entity);
        }
    }
}
