using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstApp.Models;
using FirstApp.ViewModels;

namespace FirstApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
            public ActionResult Random()
        {
            var movie = new Movie() { Name = "li", Id = 1 };
            var customers = new List<Customer>
            {
                new Customer{Name="cus1"},
                new Customer{Name="cus2"}
            };
            var viewModel = new RandomMovieViewModel (){ Movie=movie,Customer=customers};
            
            return View(viewModel);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

    }
}