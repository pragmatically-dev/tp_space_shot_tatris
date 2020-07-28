using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_expo_mep.Juego
{
    public partial class frm_Juego : Form
    {
        private Configuracion config = Json.Deserializar(Application.StartupPath + "/Parametros.json");
        private Dificultad d;
        private Colores c;
        private Color[] Colores = { Color.White, Color.Blue, Color.Red };

        private void ConfigurarJuego() {
            try
            {
                d = config.Dificultad;
                c = config.Colores;

                #region "Op ternario para el color"
                this.BackColor = (c.ByN) ? Colores[0] :
                this.BackColor = (c.AyN) ? Colores[1] :
                this.BackColor = (c.RyN) ? Colores[2] :
                Colores[0];
                #endregion
            }
            catch(Exception){
                MessageBox.Show("Asegurese de seleccionar color y dificultad");
            }
        }

        public frm_Juego()
        {
            InitializeComponent();
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            ConfigurarJuego();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {

            Menu_Principal m = new Menu_Principal();
            m.Show();
            this.Close();
        }
    }
}
