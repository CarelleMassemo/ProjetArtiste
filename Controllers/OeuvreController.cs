using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetArtiste1.Data;
using ProjetArtiste1.Data.Services;
using ProjetArtiste1.Data.Static;
using ProjetArtiste1.Models;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjetArtiste1.Controllers
{
   
    public class OeuvreController : Controller
    {

        private readonly ApplicationDbContext _context;

        public OeuvreController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _context.Oeuvres.ToListAsync();
            return View(data);
        }
       
        //Get: Oeuvres/Create
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("nom,description,prix,imageURL,dateCreation,oeuvreCategorie")] Oeuvre oeuvre)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(oeuvre);
        //    }
        //    await _context.AddAsync(oeuvre);
        //    return RedirectToAction(nameof(Index));
        //}



        //Get: oeuvres/Details/1
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nom,description,prix,imageURL,dateCreation,oeuvreCategorie")] Oeuvre oeuvre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oeuvre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(oeuvre);
        }

        public async Task<IActionResult> Details(int id)
        {
            var oeuvreDetails = _context.Oeuvres.FirstOrDefault(a => a.Id == id);

            if (oeuvreDetails == null) return View("NotFound");
            return View(oeuvreDetails);
        }
       
        //Get: Oeuvres/Edit/1
        public IActionResult Edit(int id)
        {
            var oeuvreDetails = _context.Oeuvres.FirstOrDefault(a => a.Id == id);
            if (oeuvreDetails == null) return View("NotFound");
            return View(oeuvreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Oeuvre oeuvre)
        {
            var oeuvre1 = _context.Oeuvres.FirstOrDefault(c => c.Id.Equals(oeuvre.Id));

            if (oeuvre1 == null)
            {
                return View(oeuvre);
            }

            oeuvre1.nom = oeuvre.nom;
            oeuvre1.description = oeuvre.description;
            oeuvre1.oeuvreCategorie = oeuvre.oeuvreCategorie;
            oeuvre1.imageURL = oeuvre.imageURL;
            oeuvre1.prix = oeuvre.prix;
            oeuvre1.dateCreation = oeuvre.dateCreation;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        //Get: Oeuvres/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var oeuvreDetails = _context.Oeuvres.FirstOrDefault(a => a.Id == id);
            if (oeuvreDetails == null) return View("NotFound");
            return View(oeuvreDetails);


        }

        [HttpPost]
        public async Task<IActionResult> Delete(Oeuvre oeuvre)
        {
            var oeuvreDetails1 = _context.Oeuvres.FirstOrDefault(a => a.Id.Equals(oeuvre.Id));

            if (oeuvreDetails1 == null)
            {
                return View("NotFound");
            }
            _context.Oeuvres.Remove(oeuvreDetails1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }

}





