using Churchmanagement.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ChurchMember> ChurchMembers { get; set; }
    public DbSet<LocalChurch> LocalChurches { get; set; }
    public DbSet<Diocese> Dioceses { get; set; }
    public DbSet<ArchDiocese> ArchDioceses { get; set; }
    public DbSet<Parish> Parishes { get; set; }
    public DbSet<Clergy> Clergies { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<LeadershipBoard> LeadershipBoards { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }
}
