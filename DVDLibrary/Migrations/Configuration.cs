namespace DVDLibrary.Migrations
{
    using DVDLibrary.Models.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibrary.Models.Repositories.EF.DVDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibrary.Models.Repositories.EF.DVDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.DVDs.AddOrUpdate(
                d => d.Title,
                new DVD
                {
                    Title = "Star Wars",
                    ReleaseYear = 1977,
                    Director = "George Lucas",
                    Rating = "PG",
                    Notes = "Luke loses a hand"
                }
            );

            context.DVDs.AddOrUpdate(
                d => d.Title,
                new DVD
                {
                    Title = "Shrek",
                    ReleaseYear = 2001,
                    Director = "Andrew Adamson",
                    Rating = "PG",
                    Notes = "Fiona is an Ogre!"
                }
            );

            context.DVDs.AddOrUpdate(
                d => d.Title,
                new DVD
                {
                    Title = "Spider-man",
                    ReleaseYear = 2019,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Notes = null
                }
            );

            context.DVDs.AddOrUpdate(
                d => d.Title,
                new DVD
                {
                    Title = "Die Hard",
                    ReleaseYear = 1988,
                    Director = "John McTiernan",
                    Rating = "R",
                    Notes = "Classic Bruce Willis."
                }
            );

            context.DVDs.AddOrUpdate(
                d => d.Title,
                new DVD
                {
                    Title = "The Emperor's New Groove",
                    ReleaseYear = 2000,
                    Director = "Mark Dindal",
                    Rating = "G",
                    Notes = "Will he ever find his groove again??"
                }
            );
        }
    }
}
