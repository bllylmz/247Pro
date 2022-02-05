using Microsoft.EntityFrameworkCore;

namespace _247Pro.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
