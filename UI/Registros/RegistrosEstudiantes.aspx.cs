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
    public partial class RegistrosEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
                    Estudiantes user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
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
            NombreTextBox.Text = string.Empty;
            PerdidoTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString();
            
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Estudiantes LlenaClase()
        {
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.EstudianteID = Utils.ToInt(IdTextBox.Text);
            estudiantes.Nombre = NombreTextBox.Text;
            estudiantes.PuntoPerdidos = Convert.ToDecimal(PerdidoTextBox.Text);
            estudiantes.Fecha = DateTime.Now;
            return estudiantes;
        }

        private void LlenaCampo(Estudiantes estudiantes)
        {
            IdTextBox.Text = estudiantes.EstudianteID.ToString();
            NombreTextBox.Text = estudiantes.Nombre;
            fechaTextBox.Text = estudiantes.Fecha.ToString();
            PerdidoTextBox.Text = estudiantes.PuntoPerdidos.ToString();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            Estudiantes estudiante = db.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (estudiante != null);

        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            Estudiantes estudiante;
            bool paso = false;

            estudiante = LlenaClase();

            if (IdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(estudiante);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "LLenar este campo", "Error", "error");
                    return;
                }
                paso = db.Modificar(estudiante);
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
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            int id = Utils.ToInt(IdTextBox.Text);
            var estudiante = repositorio.Buscar(id);

            if (estudiante != null)
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
            RepositorioBase<Estudiantes> rep = new RepositorioBase<Estudiantes>();
            Estudiantes a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
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
