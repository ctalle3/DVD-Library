using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.BLL
{
    public class DVDManager
    {
        public IDVDRepository newDVDRepository;

        // DEPENDENCY INJECTION!!!
        public DVDManager(IDVDRepository dvdRepository)
        {
            newDVDRepository = dvdRepository;
        }
    }
}