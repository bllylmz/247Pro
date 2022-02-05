using _247Pro.Core.Repository;
using System.Threading.Tasks;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.Estimate
{
    public interface IEstimateRepository : IRepository<EF.Estimate>
    {
        Task<EF.Estimate> MantToManyUpdate(EF.Estimate item);
    }
}
