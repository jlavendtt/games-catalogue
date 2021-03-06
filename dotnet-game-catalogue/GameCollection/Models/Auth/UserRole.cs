using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Models.Auth
{
    public class UserRole
    {
        public Role SelectedRole { get; set; }

        public User EnrolledUser { get; set; }
        [ForeignKey("EnrolledUser")]
        public int UserId { get; set; }
        [ForeignKey("SelectedRole")]
        public int RoleId { get; set; }
    }
}
