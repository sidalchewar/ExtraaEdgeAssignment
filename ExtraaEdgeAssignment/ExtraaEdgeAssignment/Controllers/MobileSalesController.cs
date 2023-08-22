using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraaEdgeAssignment.DBContext;
using ExtraaEdgeAssignment.Models;
using Microsoft.VisualBasic;

namespace ExtraaEdgeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSalesController : ControllerBase
    {
        private readonly MobileDbContext _context;

        public MobileSalesController(MobileDbContext context)
        {
            _context = context;
        }

        // GET: api/MobileSales
        [HttpGet]
        public List<MobileSales> GetMobileSales()
        {
            if(_context.MobileSales.ToList()!=null)
            {
                return _context.MobileSales.ToList();
            }
            return null;
        }

        [HttpGet("{month}")]
        public List<MobileSales> GetMobileSalesByDate(int month)
        {
            List<MobileSales> sales=_context.MobileSales.ToList();

            return sales.Where(s=>s.Date.Month==month).ToList();
        }

        [HttpGet("{brandid}/{month}")]
        public List<MobileSales> GetMobileSalesByDate(int month,int brandid)
        {
            List<MobileSales> sales = _context.MobileSales.ToList();

            List<MobileSales> mobileSales = new List<MobileSales>();
            for(int i=0; i<sales.Count; i++)
            {
                Mobile mb = _context.Mobiles.Find(sales[i].MobileId);
                if (mb.MobileBrandId==brandid)
                {
                    mobileSales.Add(sales[i]);
                }
            }

                return mobileSales;   
        }

        [HttpPost]
        public MobileSales AddMobileSale(MobileSales mobileSales)
        {
            Mobile mb = _context.Mobiles.Find(mobileSales.MobileId);
            if(mb.NumberOfMobiles>=mobileSales.NumberOfMobileSales)
            {
                float price = _context.Mobiles.Find(mobileSales.MobileId).Price;
                mobileSales.TotalPrice = mobileSales.NumberOfMobileSales * price;
                mb.NumberOfMobiles = mb.NumberOfMobiles - mobileSales.NumberOfMobileSales;
                _context.Mobiles.Update(mb);
                _context.MobileSales.Add(mobileSales);
                _context.SaveChanges();
            }
            
            return mobileSales;
        }

        /*[HttpGet]
        public float GetProfitLoss()
        {

        }*/

    }
}
