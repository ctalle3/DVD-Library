using DVDLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Interfaces
{
    public interface IDVDRepository
    {
        DVD CreateDVD(DVD dvd);
        List<DVD> ReadDVDList();
        List<DVD> ReadDVDTitle(string title);
        List<DVD> ReadDVDDirector(string director);
        List<DVD> ReadDVDRating(string rating);
        List<DVD> ReadDVDYear(string year);
        DVD ReadDVD(int dvdId);
        void UpdateDVD(DVD dvd);
        void DeleteDVD(int dvdId);
    }
}
