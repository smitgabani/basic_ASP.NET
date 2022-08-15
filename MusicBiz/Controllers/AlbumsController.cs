using S2022A5SG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A5SG.Controllers
{
    public class AlbumsController : Controller
    {
        Manager m = new Manager();
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5
        [Authorize(Roles = "Executive, Coordinator, Clerk, Staff")]
        public ActionResult Details(int? id)
        {
            var obj = m.AlbumGetById(id.GetValueOrDefault());
            if (obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(obj);
            }

        }

        // GET: Albums/Create
        

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // Get /Albums/AddTrack
        [Authorize(Roles = "Clerk"), Route("albums/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());

            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {
                var trackAdd = new TrackAddFormViewModel();
                trackAdd.AlbumId = album.Id;
                trackAdd.AlbumName = album.Name;
                trackAdd.TrackGenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(trackAdd);
            }
        }

        [Authorize(Roles = "Clerk"), Route("albums/{id}/addtrack")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTrack(TrackAddViewModel track)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(track);
                }
                
                var addedTrack = m.TrackAdd(track);

                if (addedTrack == null)
                {
                    return View(track);
                }
                else
                {
                    return RedirectToAction("details", "tracks", new { id = addedTrack.Id });
                }
            }
            catch
            {
                return View();
            }
        }


    }
}
