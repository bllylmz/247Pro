using _247Pro.Model;
using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.Estimate
{
    public class EstimateRepository : Repository<EF.Estimate>, IEstimateRepository
    {
        private readonly DataContext _context;
        public EstimateRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<EF.Estimate> MantToManyUpdate(EF.Estimate item)
        {
            try
            {
                if (item == null)
                    return null;

                EF.Estimate updated = await this.TableNoTracking.Include(x => x.EstimatesAccounts).FirstOrDefaultAsync(x => x.Id == item.Id);

                _context.Set<EF.EstimatesAccounts>().RemoveRange(updated.EstimatesAccounts);
                _context.Set<EF.EstimatesAccounts>().AddRange(item.EstimatesAccounts);

                Entities.Update(updated);

                if (await this.Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
