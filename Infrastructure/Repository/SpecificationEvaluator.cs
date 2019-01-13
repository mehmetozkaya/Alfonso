using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;

namespace Infrastructure.Repository
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            throw new System.Exception();
        }
    }
}