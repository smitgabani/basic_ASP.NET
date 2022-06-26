// ************************************************************************************
// WEB524 Project Template V1 2224 == c7a2a227-cf1a-4822-8ae4-35caccf5eeb0
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************


using Assignment2.Models;
using AutoMapper;
using S2022A2SAG.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2022A2SAG.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();

                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            var track = from t in ds.Tracks
                        orderby t.Name
                        select t;

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(track);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllRockMetal()
        {
            var rockmetal = from j in ds.Tracks
                       where j.GenreId == 1 || j.GenreId == 3
                       orderby j.Name, j.Composer
                       select j;

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(rockmetal);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllTylerVallance()
        {
            var tylerVallance = from r in ds.Tracks
                              where r.Composer.Contains("Steven Tyler") && r.Composer.Contains("Jim Vallance")
                              orderby r.Name
                              select r;

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tylerVallance);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Longest()
        {
            var longest = (from l in ds.Tracks
                             orderby l.Milliseconds descending
                             select l).Take(50);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(longest);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Smallest()
        {
            var smallest = (from l in ds.Tracks
                             orderby l.Bytes
                             select l).Take(50);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(smallest);
        }
        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            var inv = from i in ds.Invoices
                      orderby i.InvoiceDate descending
                      select i;

            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(inv);

        }

        public InvoiceBaseViewModel InvoiceGetById(int? id)
        {
            //Attempt to fetch the object
            var obj = ds.Invoices.Find(id);

            return obj == null ? null : mapper.Map<Invoice, InvoiceBaseViewModel>(obj);
        }

        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int? id)
        {
            var obj = ds.Invoices.Include("Customer.Employee").Include("InvoiceLines.Track.MediaType").Include("InvoiceLines.Track.Album.Artist").SingleOrDefault(i => i.InvoiceId == id);

            return (obj == null) ? null : mapper.Map<Invoice, InvoiceWithDetailViewModel>(obj);
        }

        internal object InvoiceGetById(object value)
        {
            throw new NotImplementedException();
        }
    }
}