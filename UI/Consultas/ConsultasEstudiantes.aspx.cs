using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.UI.Consultas
{
    public partial class ConsultasEstudiantes : System.Web.UI.Page
    {
        static List<Estudiantes> lista = new List<Estudiantes>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Estudiantes, bool>> filtro = x => true;
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();

            // List<TipoAnalisis> TiposAnalisis = new RepositorioBase<TipoAnalisis>().GetList(x => true);
            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.EstudianteID == id;
                    break;
                case 2:// Nombre
                    filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                    break;
            }
            DateTime desdeTextBox = Utilitarios.Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utilitarios.Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.Fecha >= desdeTextBox && c.Fecha <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
            this.BindGrid(lista);
        }
        private void BindGrid(List<Estudiantes> lista)
        {
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }

        protected void FechaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fechaCheckBox.Checked)
            {
                fechaCheckBox.Visible = true;
                fechaCheckBox.Visible = true;
            }
            else
            {
                fechaCheckBox.Visible = false;
                fechaCheckBox.Visible = false;
            }
        }
        public void LlenaReport()
        {
            //MyEstudiantesReportViewer.ProcessingMode = ProcessingMode.Local;
            //MyEstudiantesReportViewer.Reset();
            //MyEstudiantesReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportesEstudiante.rdlc");
            //MyEstudiantesReportViewer.LocalReport.DataSources.Clear();
            ////MyEstudiantesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClienteDS", BLL.Metodos.FClientes()));
            //MyEstudiantesReportViewer.LocalReport.Refresh();
        }
    }
}