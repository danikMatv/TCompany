using DALEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DALEF.Ct
{
    public class ImdbContext : R2024Context
    {
        public ImdbContext(DbContextOptions<R2024Context> options)
            : base(options)
        {
        }
    }
}
