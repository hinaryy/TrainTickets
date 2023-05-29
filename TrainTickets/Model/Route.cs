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
        public string FromStation { set; get; }
        public string ToStation { set; get; }
        public DateTime Date { set; get; }
        public int Price { set; get; }
    }
}
