using S2022A5SG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A5SG.Controllers
{
    
    public class ArtistsController : Controller
    {
        Manager m = new Manager();
        // GET: Artists
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var obj = m.ArtistGetById(id.GetValueOrDefault());
            if (obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(obj);
            }
        }
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var artist = new ArtistAddFormViewModel();

            artist.Executive = User.Identity.Name;
            artist.ArtistGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(artist);
        }
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult Create(ArtistAddViewModel artist)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(artist);
                }

                var addedArtist = m.ArtistAdd(artist);

                if (addedArtist == null)
                {
                    return View(addedArtist);
                }
                else
                {
                    return RedirectToAction("details", new { id = addedArtist.Id});
                }

            }
            catch
            {
                return View();
            }
        }
        
        [Authorize(Roles = "Coordinator"), Route("artists/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var albumAdd = new AlbumAddFormViewModel();
                albumAdd.ArtistId = artist.Id;
                albumAdd.ArtistName = artist.Name;
                albumAdd.AlbumGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                var selectedArtists = new List<int> { artist.Id };
                albumAdd.ArtistList = new MultiSelectList(m.ArtistGetAll(), "ArtistId", "Name", selectedArtists);
                albumAdd.TrackList = new MultiSelectList(m.TrackGetAllByArtistId(artist.Id), "Id", "Name");
                return View(albumAdd);
            }
        }

        // POST: Artists/Create
        //Once user input on the page, this function will be triggered.
        [Authorize(Roles = "Coordinator"), Route("artists/{id}/addalbum")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel album)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(album);
                }

                var addedAlbum = m.AlbumAdd(album);

                if (addedAlbum == null)
                {
                    return View(album);
                }
                else
                {
                    return RedirectToAction("Details", "Albums", new { id = addedAlbum.Id });
                }

            }
            catch
            {
                return View();
            }
        }
    }
}