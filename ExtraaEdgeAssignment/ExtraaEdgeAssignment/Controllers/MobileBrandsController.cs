using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraaEdgeAssignment.DBContext;
using ExtraaEdgeAssignment.Models;

namespace ExtraaEdgeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBrandsController : ControllerBase
    {
        private readonly MobileDbContext _context;

        public MobileBrandsController(MobileDbContext context)
        {
            _context = context;
        }

        // GET: api/MobileBrands
        [HttpGet]
        public List<MobileBrand> GetMobileBrands()
        {
            if (_context.MobileBrands == null)
            {
                return null;
            }
            return _context.MobileBrands.ToList();
        }

        // GET: api/MobileBrands/5
        [HttpGet("{id}")]
        public MobileBrand GetMobileBrandsById(int id)
        {
            if (_context.MobileBrands.Find(id) == null)
            {
                return null;
            }
            return _context.MobileBrands.Find(id);
        }

        [HttpPut("{id}")]
        public MobileBrand  PutMobileBrand(int id, MobileBrand mobileBrand)
        {
            if(_context.MobileBrands.Find(id)!=null)
            {
                _context.MobileBrands.Update(mobileBrand);
                _context.SaveChanges();
                return _context.MobileBrands.Find(id);
            }
            return null;
           
        }

        [HttpPost]
        public MobileBrand AddMobileBrand(MobileBrand mobileBrand)
        {
            if(mobileBrand != null)
            {
                _context.MobileBrands.Add(mobileBrand);
                _context.SaveChanges();
                return mobileBrand;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public MobileBrand DeleteMobileBrand(int id)
        {
            if(_context.MobileBrands.Find(id)!=null)
            {
                var obj = _context.MobileBrands.Find(id);
                _context.MobileBrands.Remove(obj);
                _context.SaveChanges();
                return obj;
            }
            return null;
        }
    }
}
