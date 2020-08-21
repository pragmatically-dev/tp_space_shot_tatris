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
using Newtonsoft.Json;
using Tetris_expo_mep.Juego;
using System.Media;
using Tetris_expo_mep;
namespace Tetris_expo_mep
{
    public partial class Menu_Principal : Form
    {
        SoundPlayer sound = new SoundPlayer(Application.StartupPath+ "/MV  Jack Stauber - Buttercup.wav");

        //private Dificultad D;//dificultad
        //private Colores C;//Colores 
        //private string Path = Application.StartupPath+"/Parametros.json";
        //private Configuracion configuracion;
        public Menu_Principal()
        {
            InitializeComponent();
        }
        public void GuardarConfiguracion(Dificultad d, Colores c) {

            //configuracion = new Configuracion() {
            //    Dificultad = d,
            //    Colores = c
            //};
            //Json.Guardar(Path,configuracion);
        } 



        //#region "Dificultad"
        //private void FacilToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    D = new Dificultad() {
        //        Facil = true,
        //        Normal = false,
        //        Dificil = false
        //    };

            
        //}

        //private void DificilToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    D = new Dificultad()
        //    {
        //        Facil = false,
        //        Normal = true,
        //        Dificil = false
        //    };
            
        //}

        //private void ExtremoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    D = new Dificultad()
        //    {
        //        Facil = false,
        //        Normal = false,
        //        Dificil = true
        //    };
            
        //}
        //#endregion
        //#region "Colores"
        //private void BlancoYNegroToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    C = new Colores();

        //    C.ByN = true;
        //    C.AyN = false;
        //    C.RyN = false;
            
        //}

        //private void AzulYNegroToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    C = new Colores();

        //    C.ByN = false;
        //    C.AyN = true;
        //    C.RyN = false;
            
        //}

        //private void RojoYNegroToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    C = new Colores();

        //    C.ByN = false;
        //    C.AyN = false;
        //    C.RyN = true;
            
        //}
        //#endregion

        private void NuevoJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GuardarConfiguracion(D,C);
            Juego.Juego juego = new Juego.Juego(); 
                        this.Hide();
            juego.Show();

        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Juego.Juego juego = new Juego.Juego();
            Juego.Juego.punt = 0;
            this.Hide();
            juego.Show();


        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
            dB.GenerarDB();
            sound.Play();
        }

        private void on_Click(object sender, EventArgs e)
        {
            sound.PlayLooping();
            on.Visible = false;
            off.Visible = true;
        }

        private void off_Click(object sender, EventArgs e)
        {
            sound.Stop();
            on.Visible = true;
            off.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPuntuaciones frm = new frmPuntuaciones();
            frm.Show();
        }

        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nieva Santiago ","Creditos");
        }
    }
}
