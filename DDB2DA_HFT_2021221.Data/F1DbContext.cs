using DDB2DA_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Data
{
    public class F1DbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<GrandPrix> GrandPrix { get; set; }


        public F1DbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasOne(driver => driver.Team)
                .WithMany(team => team.Drivers)
                .HasForeignKey(driver => driver.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TeamGPs>(entity =>
            {
                entity.HasOne(x => x.gp)
                .WithMany(y => y.TeamGPs)
                .HasForeignKey(tg => tg.GpId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            });

            modelBuilder.Entity<TeamGPs>(entity =>
            {
                entity.HasOne(x => x.team)
                .WithMany(y => y.TeamGPs)
                .HasForeignKey(tg => tg.TeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });



            #region DataSeed

            Team mercedes = new Team() { Id = 1, Name = "Mercedes", Points = 433.5 };
            Team redbull = new Team() { Id = 2, Name = "Red Bull Racing Honda", Points = 397.5 };
            Team mclaren = new Team() { Id = 3, Name = "McLaren Mercedes", Points = 240 };
            Team ferrari = new Team() { Id = 4, Name = "Ferrari", Points = 232.5 };
            Team alpine = new Team() { Id = 5, Name = "Alpine Renault", Points = 104 };
            Team alphatauri = new Team() { Id = 6, Name = "Alphatauri Honda", Points = 92 };
            Team astonmartin = new Team() { Id = 7, Name = "Aston Martin Mercedes", Points = 61 };
            Team williams = new Team() { Id = 8, Name = "Williams Mercedes", Points = 23 };
            Team alfaromeo = new Team() { Id = 9, Name = "Alfa Romeo Racing Ferrari", Points = 7 };
            Team haas = new Team() { Id = 10, Name = "Haas Ferrari", Points = 0 };

            Driver ver = new Driver() { Id = 33, ShortName = "VER", FirstName = "Max", LastName = "Verstappen", Points = 262.5, TeamId = redbull.Id, Nationality = "NED" };
            Driver ham = new Driver() { Id = 44, ShortName = "HAM", FirstName = "Lewis", LastName = "Hamilton", Points = 256.5, TeamId = mercedes.Id, Nationality = "GBR" };
            Driver bot = new Driver() { Id = 77, ShortName = "BOT", FirstName = "Valtteri", LastName = "Bottas", Points = 177, TeamId = mercedes.Id, Nationality = "FIN" };
            Driver nor = new Driver() { Id = 4, ShortName = "NOR", FirstName = "Lando", LastName = "Norris", Points = 145, TeamId = mclaren.Id, Nationality = "GBR" };
            Driver per = new Driver() { Id = 11, ShortName = "PER", FirstName = "Sergio", LastName = "Perez", Points = 135, TeamId = redbull.Id, Nationality = "MEX" };
            Driver sai = new Driver() { Id = 55, ShortName = "SAI", FirstName = "Carlos", LastName = "Sainz", Points = 116.5, TeamId = ferrari.Id, Nationality = "ESP" };
            Driver lec = new Driver() { Id = 16, ShortName = "LEC", FirstName = "Charles", LastName = "Leclerc", Points = 116, TeamId = ferrari.Id, Nationality = "MON" };
            Driver ric = new Driver() { Id = 3, ShortName = "RIC", FirstName = "Daniel", LastName = "Ricciardo", Points = 95, TeamId = mclaren.Id, Nationality = "AUS" };
            Driver gas = new Driver() { Id = 10, ShortName = "GAS", FirstName = "Pierre", LastName = "Gasly", Points = 74, TeamId = alphatauri.Id, Nationality = "FRA" };
            Driver alo = new Driver() { Id = 14, ShortName = "ALO", FirstName = "Fernando", LastName = "Alonso", Points = 58, TeamId = alpine.Id, Nationality = "ESP" };
            Driver oco = new Driver() { Id = 31, ShortName = "OCO", FirstName = "Esteban", LastName = "Ocon", Points = 46, TeamId = alpine.Id, Nationality = "FRA" };
            Driver vet = new Driver() { Id = 5, ShortName = "VET", FirstName = "Sebastian", LastName = "Vettel", Points = 35, TeamId = astonmartin.Id, Nationality = "GER" };
            Driver str = new Driver() { Id = 18, ShortName = "STR", FirstName = "Lance", LastName = "Stroll", Points = 26, TeamId = astonmartin.Id, Nationality = "CAN" };
            Driver tsu = new Driver() { Id = 22, ShortName = "TSU", FirstName = "Yuki", LastName = "Tsunoda", Points = 18, TeamId = alphatauri.Id, Nationality = "JPN" };
            Driver rus = new Driver() { Id = 63, ShortName = "RUS", FirstName = "George", LastName = "Russel", Points = 16, TeamId = williams.Id, Nationality = "GBR" };
            Driver lat = new Driver() { Id = 6, ShortName = "LAT", FirstName = "Nicholas", LastName = "Latifi", Points = 7, TeamId = williams.Id, Nationality = "CAN" };
            Driver rai = new Driver() { Id = 7, ShortName = "RAI", FirstName = "Kimi", LastName = "Räikkönen", Points = 6, TeamId = alfaromeo.Id, Nationality = "FIN" };
            Driver gio = new Driver() { Id = 99, ShortName = "GIO", FirstName = "Antonio", LastName = "Giovinazzi", Points = 1, TeamId = alfaromeo.Id, Nationality = "ITA" };
            Driver msc = new Driver() { Id = 47, ShortName = "MSC", FirstName = "Mick", LastName = "Schumacher", Points = 0, TeamId = haas.Id, Nationality = "GER" };
            Driver kub = new Driver() { Id = 88, ShortName = "KUB", FirstName = "Robert", LastName = "Kubica", Points = 0, TeamId = alfaromeo.Id, Nationality = "POL" };
            Driver maz = new Driver() { Id = 21, ShortName = "MAZ", FirstName = "Nikita", LastName = "Mazepin", Points = 0, TeamId = haas.Id, Nationality = "RAF" };

            GrandPrix bah = new GrandPrix() { Name = "Bahrain GP", Date = new DateTime(2021, 03, 28), Track = "Bahrain International Circuit" };
            GrandPrix emil = new GrandPrix() { Name = "Emilia Romagna Grand Prix", Date = new DateTime(2021, 04, 18), Track = "Autodromo Enzo e Dino Ferrari" };
            GrandPrix port = new GrandPrix() { Name = "Portugese Grand Prix", Date = new DateTime(2021, 05, 02), Track = "Algarve International Circuit" };
            GrandPrix span = new GrandPrix() { Name = "Spanish GP", Date = new DateTime(2021, 05, 9), Track = "Circuit de Barcelona-Catalunya" };
            GrandPrix mon = new GrandPrix() { Name = "Monaco GP", Date = new DateTime(2021, 05, 23), Track = "Circuit de Monaco"};
            GrandPrix azer = new GrandPrix() { Name = "Azerbaijan GP", Date = new DateTime(2021, 06, 6), Track = "Baku City Circuit"};
            GrandPrix fre = new GrandPrix() { Name = "Circuit Paul Ricard", Date = new DateTime(2021, 06, 20), Track = "Circuit Paul Ricard"};
            GrandPrix ste = new GrandPrix() { Name = "Steiermark GP", Date = new DateTime(2021, 06, 27), Track = "Red Bull Ring"};
            GrandPrix aus = new GrandPrix() { Name = "Austrian GP", Date = new DateTime(2021, 07, 04), Track = "Red Bull Ring"};
            GrandPrix brt = new GrandPrix() { Name = "British GP", Date = new DateTime(2021, 07, 18), Track = "Silverstone Circuit"};
            GrandPrix hun = new GrandPrix() { Name = "Hungarian GP", Date = new DateTime(2021, 08, 1), Track = "Hungaroring"};

            #endregion

            modelBuilder.Entity<Team>().HasData(mercedes, redbull, mclaren, ferrari, alpine, alphatauri, astonmartin, williams, alfaromeo, haas);
            modelBuilder.Entity<Driver>().HasData(ver, ham, bot, nor, per, sai, lec, ric, gas, alo, oco, vet, str, tsu, rus, lat, rai, gio, msc, kub, maz);
            modelBuilder.Entity<GrandPrix>().HasData(bah, emil, port, span, mon, azer, fre, ste, aus, brt, hun);

        }
    }
}
