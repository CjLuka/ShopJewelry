using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Order
    {
        public int Id { get; set; }
        public double Value { get; set; }

        //[ForeignKey("UserId")]
        //public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
