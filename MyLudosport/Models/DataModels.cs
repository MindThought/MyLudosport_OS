using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLudosport.Models
{
    #region Users
    public class Athlete
    {
        public Guid Id { get; set; }
        #region Properties
        public string AccountId { get; set; }
        public virtual ApplicationUser Account { get; set; }
        public string BattleName { get; set; }
        public virtual ICollection<AthleteClanRelation> ClanRelations { get; set; }
        public virtual ICollection<AthleteSchoolRelation> SchoolRelations { get; set; }
        public virtual ICollection<AthleteAcademyRelation> AcademyRelations { get; set; }
        public virtual ICollection<AthleteDuelRelations> DuelRelations { get; set; }

        #region Styles
        [DisplayName("Form 1")]
        public StyleLevel? Form1 { get; set; } = null;
        [DisplayName("Form 2")]
        public StyleLevel? Form2 { get; set; } = null;
        [DisplayName("Form 3")]
        public StyleLevel? Form3 { get; set; } = null;
        [DisplayName("Form 4")]
        public StyleLevel? Form4 { get; set; } = null;
        [DisplayName("Form 5")]
        public StyleLevel? Form5 { get; set; } = null;
        [DisplayName("Form 6")]
        public StyleLevel? Form6 { get; set; } = null;
        [DisplayName("Form 7")]
        public StyleLevel? Form7 { get; set; } = null;
        [DisplayName("Form 8")]
        public StyleLevel? Form8 { get; set; } = null;
        [DisplayName("Form 9")]
        public StyleLevel? Form9 { get; set; } = null;
        [DisplayName("Course Y")]
        public StyleLevel? CourseY { get; set; } = null;
        #endregion
        #endregion
    }

    public class Judge
    {
        public Guid Id { get; set; }
        #region Properties
        public string AccountId { get; set; }
        public virtual ApplicationUser Account { get; set; }
        public JudgeLevel Level { get; set; }
        #endregion
    }
    #endregion

    #region Orgs
    public class Academy
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public string Name { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<AthleteAcademyRelation> AthleteRelations { get; set; }
        public Athlete Dean { get; set; }
        public virtual ICollection<ApplicationUser> Admins { get; set; }
        #endregion
    }

    public class Clan
    {
        [Key]
        public Guid Id { get; set; }
        #region Properies
        public School School { get; set; }
        public virtual ICollection<AthleteClanRelation> Students { get; set; }
        public virtual ICollection<Athlete> Instructors { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Admins { get; set; }
        //TODO: Add classes
        #endregion
    }

    public class School
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public Academy Academy { get; set; }
        public virtual ICollection<Clan> Clans { get; set; }
        public virtual ICollection<AthleteSchoolRelation> AthleteRelations { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ApplicationUser> Admins { get; set; }
        #endregion
    }
    #endregion

    public class Duel
    {
        [Key]
        public Guid Id { get; set; }
        #region Properties
        public virtual ICollection<AthleteDuelRelations> DuelRelations { get; set; }
        public string Text { get; set; }
        public DateTime ChallengeTime { get; set; } = DateTime.Now;
        public DateTime ReportTime { get; set; }
        public DuelResult DuelResult { get; set; } = DuelResult.None;
        public DuelStatus DuelStatus { get; set; } = DuelStatus.Initiated;
        public Reporter Reporter { get; set; } = Reporter.None;
        #endregion
    }

    #region Enums
    public enum DuelResult
    {
        ChallengerWins,
        ReceiverWins,
        Declined,
        None
    }

    public enum DuelStatus
    {
        Initiated,
        Accepted,
        Reported,
        Confirmed
    }

    public enum DuelChallenger
    {
        Challenger,
        Receiver
    }

    public enum Reporter
    {
        Challenger,
        Receiver,
        None
    }

    public enum StyleLevel
    {
        Student,
        Instructor,
        Technico,
        StyleMaster
    }

    public enum JudgeLevel
    {
        //TODO Add levels
    }
    #endregion
}
