using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Model
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public Route Route { get; set; }

    }
}
