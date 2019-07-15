using DVDLibrary.BLL;
using DVDLibrary.Models.Data;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDLibrary.Controllers
{
    public class DVDController : ApiController
    {
        private IDVDRepository _repository;

        DVDManager manager = DVDManagerFactory.Create();

        public DVDController()
        {
            DVDRepositoryMock mock = new DVDRepositoryMock();
            DVDRepositoryEF ef = new DVDRepositoryEF();
            DVDRepositoryADO ado = new DVDRepositoryADO();

            if (manager.newDVDRepository.GetType() == mock.GetType())
            {
                _repository = manager.newDVDRepository;
            }
            else if (manager.newDVDRepository.GetType() == ef.GetType())
            {
                _repository = ef;
            }
            else
            {
                _repository = ado;
            }
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllDVDs()
        {
            return Ok(_repository.ReadDVDList());
        }

        //Make jQuery for this feature
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVD(int dvdId)
        {
            DVD dvd = _repository.ReadDVD(dvdId);

            if(dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }
            
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create(DVD dvd)
        {
            // Validation needed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DVD newDVD = new DVD()
            {
                Title = dvd.Title,
                ReleaseYear = dvd.ReleaseYear,
                Director = dvd.Director,
                Rating = dvd.Rating,
                Notes = dvd.Notes
            };

            _repository.CreateDVD(newDVD);

            return Created($"dvd/{newDVD.DVDId}", newDVD);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(DVD dvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DVD editedDVD = _repository.ReadDVD(dvd.DVDId);

            if (editedDVD == null)
            {
                return NotFound();

            }

            editedDVD = dvd;

            _repository.UpdateDVD(editedDVD);
            return Ok(editedDVD);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            DVD dvd = _repository.ReadDVD(dvdId);

            if(dvd == null)
            {
                return NotFound();
            }

            _repository.DeleteDVD(dvdId);
            return Ok();
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllDVDsByTitle(string title)
        {
            return Ok(_repository.ReadDVDTitle(title));
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllDVDsByYear(string releaseYear)
        {
            return Ok(_repository.ReadDVDYear(releaseYear));
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllDVDsByDirector(string director)
        {
            return Ok(_repository.ReadDVDDirector(director));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllDVDsByRating(string rating)
        {
            return Ok(_repository.ReadDVDRating(rating));
        }
    }
}