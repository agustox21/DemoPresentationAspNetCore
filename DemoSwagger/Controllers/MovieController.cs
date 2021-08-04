using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DemoSwagger.Model;

namespace DemoSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MvcMovieContext _context;

        public MovieController(MvcMovieContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.Movie.ToList());
        }

        [HttpPost]
        public JsonResult Post(Movie obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return new JsonResult("Added Successfully with ID=" + obj.Id.ToString());
        }

        [HttpPut]
        public JsonResult Put(Movie obj)
        {
            var movie = _context.Movie.Find(obj.Id);

            if (movie == null)
            {
                return new JsonResult("Record Not Found =" + obj.Id.ToString());
            }
            else
            {
                movie.Title = obj.Title;
                movie.ReleaseDate = obj.ReleaseDate;
                movie.Genre = obj.Genre;
                movie.Price = obj.Price; 

                _context.Update(movie);
                _context.SaveChanges();

                return new JsonResult("Edited Successfully");
            }

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int Id)
        {
            var movie = _context.Movie.Find(Id);

            if (movie == null)
            {
                return new JsonResult("Record Not Found =" + Id.ToString());
            }
            else
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return new JsonResult("Deleted Successfully");
            }
        }
    }
}
