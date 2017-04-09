using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
// new...
using AutoMapper;
using BtsIntegrated.Models;
using System.Security.Claims;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;

namespace BtsIntegrated.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper components
        MapperConfiguration config;
        public IMapper mapper;

        // Request user property...

        // Backing field for the property
        private RequestUser _user;

        // Getter only, no setter
        public RequestUser User
        {
            get
            {
                // On first use, it will be null, so set its value
                if (_user == null)
                {
                    _user = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);
                }
                return _user;
            }
        }

        // Default constructor...
        public Manager()
        {
            // If necessary, add constructor code here

            // Configure the AutoMapper components
            config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                // Object mapper definitions

                //cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

                //mappig for getting data from the database
                cfg.CreateMap<Models.Location, Controllers.LocationBase>();
                cfg.CreateMap<Models.Location, Controllers.LocationWithTimings>();
                cfg.CreateMap<Models.Location, Controllers.LocationDetailWithComment>();
                cfg.CreateMap<Models.Timing, Controllers.TimingBase>();
                cfg.CreateMap<Models.Comment, Controllers.CommentBase>();
                cfg.CreateMap<Models.Comment, Controllers.CommentAdd>();
                cfg.CreateMap<Rating, RatingBase>();

                //mapping for storing data to database
                cfg.CreateMap<Controllers.LocationAdd, Models.Location>();
                cfg.CreateMap<Controllers.TimingAdd, Models.Timing>();
                cfg.CreateMap<Controllers.CommentAdd, Models.Comment>();
                cfg.CreateMap<RatingAdd, Rating>();

                cfg.CreateMap<Controllers.CommentAdd, Controllers.CommentEditForm>();
                cfg.CreateMap<Controllers.CommentBase, Controllers.CommentEditForm>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // ############################################################
        // RoleClaim

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()



        //get all locations
        public IEnumerable<LocationBase> LocationGetAll()
        {
            return mapper.Map<IEnumerable<LocationBase>>(ds.Locations);
        }

        //get one
        public LocationWithTimings LocationGetOne(int? id)
        {
            var data = ds.Locations.Include("Timing").SingleOrDefault(i=>i.LocationId==id);
            return (data == null) ? null : mapper.Map<LocationWithTimings>(data);
        }

        public LocationWithTimings LocationEditExisting(LocationWithTimings newItem)
        {
            var data = ds.Locations.Include("Timing").SingleOrDefault(i=>i.LocationId==newItem.LocationId);
            var time = ds.Timings.SingleOrDefault(i=>i.TimingId == newItem.LocationId);
            
            if (data == null)
            {
                return null;
            }
            if (time == null)
            {
                return null;
            }
            var newTiming = new Timing
            {
                //timing addition
                TimingId =  newItem.LocationId,
                MondayOpeningTime = newItem.TimingMondayOpeningTime,
                MondayClosingTime = newItem.TimingMondayClosingTime,
                TuesdayOpeningTime = newItem.TimingTuesdayOpeningTime,
                TuesdayClosingTime = newItem.TimingTuesdayClosingTime,
                WednesdayOpeningTime = newItem.TimingWednesdayOpeningTime,
                WednesdayClosingTime = newItem.TimingWednesdayClosingTime,
                ThursdayOpeningTime = newItem.TimingThursdayOpeningTime,
                ThursdayClosingTime = newItem.TimingThursdayClosingTime,
                FridayOpeningTime = newItem.TimingFridayOpeningTime,
                FridayClosingTime = newItem.TimingFridayClosingTime,
                SaturdayOpeningTime = newItem.TimingSaturdayOpeningTime,
                SaturdayClosingTime = newItem.TimingSaturdayClosingTime,
                SundayOpeningTime = newItem.TimingSundayOpeningTime,
                SundayClosingTime = newItem.TimingSundayClosingTime


                //timing addition end
            };
            if ((data.Address != newItem.Address)||(data.PostalCode != newItem.PostalCode))
            {
                var latlng = LatLongCoordsDoubles(newItem);
                newItem.Latitude = latlng[0];
                newItem.Longitude = latlng[1];
            }
            ds.Entry(time).CurrentValues.SetValues(newTiming);
            ds.Entry(data).CurrentValues.SetValues(newItem);
            //ds.Entry(data.Timing).CurrentValues.SetValues(newItem);
            ds.SaveChanges();
            return mapper.Map<LocationWithTimings>(data);
        }

        public LocationWithTimings LocationAdd(LocationWithTimings newLocation)
        {
            //var addedLocationTiming = ds.Timings.Add(mapper.Map<Timing>(newLocation.Timings));
            var addedLocation = ds.Locations.Add(mapper.Map<Location>(newLocation));
            
            addedLocation.Timing = new Timing
            {
                //timing addition
                MondayOpeningTime = newLocation.TimingMondayOpeningTime,
                MondayClosingTime = newLocation.TimingMondayClosingTime,
                TuesdayOpeningTime = newLocation.TimingTuesdayOpeningTime,
                TuesdayClosingTime = newLocation.TimingTuesdayClosingTime,
                WednesdayOpeningTime = newLocation.TimingWednesdayOpeningTime,
                WednesdayClosingTime = newLocation.TimingWednesdayClosingTime,
                ThursdayOpeningTime = newLocation.TimingThursdayOpeningTime,
                ThursdayClosingTime = newLocation.TimingThursdayClosingTime,
                FridayOpeningTime = newLocation.TimingFridayOpeningTime,
                FridayClosingTime = newLocation.TimingFridayClosingTime,
                SaturdayOpeningTime = newLocation.TimingSaturdayOpeningTime,
                SaturdayClosingTime = newLocation.TimingSaturdayClosingTime,
                SundayOpeningTime = newLocation.TimingSundayOpeningTime,
                SundayClosingTime = newLocation.TimingSundayClosingTime
                //timing addition end
            };
            var latlng = LatLongCoordsDoubles(newLocation);
            addedLocation.Latitude = latlng[0];
            addedLocation.Longitude = latlng[1];
            ds.Timings.Add(addedLocation.Timing);
            ds.SaveChanges();
            return mapper.Map<LocationWithTimings>(addedLocation);
        }

        public double[] GetUserLatLngCoords(string input)
        {
            double[] coords = new double[2];
            //var postalCode = input.Replace(" ", "");
            var requestUri = $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(input)}&sensor=false";
            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse")?.Element("result");
            var locationElement = result?.Element("geometry")?.Element("location");
            var lat = locationElement?.Element("lat");
            var lng = locationElement?.Element("lng");
            if (lat != null)
            {
                coords[0] = Convert.ToDouble(lat.Value);
            }
            if (lng != null)
            {
                coords[1] = Convert.ToDouble(lng.Value);
            }
            return coords;
        }

        /*
         * Returns an arry of double of size 2 i.e. 0 and 1. 
         * Each array index contains the data for the coordinates of a locaiton provided a variable
         * of type LocationWithTimings from which it will extract the necessary data to gives geo locaiton
         * coordinates
         * 
         * 0 - Latitude
         * 1 - Longitude
         */
        public double[] LatLongCoordsDoubles(LocationWithTimings data)
        {
            double[] coords = new double[2];

            var addressFull = data.Address + "," + data.City + "," + data.PostalCode;
            //var address = "123 something st, somewhere";
            var address = addressFull;
            var requestUri = $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(address)}&sensor=false";
            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse")?.Element("result");
            var locationElement = result?.Element("geometry")?.Element("location");
            var lat = locationElement?.Element("lat");
            var lng = locationElement?.Element("lng");
            if (lat != null)
            {
                coords[0] = Convert.ToDouble(lat.Value);
            }
            if (lng != null)
            {
                coords[1] = Convert.ToDouble(lng.Value);
            }
            return coords;
        }

        public void LocationRemove(int? id)
        {
            var location = ds.Locations.Find(id.GetValueOrDefault());
            if (location == null)
            {
                return;
            }
            ds.Locations.Remove(location);
            ds.SaveChanges();
        }

        //Comments Methods

        public IEnumerable<CommentBase> CommentsGetAll()
        {
            return mapper.Map<IEnumerable<CommentBase>>(ds.Comments);
        }

        /*public IEnumerable<CommentWithLocation> GetCommentsOneLocation(int id)
        {
            var data = ds.Comments.Include("Location").SingleOrDefault(i => i.Location.LocationId == id);
            return (data == null) ? null : mapper.Map<IEnumerable<CommentWithLocation>>(data);
        }*/


        //Comment get 1 for edit
        public CommentBase CommentGetById(int id)
        {
            var o = ds.Comments.SingleOrDefault
                (c => c.CommentId == id && c.UserName == HttpContext.Current.User.Identity.Name);
            return (o == null) ? null : mapper.Map<CommentBase>(o);
        }
        public CommentBase CommentEdit(CommentEdit newComment)
        {
            var o = ds.Comments.SingleOrDefault
                (c => c.CommentId == newComment.CommentId && c.UserName == HttpContext.Current.User.Identity.Name);

            if (o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newComment);
                ds.SaveChanges();
                return mapper.Map<CommentBase>(o);
            }
        }
        public CommentBase CommentEdit2(CommentEdit newComment)
        {
            var o = ds.Comments.Include("location").SingleOrDefault
                (c => c.CommentId == newComment.CommentId && c.UserName == HttpContext.Current.User.Identity.Name);

            if (o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newComment);
                ds.SaveChanges();
                return mapper.Map<CommentBase>(o);
            }
        }
        public LocationDetailWithComment LocationGetOneWithComment(int id)
        {
            var data = ds.Locations.Include("Timing").Include("Comments")
                .SingleOrDefault(i => i.LocationId == id);
            return mapper.Map<LocationDetailWithComment>(data);
        }

        public CommentAdd LocationAddComment(CommentAdd newComment)
        {
            var addComment = ds.Comments.Add(mapper.Map<Comment>(newComment));
            addComment.UserName = HttpContext.Current.User.Identity.Name;
            ds.SaveChanges();
            return (addComment == null) ? null : mapper.Map<CommentAdd>(addComment);
        }
        public bool RemoveComment(int? id)
        {
            var c = ds.Comments.Find(id.GetValueOrDefault());
            if (c != null)
            {
                ds.Comments.Remove(c);
                ds.SaveChanges();
                return true;
            }
            return false;
        }

        //Ratings Methods

        //public RatingBase GetOneLoactionForRating(int id)
        //{

        //}
        public void RatingAdd(RatingAdd newRating)
        {
            var addedRating = ds.Ratings.Add(mapper.Map<Rating>(newRating));
            addedRating.UserName = HttpContext.Current.User.Identity.Name;
            ds.SaveChanges();
        }

        public double GetAvgRatingForOneLocation(int id)
        {
            double avg = 0;
            var data = (from x in ds.Ratings where x.LocationId.Equals(id) select x).ToList();
            if (data.Any())
            {
                avg = (from x in data select x.Value).Average();
            }
            //var data = ds.Ratings.SingleOrDefault(i => i.Location.LocationId == id);
            return avg;
        }

        //End of Comment Section

        // Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

        public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // ############################################################
            // Role claims

            if (ds.RoleClaims.Count() == 0)
            {
                // Add role claims here

                //ds.SaveChanges();
                //done = true;
            }

            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.RoleClaims)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    // New "RequestUser" class for the authenticated user
    // Includes many convenient members to make it easier to render user account info
    // Study the properties and methods, and think about how you could use it

    // How to use...

    // In the Manager class, declare a new property named User
    //public RequestUser User { get; private set; }

    // Then in the constructor of the Manager class, initialize its value
    //User = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);

    public class RequestUser
    {
        // Constructor, pass in the security principal
        public RequestUser(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                // You can change the string value in your app to match your app domain logic
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            // Compose the nicely-formatted full names
            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

}