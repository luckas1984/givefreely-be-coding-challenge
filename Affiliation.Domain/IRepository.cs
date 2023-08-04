using Affiliation.Domain.Models;

namespace Affiliation.Domain
{
    public interface IRepository<TModel>
        where TModel : class
    {
        TModel Get(int id);

        IQueryable<TModel> All();

        TModel Insert(TModel model);

        void Update(TModel model);

        void Delete(TModel model);
    }
}
