namespace LinkedIn.Data
{
    using System.Data.Entity;
    using Models;

    public interface ILinkedInDbContext
    {
        IDbSet<Certification> Certifications { get; set; }

        IDbSet<Discussion> Discussions { get; set; }

        IDbSet<Experience> Experiences { get; set; }

        IDbSet<Group> Groups { get; set; }

        IDbSet<UserLanguage> UserLanguages { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Endorcement> Endorcements { get; set; }

        IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        int SaveChanges();
    }
}
