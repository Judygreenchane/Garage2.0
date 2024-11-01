using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using Garage2._0.Models.Entities;
using Garage2._0.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Humanizer.Localisation;
using Microsoft.Data.SqlClient;
using Garage2._0.Helper;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }

        //GET: ParkedVehicles
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.TypeSortParm = string.IsNullOrEmpty(sortOrder) ? "type" : "";
            ViewBag.RegSortParm = sortOrder == "reg" ? "reg_desc" : "reg";
            ViewBag.ColorSortParm = sortOrder == "color" ? "color_desc" : "color";
            ViewBag.BrandSortParm = sortOrder == "brand" ? "brand_desc" : "brand";
            ViewBag.ModelSortParm = sortOrder == "model" ? "model_desc" : "model";
            ViewBag.WheelSortParm = sortOrder == "wheel_desc" ? "wheel" : "wheel_desc";
            var order = from s in _context.ParkedVehicle
                           select s;
            switch (sortOrder)
            {
                case "type":
                    order = order.OrderByDescending(s => s.VehicleType);
                    break;
                case "reg":
                    order = order.OrderBy(s => s.RegistrationNumber);
                    break;
                case "reg_desc":
                    order = order.OrderByDescending(s => s.RegistrationNumber);
                    break;
                case "color":
                    order = order.OrderBy(s => s.Color);
                    break;
                case "color_desc":
                    order = order.OrderByDescending(s => s.Color);
                    break;
                case "brand":
                    order = order.OrderBy(s => s.Brand);
                    break;
                case "brand_desc":
                    order = order.OrderByDescending(s => s.Brand);
                    break;
                case "model":
                    order = order.OrderBy(s => s.VehicleModel);
                    break;
                case "model_desc":
                    order = order.OrderByDescending(s => s.VehicleModel);
                    break;
                case "wheel":
                    order = order.OrderBy(s => s.Wheel);
                    break;
                case "wheel_desc":
                    order = order.OrderByDescending(s => s.Wheel);
                    break;
                default:
                    order = order.OrderBy(s => s.VehicleType);
                    break;
            }
            return View(await order.ToListAsync());

            //return View(await _context.ParkedVehicle.ToListAsync());
        }

        public async Task<IActionResult> Filter(int? type, string regNr, string color, string brand, string model, int? wheels)
        {
            var filtered = type is null ?
                _context.ParkedVehicle :
                _context.ParkedVehicle.Where(m => (int)m.VehicleType == type);

            filtered = string.IsNullOrWhiteSpace(regNr) ?
                filtered :
                filtered.Where(m => m.RegistrationNumber.Contains(regNr));

            filtered = string.IsNullOrWhiteSpace(color) ?
                filtered :
                filtered.Where(m => m.Color.Contains(color));

            filtered = string.IsNullOrWhiteSpace(brand) ?
                filtered :
                filtered.Where(m => m.Brand.Contains(brand));

            filtered = string.IsNullOrWhiteSpace(model) ?
                filtered :
                filtered.Where(m => m.VehicleModel.Contains(model));

            filtered = wheels is null ?
                filtered :
                filtered.Where(m => (int)m.Wheel == wheels);


           return View(nameof(Index), await filtered.ToListAsync());
        }



        public async Task<IActionResult> Filter2(int? type, string regNr)
        {
            var filtered = type is null ?
                _context.ParkedViewModel :
                _context.ParkedViewModel.Where(m => (int)m.Type == type);

            filtered = string.IsNullOrWhiteSpace(regNr) ?
                filtered :
                filtered.Where(m => m.RegistrationNumber.Contains(regNr));


            return View(nameof(ParkedViewModel), await filtered.ToListAsync());
        }

        public async Task<IActionResult> ParkedViewModel()
        {
            var model = _context.ParkedVehicle.Select(p => new ParkedViewModel
            {
                Id = p.Id,
                Type = p.VehicleType,
                RegistrationNumber = p.RegistrationNumber,
                ArrivalTime = p.ArrivalTime,
                ParkedTime = DateTime.Now - p.ArrivalTime

            });

            return View( await model.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleType,RegistrationNumber,Color,Brand,VehicleModel,Wheel")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;
                dateTime = new DateTime(
                    dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond),
                    dateTime.Kind
                );
                parkedVehicle.ArrivalTime = dateTime;
                parkedVehicle.RegistrationNumber = parkedVehicle.RegistrationNumber.ToUpper();
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleType,RegistrationNumber,Color,Brand,VehicleModel,Wheel,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ParkedVehicles/Receipt/5
        public async Task<IActionResult> ReceiptView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);

            if (parkedVehicle == null)
            {
                return NotFound();
            }
            
            var model = new ReceiptViewModel{ 
                Id=parkedVehicle.Id,
                RegistrationNumber=parkedVehicle.RegistrationNumber,
                ArrivalTime=parkedVehicle.ArrivalTime,
                DepartureTime=DateTime.Now,
                ParkedTime=(DateTime.Now-parkedVehicle.ArrivalTime),
                ParkedFee= (decimal)((DateTime.Now - parkedVehicle.ArrivalTime).TotalMinutes * 0.5)

            };

            return View(model);
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}
