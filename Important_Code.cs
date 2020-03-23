 //First Way to route customize       
        ///In controller file
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }
            
         ///INn Route.config file   
            routes.MapRoute(
                "MovieByReleaseDate",
                "movies/released/{year}/{month}",
                new { Controller ="Movies",Action="ByReleaseDate"},
                new {year =@"\d{4}",month=@"\d{2}" }
                );
//Second Way to route customize 
             routes.MapMvcAttributeRoutes();//add to route.config
//Add to controller
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }
////////////////////////////////////////////////////////////

        public ActionResult index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))

            {
                sortBy = "Name";
            }
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
///////////////////////////////////////Checking return type //////////////////////////////
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", Id = 101, Description = "This is good movie" };
            //return View(movie);
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortByName = "Ahsan" });
        }
///////////////////////////////View file////////////////////////////////////////////////
@model Vidly03.Models.Movie
@{
    ViewBag.Title = "Random";
}

<h2>@Model.Name</h2>
///////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }
/////////////////////////////////////////////////////////////////////////////////////////////



