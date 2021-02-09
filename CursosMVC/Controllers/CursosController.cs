using CursosMVC.Data;
using CursosMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CursosMVC.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursosController
        public async Task<ActionResult> Index(string search)
        {
            var cursos = await _context.Cursos.ToListAsync();

            if (!String.IsNullOrEmpty(search))
            {
                cursos = await _context.Cursos.Where(c => 
                    c.Nome.Contains(search) || c.Plataforma.Contains(search)).ToListAsync();
            }

            return View(cursos);
        }

        // GET: CursosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CursosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id, Nome, Plataforma, TemCertificado, CertificadoGratuito, Link")] Curso curso, IList<IFormFile> foto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IFormFile imagem = foto.FirstOrDefault();
                    if (imagem != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        imagem.OpenReadStream().CopyTo(ms);
                        curso.Dados = ms.ToArray();
                        curso.ContentType = imagem.ContentType;
                    }

                    _context.Add(curso);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public FileStreamResult CarregarFoto(int id)
        {
            var dados = (from c in _context.Cursos
                             where c.Id == id
                             select c.Dados).FirstOrDefault();

            var contentType = (from c in _context.Cursos
                                   where c.Id == id
                                   select c.ContentType).FirstOrDefault();
            if (dados != null)
            {
                MemoryStream ms = new MemoryStream(dados);
                return new FileStreamResult(ms, contentType);
            }
            else
            {
                return null;
            }
        }
    }
}
