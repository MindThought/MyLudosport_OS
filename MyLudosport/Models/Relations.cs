using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyLudosport.Models
{
    #region AccountRelations
    public class AccountAthlete
    {
        public Guid AccountId { get; set; }
        public ApplicationUser Account { get; set; }
        public Guid AthleteId { get; set; }
        public Athlete Athlete { get; set; }
    }

    #endregion

    #region AthleteOrgRelations
    public class AthleteSchoolRelation
    {
        [Key]
        [Column(Order = 0)]
        public Guid AthleteId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid SchoolId { get; set; }

        public virtual Athlete Athlete { get; set; }
        public virtual School School { get; set; }
    }

    public class AthleteClanRelation
    {
        [Key]
        [Column(Order = 0)] 
        public Guid AthleteId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ClanId { get; set; }

        public virtual Athlete Athlete { get; set; }
        public virtual Clan Clan { get; set; }
    }

    public class AthleteAcademyRelation
    {
        [Key]
        [Column(Order = 0)]
        public Guid AthleteId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid AcademyId { get; set; }

        public virtual Athlete Athlete { get; set; }
        public virtual Academy Academy { get; set; }
    }

    //TODO Add duels
    #endregion

    #region Other AthleteRelations
    public class AthleteDuelRelations
    {
        [Key]
        [Column(Order = 0)]
        public Guid AthleteId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid DuelId { get; set; }

        public DuelChallenger Challenger { get; set; }

        public virtual Athlete Athlete { get; set; }
        public virtual Duel Duel { get; set; }
    }
    #endregion
}
