using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tetris_expo_mep.Juego.Jugador;
using Tetris_expo_mep.Juego.Figuras;
using System.Media;
namespace Tetris_expo_mep.Juego
{
    public partial class Juego : Form
    {
        private int[,] MatrizJuego;
        private int Alt, Anch;
        private static SoundPlayer Smov =new SoundPlayer(Application.StartupPath+ "/Recursos/Movement/Footsteps/sfx_movement_footsteps5.wav");
        public static SoundPlayer SbreakBloq = new SoundPlayer(Application.StartupPath +"/Recursos/Death Screams/Robot/sfx_deathscream_robot2.wav");
        private static SoundPlayer shoot = new SoundPlayer(Application.StartupPath + "/Recursos/Weapons/Lasers/sfx_wpn_laser9.wav");
        public static int punt;
        public static int cantBloques;
        private bool ganaste;
        protected int Seg = 40;
        protected DB d = new DB();
        protected Thread t;
        #region"ConfigPlayer"
        private string Direccion;
        private int[] Py = { 16, 17, 17, 17 };
        private int[] Px = { 4, 3, 4, 5 };
        private int tagP = 1;
        private Jugador.Jugador Jugador;

        #endregion
        #region"Bala"
        Bala.Bala bala;
        #endregion
        private void IniciarlizarM(int h, int w)
        {
            MatrizJuego = new int[h, w];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {

                    MatrizJuego[y, x] = 0;
                }
            }
        }
        public void GenerarMarco(int h, int w)
        {

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    MatrizJuego[0, j] = 9;

                    MatrizJuego[i, 0] = 9;

                    MatrizJuego[i, 16] = 9;

                    MatrizJuego[19, j] = 9;
                }
            }


        }
        private void Graficar(int h, int w, PaintEventArgs e)
        {

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {

                    if (MatrizJuego[y, x] == 9)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Size = new Size(35, 35);
                        rectangle.Location = new Point(x * 36, y * 36);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, rectangle);
                    }

                    if (MatrizJuego[y, x] == Jugador.Tag)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Size = new Size(35, 35);
                        rectangle.Location = new Point(x * 36, y * 36);
                        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectangle);
                    }

                    if (MatrizJuego[y, x] == 2)
                    {

                        Rectangle rectangle = new Rectangle();
                        rectangle.Size = new Size(35, 35);
                        rectangle.Location = new Point(x * 36, y * 36);
                        e.Graphics.FillRectangle(Brushes.Lime, rectangle);
                    }

                    if (MatrizJuego[y, x] == 8)
                    {

                        Rectangle rectangle = new Rectangle();
                        rectangle.Size = new Size(10, 10);
                        rectangle.Location = new Point(x * 36 + 13, y * 36);
                        e.Graphics.FillRectangle(Brushes.White, rectangle);
                    }

                }
            }
        }
        private void gm(int[,]M) {
            for (int i = 1; i < 13; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    cantBloques++;
                    M[i, j] = 2;
                    
                }
            }
        }
        private void Game_Load(object sender, EventArgs e)
        {
            #region"Conf Matriz"
            Alt = 40;
            Anch = 40;
            IniciarlizarM(Alt, Anch);
            GenerarMarco(Alt, Anch);
            #endregion
            #region"Conf Player"
            Jugador = new Jugador.Jugador(Py, Px, tagP);
            Jugador.CrearFiguraEnMatriz(MatrizJuego);

            #endregion
            #region "Conf PiezaL"
            //figL = new FigL(PY, PX, Ptag);

            //Thread th = new Thread(() => { figL.Mover(MatrizJuego); });
            //th.Start();
            #endregion
            gm(MatrizJuego);
        }
        public Juego()
        {
            InitializeComponent();

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Comprobar(MatrizJuego);
            if (cantBloques==0) {
                ganaste = true;
            }
            this.Invalidate();
            label1.Text = "Puntaje: " + punt.ToString();
        }
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graficar(Alt, Anch, e);
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            //          
            shoot.Dispose();
            SbreakBloq.Dispose();
            Smov.Dispose();
            Menu_Principal c = new Menu_Principal();
            c.Show();
        }
        private void Juego_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void Crono_Tick(object sender, EventArgs e)
        {
            if (ganaste!=false) {
                Perdiste();
                Crono.Enabled = false;
            }
            if (Seg==0) { Crono.Enabled = false; Perdiste(); Crono.Enabled = false; }
            Seg-=1;
            label2.Text = "Tiempo: "+Seg.ToString();            
        }
        private void Perdiste()
        {
            Crono.Enabled = false;
            var M = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su nombre: ", "Game");
            JugadorDB jugador = new JugadorDB() {
                Fecha = DateTime.Now.ToString(),
                Nombre = M,
                Puntaje = punt
            };
            d.InsertarPuntaje(jugador);
            timer1.Enabled = false;

            MessageBox.Show("Presione enter para continuar.","Game");
            this.Close();

        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
            {
                Direccion = "Right";
                Jugador.MovJugador(MatrizJuego, Direccion);
                Smov.Play();
            }

            if (e.KeyCode == Keys.Left)
            {
                Direccion = "Left";
                Jugador.MovJugador(MatrizJuego, Direccion);
                Smov.Play();
            }

            if (e.KeyCode == Keys.Up)
            {
                Direccion = "Up";
                Jugador.MovJugador(MatrizJuego, Direccion);
                Smov.Play();
            }

            if (e.KeyCode == Keys.Down)
            {
                Direccion = "Down";
                Jugador.MovJugador(MatrizJuego, Direccion);
                Smov.Play();
            }
            
            if (e.KeyCode == Keys.Space)
            {
                bala = new Bala.Bala(8);

                t = new Thread(() => { bala.MoverBala(MatrizJuego, Jugador.Y1, Jugador.X1); });
                t.Start();
                shoot.Play();
                Crono.Enabled = true;

            }

        }
    }
}
