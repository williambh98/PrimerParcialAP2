using BLL;
using Entidades;
using PrimerParcial.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.UI.Registros
{
    public partial class RegistrosCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if(id > 0)
                    {
                        RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
                        Categoria user = repositorio.Buscar(id);
                        if (user == null)
                            Utils.ShowToastr(this, "Id No Existe", "Error", "error");
                        else
                            LlenaCampo(user);
                       repositorio.Dispose();
                    }
                   else
                {
                    NuevoButton_Click(null, null);
                }
            }

        }
        private void Limpiar()
        {
            IdTextBox.Text = 0.ToString();
            DescripcionTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString();
            PromedioTextBox.Text = 0.ToString();
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Categoria LlenaClase()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaID = Utils.ToInt(IdTextBox.Text);
            categoria.Descripcion = DescripcionTextBox.Text;
            categoria.Fecha = DateTime.Now;
            return categoria;
        }

        private void LlenaCampo(Categoria categoria)
        {
            IdTextBox.Text = categoria.CategoriaID.ToString();
            DescripcionTextBox.Text = categoria.Descripcion;
            fechaTextBox.Text = categoria.Fecha.ToString();
            PromedioTextBox.Text = categoria.Perdida.ToString();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Categoria> db = new RepositorioBase<Categoria>();
            Categoria categoria = db.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (categoria != null); 

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categoria> db = new RepositorioBase<Categoria>();
            Categoria categoria;
            bool paso = false;

            categoria = LlenaClase();

            if (IdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(categoria);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "LLenar este campo", "Error", "error");
                    return;
                }
                paso = db.Modificar(categoria);
                Utils.ShowToastr(this.Page, "Modificado ", "Exito", "success");
                return;
            }

            if (paso)
                Utils.ShowToastr(this.Page, "Guardado ", "Exito", "success");
            else
                Utils.ShowToastr(this.Page, "Error No Guardado", "Error", "error");
            Limpiar();

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            int id = Utils.ToInt(IdTextBox.Text);
            var categoria = repositorio.Buscar(id);

            if (categoria != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No Eliminado", "error");
            }
            else
                EliminarRequiredFieldValidator.IsValid = false;
            repositorio.Dispose();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categoria> rep = new RepositorioBase<Categoria>();
            Categoria a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
            if (a != null)
                LlenaCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
            }
            rep.Dispose();
        }

    }
}