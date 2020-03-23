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
