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
    public class EditarMateriaModel : PageModel
    {
        private readonly IMateriaRepository _materiaRepository;

        public EditarMateriaModel(IMateriaRepository materiaRepository)
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

            var materiaToUpdate = _materiaRepository.GetById(id);

            if (materiaToUpdate == null)
                return NotFound();

            materiaToUpdate.Codigo = Materia.Codigo;
            materiaToUpdate.Descripcion = Materia.Descripcion;
            materiaToUpdate.Habilitada = Materia.Habilitada;

            _materiaRepository.Update(materiaToUpdate);

            return RedirectToPage("./Materias");
        }
    }
}
