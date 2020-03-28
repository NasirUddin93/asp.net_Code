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
@Html.EditorForModel()  // Add to cshtml file to autogenerate the input form
    public class EmployeeModel
    {
        [Display(Name ="Employee ID")]
        [Range(100000,999999,ErrorMessage ="You need to enter valid EmployeeId")]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        [Required( ErrorMessage = "You need to enter First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to enter Last Name")]

        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to enter Email address")]

        public string EmailAddress { get; set; }
        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress",ErrorMessage ="You must match email address and confirm email !")]
        public string ConfirmEmail { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage ="You must have pass")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength =10,ErrorMessage ="You need to provide long password")]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Your password and confirm password must match.")]
        public string ConfirmPassword { get; set; }
    }
/////////////////////////////////////////////////////////////////////////////////////////////
        //http://localhost:51727/home/index/10?name=nasi
        public string Index(string id)
        {
            return "This is good for me "+id+Request.QueryString["name"];
        }
/////Another way to do samething
        public string Index(string id,string name)
        {
            return "This is good for me "+id+name;
        }
//////////////////////////////////////////ViewBag//////////////////////////////////////////////////
    public ActionResult Index()     ///Controller file
        {
            ViewBag.Countries = new List<string>
            {
                "Bangladesh",
                "India",
                "Pakistan",
                "US"
            };
            return View();           
        }
<ul>               /// View file
    @foreach (string strCountries in ViewBag.Countries)
    {
        <li>@strCountries</li>
    }

</ul>
////////////////////////////////////ViewData///////////////////////////////////
    public ActionResult Index()
        {
            ViewData["Countries"] = new List<string>
            {
                "Bangladesh",
                "India",
                "Pakistan",
                "US"
            };
            return View();           
        }
    }
    <ul>
    @foreach (string strCountries in (List<string>)ViewData["Countries"])
    {
        <li>@strCountries</li>
    }

</ul>
///////////////////////////////////////////////////////////////////////////////
    public class Employee          ///Model file
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
    public ActionResult Details()  ///Controller file
        {
            Employee employee = new Employee()
            {
                EmployeeId = 101,
                Name = "John",
                Gender = "Male",
                City = "London"
            };

            return View(employee);
        }
@model MVCDemo06.Models.Employee  ///view file

@{
    ViewBag.Title = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Details</h2>

<div>
    <h4>Employee</h4>
    <table border="1">
        <tr>
            <td>Employee ID</td>
            <td>@Model.EmployeeId</td>
        </tr>
        <tr>
            <td>Name</td>
            <td>@Model.Name</td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>@Model.Gender</td>
        </tr>
        <tr>
            <td>City</td>
            <td>@Model.City</td>
        </tr>
    </table>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", new { id = Model.EmployeeId }) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
////////////////////////////////////////////////////////////////////////////////
 @Html.DisplayNameFor(model => model.ProductId)  ///Provide Variable 
  @Html.DisplayFor(model => model.ProductId)   //Provides value
 ///////////////////////////////////////////////////////////////////////////// 



