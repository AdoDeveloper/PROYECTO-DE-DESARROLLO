using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                REP.Ventas ventas = new REP.Ventas();
                ventas.SetDataSource(DataLayer.Consultas.VENTAS_SEGUN_PERIODO(dtpInicio.Text, dtpCierre.Text));
                crvVisor.ReportSource = ventas;

            }
            catch (Exception)
            {

            }
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje de carga
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show(this);

            try
            {
                DataTable dataTable = await Task.Run(() => DataLayer.Consultas.VENTAS_SEGUN_PERIODO(dtpInicio.Text, dtpCierre.Text));
                ExportarAExcel(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
            finally
            {
                // Cerrar mensaje de carga
                loadingForm.Close();
            }
        }

        private void ExportarAExcel(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = (Microsoft.Office.Interop.Excel._Worksheet)excel.ActiveSheet;

                // Renombrar la hoja activa a "Ventas"
                worksheet.Name = "Ventas";

                int indiceColumna = 0;

                // Escribir los nombres de las columnas
                foreach (DataColumn col in dataTable.Columns)
                {
                    indiceColumna++;
                    worksheet.Cells[1, indiceColumna] = col.ColumnName;
                }

                int indiceFila = 0;

                // Escribir los datos de las filas
                foreach (DataRow row in dataTable.Rows)
                {
                    indiceFila++;
                    indiceColumna = 0;

                    foreach (DataColumn col in dataTable.Columns)
                    {
                        indiceColumna++;
                        worksheet.Cells[indiceFila + 1, indiceColumna] = row[col.ColumnName];
                    }
                }

                // Crear tabla de datos
                Microsoft.Office.Interop.Excel.Range dataRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[indiceFila + 1, indiceColumna]];
                dataRange.Worksheet.ListObjects.Add(Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange, dataRange, System.Type.Missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes).Name = "VentasTable";
                dataRange.Select();
                dataRange.Worksheet.ListObjects["VentasTable"].TableStyle = "TableStyleMedium9";

                // Crear tabla dinámica
                Microsoft.Office.Interop.Excel._Worksheet pivotSheet = (Microsoft.Office.Interop.Excel._Worksheet)excel.Sheets.Add();
                pivotSheet.Name = "TablaDinámica";
                Microsoft.Office.Interop.Excel.PivotTable pivotTable = pivotSheet.PivotTableWizard(
                    SourceType: Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase,
                    SourceData: dataRange,
                    TableDestination: pivotSheet.Cells[1, 1],
                    TableName: "VentasPivotTable"
                );

                // Configurar campos de la tabla dinámica
                Microsoft.Office.Interop.Excel.PivotField pivotField;

                // Agregar campos al PivotTable
                pivotField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("id_factura");
                pivotField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                pivotField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("fecha");
                pivotField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlColumnField;
                pivotField = (Microsoft.Office.Interop.Excel.PivotField)pivotTable.PivotFields("Total_Venta");
                pivotField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlDataField;
                pivotField.Function = Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum;
                pivotField.NumberFormat = "#,##0.00";

                // Aplicar diseño a la tabla dinámica
                pivotTable.DisplayErrorString = true;
                pivotTable.DisplayNullString = true;
                pivotTable.NullString = "0";
                pivotTable.TableStyle2 = "PivotStyleMedium9"; // Aplicar un estilo de tabla dinámica

                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {

                if (crvVisor.ReportSource != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Guardar Reporte como PDF";
                    saveFileDialog.FileName = "ReporteVentas.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ReportDocument reportDocument = (ReportDocument)crvVisor.ReportSource;
                        ExportOptions exportOptions = reportDocument.ExportOptions;
                        PdfRtfWordFormatOptions pdfFormatOptions = new PdfRtfWordFormatOptions();
                        DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();

                        diskOptions.DiskFileName = saveFileDialog.FileName;
                        exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        exportOptions.ExportFormatOptions = pdfFormatOptions;
                        exportOptions.ExportDestinationOptions = diskOptions;

                        reportDocument.Export();
                        MessageBox.Show("Reporte exportado a PDF exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No hay un reporte cargado en el visor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
