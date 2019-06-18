using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public bool IsMale { get; set; }

        public bool IsDisabled { get; set; }

        public string Hobbies { get; set; }

        public string Description { get; set; }
    }
}
