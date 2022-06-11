// ************************************************************************************
// WEB524 Project Template V1 2224 == 81ed9814-f987-4212-b742-d1d07897411a
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

using Assign1.EntityModels;
using Assign1.GetAllGetOne;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assign1.Controllers
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

                cfg.CreateMap<Customer, CustomerBaseViewModel>();

                // Map from CustomerAddViewModel to Customer design model.
                cfg.CreateMap<CustomerAddViewModel, Customer>();

                cfg.CreateMap<CustomerAddViewModel, CustomerEditContactFormViewModel>();

                // // // // //

                cfg.CreateMap<Venue, VenueBaseViewModel>();
                cfg.CreateMap<VenueAddViewModel, Venue>();
                cfg.CreateMap<VenueAddViewModel, VenueEditFormViewModel>();

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

        public IEnumerable<CustomerBaseViewModel> CustomerGetAll()
        {
            // // Define a new empty view model collection
            // var results = new List<CustomerBaseViewModel>();
            // // Fetch all the objects from the data store
            // var allCustomers = ds.Customers;
            // // Manually map each source object to a target object
            // foreach (var customer in allCustomers)
            // {
            //     // Create and configure a new target object
            //     var c = new CustomerBaseViewModel();
            //     c.Address = customer.Address;
            //     c.City = customer.City;
            //     c.Company = customer.Company;
            //     c.Country = customer.Country;
            //     c.CustomerId = customer.CustomerId;
            //     c.Email = customer.Email;
            //     c.Fax = customer.Fax;
            //     c.FirstName = customer.FirstName;
            //     c.LastName = customer.LastName;
            //     c.Phone = customer.Phone;
            //     c.PostalCode = customer.PostalCode;
            //     c.State = customer.State;
            //     // Add the new target object to the results collection
            //     results.Add(c);
            // }
            // // Return the results
            // return results;

            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerBaseViewModel>>(ds.Customers);
        }

        public CustomerBaseViewModel CustomerGetById(int id)
        {
            //Attempt to fetch the object
            var obj = ds.Customers.Find(id);

            //Return the result (or null if not found).
            return obj == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(obj);
        }

        public CustomerBaseViewModel CustomerAdd(CustomerAddViewModel newCustomer)
        {
            // Attempt to add the new item.
            // Notice how we map the incoming data to the Customer design model class.
            var addedItem = ds.Customers.Add(mapper.Map<CustomerAddViewModel, Customer>(newCustomer));
            ds.SaveChanges();
            // If successful, return the added item (mapped to a view model class).
            return addedItem == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(addedItem);
        }

        public CustomerBaseViewModel CustomerEditContactInfo(CustomerEditContactViewModel customer)
        {
            // Attempt to fetch the object.
            var obj = ds.Customers.Find(customer.CustomerId);
            if (obj == null)
            {
                // Customer was not found, return null.
                return null;
            }
            else
            {
                // Customer was found. Update the entity object
                // with the incoming values then save the changes.
                ds.Entry(obj).CurrentValues.SetValues(customer);
                ds.SaveChanges();
                // Prepare and return the object.
                return mapper.Map<Customer, CustomerBaseViewModel>(obj);
            }
        }

        public bool CustomerDelete(int id)
        {
            // Attempt to fetch the object to be deleted
            var itemToDelete = ds.Customers.Find(id);
            if (itemToDelete == null)
                return false;
            else
            {
                // Remove the object
                ds.Customers.Remove(itemToDelete);
                ds.SaveChanges();
                return true;
            }
        }
        // // // // // Venues 
        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(ds.Venues);
        }

        public VenueBaseViewModel VenueGetById(int id)
        {
            //Attempt to fetch the object
            var obj = ds.Venues.Find(id);

            //Return the result (or null if not found).
            return obj == null ? null : mapper.Map<Venue, VenueBaseViewModel>(obj);
        }

        public VenueBaseViewModel VenueAdd(VenueAddViewModel newVenue)
        {
            // Attempt to add the new item.
            // Notice how we map the incoming data to the Customer design model class.
            var addedItem = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(newVenue));
            ds.SaveChanges();
            // If successful, return the added item (mapped to a view model class).
            return addedItem == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addedItem);
        }

        public VenueBaseViewModel VenueEditViewModel(VenueEditViewModel venue)
        {
            // Attempt to fetch the object.
            var obj = ds.Venues.Find(venue.VenueId);
            if (obj == null)
            {
                // Customer was not found, return null.
                return null;
            }
            else
            {
                // Customer was found. Update the entity object
                // with the incoming values then save the changes.
                ds.Entry(obj).CurrentValues.SetValues(venue);
                ds.SaveChanges();
                // Prepare and return the object.
                return mapper.Map<Venue, VenueBaseViewModel>(obj);
            }
        }

        public VenueBaseViewModel VenueEditInfo(VenueEditViewModel venue)
        {
            // Attempt to fetch the object.
            var obj = ds.Venues.Find(venue.VenueId);
            if (obj == null)
            {
                // Customer was not found, return null.
                return null;
            }
            else
            {
                // Customer was found. Update the entity object
                // with the incoming values then save the changes.
                ds.Entry(obj).CurrentValues.SetValues(venue);
                ds.SaveChanges();
                // Prepare and return the object.
                return mapper.Map<Venue, VenueBaseViewModel>(obj);
            }
        }

        public bool VenueDelete(int id)
        {
            // Attempt to fetch the object to be deleted
            var itemToDelete = ds.Venues.Find(id);
            if (itemToDelete == null)
                return false;
            else
            {
                // Remove the object
                ds.Venues.Remove(itemToDelete);
                ds.SaveChanges();
                return true;
            }
        }



    }

}