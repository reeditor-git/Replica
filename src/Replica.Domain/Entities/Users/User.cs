using Replica.Domain.Entities.Base;
using Replica.Domain.Entities.Orders;

namespace Replica.Domain.Entities.Users
{
    public class User : EntityBase
    {   
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public string Image { get; set; }
    }
}
