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
            evaluacion.nombre = EstudianteTextBox.Text;
            return evaluacion;
        }

        private void LLenarCampo(Evaluacion evaluacion)
        {
            IdTextBox.Text = evaluacion.EvaluacionID.ToString();
            EstudianteTextBox.Text = evaluacion.nombre;
            fechaTextBox.Text = evaluacion.Fecha.ToString();
            ViewState["Evaluacion"] = evaluacion;


        }
        public void Limpiar()
        {
            IdTextBox.Text = "0";
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = 0.ToString();
            LogradoTextBox.Text = 0.ToString();
            TotalTextBox.Text = 0.ToString();
            ViewState["Evaluacion"] = new Evaluacion();
            GridView.DataSource = null;
            this.BindGrid();
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluacion> rep = new RepositorioBase<Evaluacion>();
            Evaluacion a = rep.Buscar(Convert.ToInt32(IdTextBox.Text));
            if (a != null)
                LLenarCampo(a);
            else
            {
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
                Limpiar();
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


            if (IdTextBox.Text == 0.ToString())
            {
                Utils.ShowToastr(this.Page, "Id no exite", "success");
                return;
            }
            if (repositorio.Eliminar(Convert.ToInt32(IdTextBox.Text)))
            {
                Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                Limpiar();
            }
           
        }
        protected void BindGrid()
        {
            GridView.DataSource = ((Evaluacion)ViewState["Evaluacion"]).detalles;
            GridView.DataBind();
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = (Evaluacion)ViewState["Evaluacion"];
            decimal p = Convert.ToDecimal(ValorTextBox.Text) - Convert.ToDecimal(LogradoTextBox.Text);
            evaluacion.AgragarDetalle(0, Utils.ToInt(IdTextBox.Text),EstudianteTextBox.Text, Convert.ToDecimal(ValorTextBox.Text),Convert.ToDecimal(LogradoTextBox.Text), DateTime.Now );
            ViewState["Evaluacion"] = evaluacion;
            this.BindGrid();
            foreach (var item in evaluacion.detalles)
            {
                TotalTextBox.Text = item.Perdido.ToString();
            }

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

            }
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



