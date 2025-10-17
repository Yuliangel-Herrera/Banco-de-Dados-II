using EFAereoNuvem.Data.Mapping;
using EFAereoNuvem.Models;
using Microsoft.EntityFrameworkCore;

namespace EFAereoNuvem.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {}
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Armchair> Armchairs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientStatus> ClientStatuses { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Scale> Scales { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdressMap());
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new FlightMap());
        modelBuilder.ApplyConfiguration(new ReservationMap());

        base.OnModelCreating(modelBuilder);
    }

}
