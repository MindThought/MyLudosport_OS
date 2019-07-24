using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyLudosport.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        #region PersonalInformation
        public string PersonalName { get; set; }
        public string FamilyName { get; set; }
        #endregion

        public virtual Athlete Athlete { get; set; }
        public virtual Judge Judge { get; set; }
    }
}
