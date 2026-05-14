using lib_servicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentacion_series.Implementaciones;
using presentacion_series.Interfaces;

namespace presentacion_series.Pages.Ventanas
{
    public class CategoriasModel : PageModel
    {
        private ICategoriasNegocio? iCategoriasNegocio;

        [BindProperty] public List<Categorias>? Lista { get; set; }
        [BindProperty] public Categorias? Venta { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public CategoriasModel()
        {
            iCategoriasNegocio = new CategoriasNegocio();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (iCategoriasNegocio == null)
                    return;
                Lista = iCategoriasNegocio.Consultar();
                Venta = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Venta = new Categorias();
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Venta = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Venta == null)
                    return;
                if (Venta.Id == 0)
                    Venta = iCategoriasNegocio!.Guardar(Venta!);
                else
                    Venta = iCategoriasNegocio!.Modificar(Venta!);
                if (Venta.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Venta = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Venta == null)
                    return;
                iCategoriasNegocio!.Borrar(Venta!.Id);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}