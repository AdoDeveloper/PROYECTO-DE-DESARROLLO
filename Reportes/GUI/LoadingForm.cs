using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            Shown += LoadingForm_Shown;
        }

        private async void LoadingForm_Shown(object sender, EventArgs e)
        {
            try
            {
                // Aquí puedes realizar cualquier tarea que requiera tiempo, como cargar datos, procesar información, etc.
                for (int i = 0; i <= 100; i++)
                {
                    await Task.Delay(10); // Simula una tarea que lleva tiempo (50 ms en este caso)

                    // Actualiza la barra de progreso
                    barra.Value = i;
                }

                // Cierra el formulario de carga cuando se completa la tarea
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Close(); // Cierra el formulario en caso de error
            }
        }
    
}
}
