using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBusWay.Domain.Entities
{
    public class User
    {
        public int UserId { set; get; }
        public string FName { set; get; }
        public string MName { set; get; }
        public string LName { set; get; }
        public string Email { set; get; }
        public string NPassport { set; get; }
        public DateTime BirthDate { set; get; }

        public ICollection<Order> Orders { get; set; }

    }
}
