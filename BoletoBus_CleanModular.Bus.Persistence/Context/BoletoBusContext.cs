using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Persistence.Context
{
    public class BoletosBusContext : DbContext
    {
        #region "Constructor"
        public BoletosBusContext(DbContextOptions<BoletosBusContext> options) : base(options)
        {

        }

        #endregion

        #region "Db Sets"
        public DbSet<Bus.Domain.Entities.Bus> Bus { get; set; }
        #endregion


    }
}
