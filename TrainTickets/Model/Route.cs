using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Model
{
    public class Route
    {
        [Key]
        public int Id { set; get; }
        public int FromStation { set; get; }
        public int ToStation { set; get; }
        public DateTime Date { set; get; }
        public double Price { set; get; }
    }
}
