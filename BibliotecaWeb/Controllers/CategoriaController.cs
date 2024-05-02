using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpGet]

        public JsonResult Obtener() {
            List<Categoria> lista = CD_Categoria.Instancia.ObtenerCategoria();
            return Json(new { data = lista }); 
        }

        public JsonResult Guardar(Categoria objeto) 
        {
            bool respuesta = false;
            if (objeto.CategoriaID == 0)
                respuesta = CD_Categoria.Instancia.RegistrarCategoria(objeto);
            else
                respuesta = CD_Categoria.Instancia.ModificarCategoria(objeto);
            return Json(new
            {
                resultado = respuesta
            });

        }

       
          [HttpGet]

          public JsonResult Eliminar(int id = 0)
          {
                bool respuesta = CD_Categoria.Instancia.EliminarCategoria(id);
                return Json(new { resultado = respuesta });
          }


    }
}
