using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.UI.Consultas
{
    public partial class ConsultasEvaluacion : System.Web.UI.Page
    {
       static List<Evaluacion> lista = new List<Evaluacion>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Evaluacion, bool>> filtro = x => true;
            RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();

            // List<TipoAnalisis> TiposAnalisis = new RepositorioBase<TipoAnalisis>().GetList(x => true);
            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.EvaluacionID == id;
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
        private void BindGrid(List<Evaluacion> lista)
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
        //public void LlenaReport()
        //{
        //    MyPagosReportViewer.ProcessingMode = ProcessingMode.Local;
        //    MyPagosReportViewer.Reset();
        //    MyPagosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoPagos.rdlc");
        //    MyPagosReportViewer.LocalReport.DataSources.Clear();
        //    MyPagosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("PagoDS", BLL.Metodos.FPagos()));
        //    MyPagosReportViewer.LocalReport.Refresh();
        //}

    }
}