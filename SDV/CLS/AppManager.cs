using SDV.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV.CLS
{   
    internal class AppManager: ApplicationContext //para que no de error intentado poner una clase
    {
        private void SplashScreen()
        {
            try {
                   Splash f = new Splash();
                    f.ShowDialog();
            
            }catch(Exception e)
            {

            }
        }

        private Boolean LoginScreen()
        {
            Boolean Resultado = false;
           

            try { 
                Login f = new Login();
                f.ShowDialog();
                Resultado = f.Autorizado;
            }
            catch(Exception e)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public AppManager() { 
            //llamando los metodos para mostrarlos
            SplashScreen();
            if(LoginScreen())
            {
                Principal f= new Principal();
                f.ShowDialog();
            }
        }
    }
}
