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
    public partial class RegistrosEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                    Evaluacion user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LLenarCampo(user);
                }
               
                ViewState["Evaluacion"] = new Evaluacion();
            }
        }
        private Evaluacion LlenarClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = (Evaluacion)ViewState["Evaluacion"];
            evaluacion.EvaluacionID = Convert.ToInt32(IdTextBox.Text);
            evaluacion.Nombre = EstudianteTextBox.Text;
            evaluacion.Total = Utils.ToInt(TotalTextBox.Text);
       
            return evaluacion;
        }

        private void LLenarCampo(Evaluacion evaluacion)
        {
            IdTextBox.Text = evaluacion.EvaluacionID.ToString();
            EstudianteTextBox.Text = evaluacion.Nombre;
            fechaTextBox.Text = evaluacion.Fecha.ToString();
            TotalTextBox.Text = evaluacion.Total.ToString();
            ViewState["Evaluacion"] = evaluacion;
            this.BindGrid();
        }
        public void Limpiar()
        {
            IdTextBox.Text = "0";
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = 0.ToString();
            LogradoTextBox.Text = 0.ToString();
            TotalTextBox.Text = 0.ToString();
            fechaTextBox.Text = DateTime.Now.ToString();
            ViewState["Evaluacion"] = new Evaluacion();
            GridView.DataSource = null;
            this.BindGrid();
        }
        private bool ValidarAgregar()
        {
            bool estato = false;

            if (String.IsNullOrWhiteSpace(EstudianteTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe llenar el campo estudiante", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(CategoriaTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe llenar el campo categoria", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(ValorTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe llenar el campo valor", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(LogradoTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe llenar el campo logrado", "Error", "error");
                estato = true;
            }
            return estato;
        }

        private bool Validar()
        {
            bool estato = false;

            if (GridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar detalle.", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estato = true;
            }
            return estato;
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluacion> rep = new RepositorioBase<Evaluacion>();
            Evaluacion a = rep.Buscar(Convert.ToInt32(IdTextBox.Text));
            if (a != null)
                LLenarCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
               
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            GridViewRow grid = GridView.SelectedRow;
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            int id = Utils.ToInt(IdTextBox.Text);
            var evaluacion = repositorio.Buscar(id);

            if (evaluacion != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No Eliminado", "error");
            }
               

        }
        protected void BindGrid()
        {
            GridView.DataSource = ((Evaluacion)ViewState["Evaluacion"]).Detalles;
            GridView.DataBind();
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion = new Evaluacion();
            decimal total = 0;
            evaluacion.Detalles = new List<DetalleEvaluacion>();
            evaluacion = (Evaluacion)ViewState["Evaluacion"];
            decimal p = Convert.ToDecimal(ValorTextBox.Text) - Convert.ToDecimal(LogradoTextBox.Text);
            evaluacion.AgragarDetalle(0, Utils.ToInt(IdTextBox.Text),EstudianteTextBox.Text, Convert.ToDecimal(ValorTextBox.Text),
            Convert.ToDecimal(LogradoTextBox.Text),p,Convert.ToDateTime(DateTime.Now) );
            ViewState["Evaluacion"] = evaluacion;
            this.BindGrid();
            foreach (var item in evaluacion.Detalles)
            {
                total += item.Perdido;
            }
            TotalTextBox.Text = total.ToString();
        }
        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (GridView.Rows.Count > 0 && GridView.SelectedIndex >= 0)
            {
                Evaluacion evaluacion = new Evaluacion();
                evaluacion = (Evaluacion)ViewState["Evaluacion"];
                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                evaluacion.RemoverDetalle(row.RowIndex);
                ViewState["Evaluacion"] = evaluacion;
                this.BindGrid();

            }

        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion();
            Evaluacion evaluacion = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if(Validar())
            {
                return;
            }
            if (evaluacion == null)
            {
                if (repositorio.Guardar(LlenarClase()))
                {

                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No existe", "Error", "error");
                    Limpiar();
                }

            }
            else
            {
                if (repositorio.Modificar(LlenarClase()))
                {
                    Utils.ShowToastr(this.Page, "Modificado con exito!!", "Guardado", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this.Page, "No se puede modificar", "Error", "error");
                    Limpiar();
                }
            }
            
        }
    }



}



