using DVDLibrary.Models.Data;
using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models.Repositories
{
    public class DVDRepositoryMock : IDVDRepository
    {
        private static DVD _dvd1 = new DVD
        {
            DVDId = 1,
            Title = "A Great Tale",
            ReleaseYear = 2015,
            Director = "Sam Jones",
            Rating = "PG",
            Notes = "This really is a great tale!"
        };

        private static DVD _dvd2 = new DVD
        {
            DVDId = 2,
            Title = "A Good Tale",
            ReleaseYear = 2012,
            Director = "Joe Smith",
            Rating = "PG-13",
            Notes = "This is a good tale!"
        };

        public static List<DVD> _dvdList = new List<DVD>() { _dvd1, _dvd2 };


        public DVD CreateDVD(DVD dvd)
        {
            dvd.DVDId = _dvdList.Max(d => d.DVDId) + 1;
            _dvdList.Add(dvd);

            return dvd;
        }

        public DVD ReadDVD(int dvdId)
        {
            return _dvdList.FirstOrDefault(m => m.DVDId == dvdId);
        }

        public List<DVD> ReadDVDList()
        {
            return _dvdList;
        }

        public List<DVD> ReadDVDTitle(string title)
        {
            return _dvdList.FindAll(m => m.Title.ToUpper().Contains(title.ToUpper()));
        }

        public List<DVD> ReadDVDDirector(string director)
        {
            List<DVD> searchList = _dvdList.FindAll(m => m.Director.ToUpper().Contains(director.ToUpper()));
            return searchList;
        }

        public List<DVD> ReadDVDRating(string rating)
        {
            List<DVD> searchList = _dvdList.FindAll(m => m.Rating.ToUpper().Contains(rating.ToUpper()));
            return searchList;
        }

        public List<DVD> ReadDVDYear(string year)
        {
            return _dvdList.FindAll(m => m.ReleaseYear.ToString().Contains(year));
        }

        public void UpdateDVD(DVD dvd)
        {
            var found = _dvdList.FirstOrDefault(m => m.DVDId == dvd.DVDId);

            _dvdList.RemoveAll(m => m.DVDId == dvd.DVDId);

            if (found != null)
            {
                found = dvd;
            }

            _dvdList.Add(found);
        }

        public void DeleteDVD(int dvdId)
        {
            _dvdList.RemoveAll(m => m.DVDId == dvdId);
        }
    }
}