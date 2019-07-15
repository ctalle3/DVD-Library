using DVDLibrary.Models.Data;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DVDLibrary.Models.Repositories
{
    public class DVDRepositoryEF : IDVDRepository
    {
        public DVD CreateDVD(DVD dvd)
        {
            var repository = new DVDContext();

            DVD returnNewDVD = new DVD();

            var selectedDVDs = (from selectedDVD in repository.DVDs
                                select new
                                {
                                    Title = dvd.Title,
                                    ReleaseYear = dvd.ReleaseYear,
                                    Director = dvd.Director,
                                    Rating = dvd.Rating,
                                    Notes = dvd.Notes
                                }).ToList().Select(d => new DVD()
                                {
                                    Title = d.Title,
                                    ReleaseYear = d.ReleaseYear,
                                    Director = d.Director,
                                    Rating = d.Rating,
                                    Notes = d.Notes
                                });
            

            foreach(DVD newDVD in selectedDVDs.Take(1))
            {
                repository.DVDs.Add(newDVD);
                repository.SaveChanges();
                returnNewDVD = newDVD;
            }

            return returnNewDVD; 
        }

        public void DeleteDVD(int dvdId)
        {
            var repository = new DVDContext();

            var chosenDVD = repository.DVDs.FirstOrDefault(d => d.DVDId == dvdId);

            repository.DVDs.Remove(chosenDVD);
            repository.SaveChanges();
        }

        public DVD ReadDVD(int dvdId)
        {
            var repository = new DVDContext();

            var chosenDVD = repository.DVDs.FirstOrDefault(d => d.DVDId == dvdId);

            return chosenDVD;
        }

        public List<DVD> ReadDVDDirector(string director)
        {
            var repository = new DVDContext();

            List<DVD> dvdList = repository.DVDs.ToList();

            List<DVD> searchList = dvdList.FindAll(d => d.Director.ToUpper().Contains(director.ToUpper()));

            return searchList;
        }

        public List<DVD> ReadDVDList()
        {
            var repository = new DVDContext();

            List<DVD> dvdList = repository.DVDs.ToList();

            return dvdList;
        }

        public List<DVD> ReadDVDRating(string rating)
        {
            var repository = new DVDContext();

            List<DVD> dvdList = repository.DVDs.ToList();

            List<DVD> searchList = dvdList.FindAll(d => d.Rating.ToUpper().Contains(rating.ToUpper()));

            return searchList;
        }

        public List<DVD> ReadDVDTitle(string title)
        {
            var repository = new DVDContext();

            List<DVD> dvdList = repository.DVDs.ToList();

            List<DVD> searchList = dvdList.FindAll(d => d.Title.ToUpper().Contains(title.ToUpper()));

            return searchList;
        }

        public List<DVD> ReadDVDYear(string year)
        {
            var repository = new DVDContext();

            List<DVD> dvdList = repository.DVDs.ToList();

            List<DVD> searchList = dvdList.FindAll(d => d.ReleaseYear.ToString().Equals(year)); // .Contains(year.ToUpper()));

            return searchList;
        }

        public void UpdateDVD(DVD dvd)
        {
            var repository = new DVDContext();

            var chosenDVD = repository.DVDs.FirstOrDefault(d => d.DVDId == dvd.DVDId);

            repository.Entry(chosenDVD).CurrentValues.SetValues(dvd);
            repository.SaveChanges(); 
        }
    }
}