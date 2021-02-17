using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio.Data.Interfaces;
using Laboratorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laboratorio.web.Pages
{
    public class EliminarMateriaModel : PageModel
    {
        private readonly IMateriaRepository _materiaRepository;

        public EliminarMateriaModel(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [BindProperty]
        public Materia Materia { get; set; }
        public IActionResult OnGet(int id)
        {
            Materia = _materiaRepository.GetById(id);
            if (Materia == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var materiaToDelete = _materiaRepository.GetById(id);

            if (materiaToDelete == null)
                return NotFound();

            materiaToDelete.Codigo = Materia.Codigo;
            materiaToDelete.Descripcion = Materia.Descripcion;
            materiaToDelete.Habilitada = Materia.Habilitada;

            _materiaRepository.Delete(materiaToDelete);

            return RedirectToPage("./Materias");
        }
    }
}
