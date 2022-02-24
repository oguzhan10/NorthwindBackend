using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from o in context.OperationClaims.ToList()
                             join u in context.UserOperationClaims.ToList() on o.Id equals u.OperationClaimId
                             where u.UserId == user.Id
                             select new OperationClaim { Id=o.Id,Name=o.Name };

                return result.ToList();
            }
        }
    }
}
