﻿using Assign1.GetAllGetOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assign1.Controllers
{
    public class VenuesController : Controller
    {
        private Manager m = new Manager();
        // GET: Venues
        public ActionResult Index()
        {          
            var v = m.VenueGetAll();
            v.OrderBy(a => a.Company); // should work
            // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
            return View(v);
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var obj = m.VenueGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            var venu = new VenueAddViewModel();
            return View(venu);
        }

        // POST: Venues/Create        
        [HttpPost]
        public ActionResult Create(VenueAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
                return View(newItem);
            try
            {
                // Process the input
                var addedItem = m.VenueAdd(newItem);
                // If the item was not added, return the user to the Create page
                // otherwise redirect them to the Details page.
                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.VenueId });
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var obj = m.VenueGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
            {
                // Create and configure an "edit form"
                // Notice that obj is a CustomerBaseViewModel object so
                // we must map it to a CustomerEditContactFormViewModel object
                // Notice that we can use AutoMapper anywhere,
                // and not just in the Manager class.
                var formObj = m.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(obj);
                return View(formObj);
            }
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, VenueEditViewModel model)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                // Our "version 1" approach is to display the "edit form" again
                return RedirectToAction("Edit", new { id = model.VenueId });
            }
            if (id.GetValueOrDefault() != model.VenueId)
            {
                // This appears to be data tampering, so redirect the user away
                return RedirectToAction("Index");
            }
            // Attempt to do the update
            var editedItem = m.VenueEditInfo(model);
            if (editedItem == null)
            {
                // There was a problem updating the object
                // Our "version 1" approach is to display the "edit form" again
                return RedirectToAction("Edit", new { id = model.VenueId });
            }
            else
            {
                // Show the details view, which will show the updated data
                return RedirectToAction("Details", new { id = model.VenueId });
            }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.VenueGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("Index");
            }
            else
                return View(itemToDelete);
        }

        // POST: Venues/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.VenueDelete(id.GetValueOrDefault());
            // "result" will be true or false
            // We probably won't do much with the result, because
            // we don't want to leak info about the delete attempt
            // In the end, we should just redirect to the list view
            return RedirectToAction("Index");
        }
    }
}
