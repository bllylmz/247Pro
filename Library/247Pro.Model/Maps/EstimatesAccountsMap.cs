using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class EstimatesAccountsMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<EstimatesAccounts>(entity =>
            {
                entity.ToTable("EstimatesAccounts");

                entity.HasKey(e => new { e.EstimateId, e.AccountId });

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.EstimatesAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstimatesAccounts_Accounts");

                entity.HasOne(d => d.Estimate)
                    .WithMany(p => p.EstimatesAccounts)
                    .HasForeignKey(d => d.EstimateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstimatesAccounts_Estimates");

            });
        }
    }
}
