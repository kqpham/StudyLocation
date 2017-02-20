using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using AutoMapper;
using BtsProjectSite.Models;

namespace BtsProjectSite.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        private MapperConfiguration config;

        public IMapper mapper;

        public Manager()
        {
            config = new MapperConfiguration(cfg =>
            {
                //mappig for getting data from the database
                cfg.CreateMap<Models.Location, Controllers.LocationBase>();
                cfg.CreateMap<Models.Location, Controllers.LocationWithTimings>();
                cfg.CreateMap<Models.Timing, Controllers.TimingBase>();

                //mapping for storing data to database
                cfg.CreateMap<Controllers.LocationAdd, Models.Location>();
                cfg.CreateMap<Controllers.TimingAdd, Models.Timing>();

            });

            mapper = config.CreateMapper();

            ds.Configuration.ProxyCreationEnabled = false;

            ds.Configuration.LazyLoadingEnabled = false;
        }

        //get all locations
        public IEnumerable<LocationBase> LocationGetAll()
        {
            return mapper.Map<IEnumerable<LocationBase>>(ds.LocationsBase);
        }

        //get one
        public LocationWithTimings LocationGetOne(int? id)
        {
            var data = ds.LocationsBase.Find(id);
            return (data == null) ? null : mapper.Map<LocationWithTimings>(data);
        }

        public LocationWithTimings LocationEditExisting(LocationWithTimings newItem)
        {
            var data = ds.LocationsBase.Find(newItem.LocationId);
            if (data == null)
            {
                return null;
            }
            ds.Entry(data).CurrentValues.SetValues(newItem);
            ds.SaveChanges();
            return mapper.Map<LocationWithTimings>(data);
        }

        public LocationWithTimings LocationAdd(LocationWithTimings newLocation)
        {
            var addedLocation = ds.LocationsBase.Add(mapper.Map<LocationWithTimings>(newLocation));
            ds.SaveChanges();
            return (addedLocation == null) ? null : mapper.Map<LocationWithTimings>(addedLocation);
        }

        public void LocationRemove(int? id)
        {
            var location = ds.LocationWithTimings.Find(id.GetValueOrDefault());
            if (location==null)
            {
                return;
            }
            ds.LocationWithTimings.Remove(location);
            ds.SaveChanges();
        }
    }
}