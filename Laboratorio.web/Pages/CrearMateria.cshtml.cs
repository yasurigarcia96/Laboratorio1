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
    public class CrearMateriaModel : PageModel
    {
        private readonly IMateriaRepository _materiaRepository;

        public CrearMateriaModel(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [BindProperty]
        public Materia Materia { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _materiaRepository.Insert(Materia);

            return RedirectToPage("./Materias");
        }
    }
}
