using BoletoBus_CleanModular.Common.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBus_CleanModular.Asiento.Domain.Entities
{
    public class Asiento : BaseEntity<int>
    {
        [Column("IdAsiento")]
        public override int Id { get; set; }

        public int IdBus { get; set; }

        public int? NumeroPiso { get; set; }

        public int? NumeroAsiento { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
