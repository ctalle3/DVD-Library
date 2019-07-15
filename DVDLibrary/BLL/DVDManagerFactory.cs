using DVDLibrary.Controllers;
using DVDLibrary.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLibrary.BLL
{
    public class DVDManagerFactory
    {
        public static DVDManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DVDManager(new DVDRepositoryMock()); 
                case "ADO":
                    return new DVDManager(new DVDRepositoryADO());
                case "EntityFramework":
                    return new DVDManager(new DVDRepositoryEF());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}