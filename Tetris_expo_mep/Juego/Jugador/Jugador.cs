using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tetris_expo_mep.Juego.Jugador
{
    public class Jugador
    {
        #region "Pos&Tag&Vel"
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }
        public int X4 { get; set; }

        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Y3 { get; set; }
        public int Y4 { get; set; }

        public int Tag { get; set; }

        private int Velocidad { get; set; }


        #endregion
        public Jugador(int[] PosY, int[] PosX, int Tag)
        {
            this.Y1 = PosY[0]; this.X1 = PosX[0];//HEAD 
            this.Y2 = PosY[1]; this.X2 = PosX[1];
            this.Y3 = PosY[2]; this.X3 = PosX[2];
            this.Y4 = PosY[3]; this.X4 = PosX[3];
            this.Tag = Tag;
            this.Velocidad = 1;
        }

        public void CrearFiguraEnMatriz(int[,] M)
        {

            try
            {
                M[this.Y1, this.X1] = this.Tag;
                M[this.Y2, this.X2] = this.Tag;
                M[this.Y3, this.X3] = this.Tag;
                M[this.Y4, this.X4] = this.Tag;
            }
            catch (Exception)
            { }
        }

        public void MovJugador(int[,] MatrizJuego, string Dir)
        {

            switch (Dir)
            {
                case "Left":
                    if (MatrizJuego[this.Y3, this.X3] != MatrizJuego[this.Y3, 1])
                    {
                        MatrizJuego[this.Y1, this.X1 -= this.Velocidad] = 1;
                        MatrizJuego[this.Y2, this.X2 -= this.Velocidad] = 1;
                        MatrizJuego[this.Y3, this.X3 -= this.Velocidad] = 1;
                        MatrizJuego[this.Y4, this.X4 -= this.Velocidad] = 1;
                        MatrizJuego[this.Y1, this.X1 + this.Velocidad] = 0;
                        MatrizJuego[this.Y2 + this.Velocidad, this.X2 + this.Velocidad] = 0;
                        MatrizJuego[this.Y3 + this.Velocidad, this.X3 + this.Velocidad] = 0;
                        MatrizJuego[this.Y4, this.X4 + this.Velocidad] = 0;
                    }
                    break;
                case "Right":
                    if (MatrizJuego[this.Y3, this.X3] != MatrizJuego[this.Y3,15]) {
                        MatrizJuego[this.Y1, this.X1 += this.Velocidad] = 1;
                        MatrizJuego[this.Y2, this.X2 += this.Velocidad] = 1;
                        MatrizJuego[this.Y3, this.X3 += this.Velocidad] = 1;
                        MatrizJuego[this.Y4, this.X4 += this.Velocidad] = 1;
                        MatrizJuego[this.Y1, this.X1 - 1] = 0;
                        MatrizJuego[this.Y2, this.X2 - 1] = 0;
                    }
                    break;
                case "Up":
                    if (MatrizJuego[this.Y3, this.X3] != MatrizJuego[16, this.X3])
                    {


                        MatrizJuego[this.Y1 -= this.Velocidad, this.X1] = 1;
                        MatrizJuego[this.Y2 -= this.Velocidad, this.X2] = 1;
                        MatrizJuego[this.Y3 -= this.Velocidad, this.X3] = 1;
                        MatrizJuego[this.Y4 -= this.Velocidad, this.X4] = 1;
                        MatrizJuego[this.Y2 + this.Velocidad, this.X2] = 0;
                        MatrizJuego[this.Y3 + this.Velocidad, this.X3] = 0;
                        MatrizJuego[this.Y4 + this.Velocidad, this.X4] = 0;
                    }
                    break;
                case "Down":
                    if (MatrizJuego[this.Y3, this.X3] != MatrizJuego[17, this.X3]) {
                        MatrizJuego[this.Y1 += this.Velocidad, this.X1] = 1;
                        MatrizJuego[this.Y2 += this.Velocidad, this.X2] = 1;
                        MatrizJuego[this.Y3 += this.Velocidad, this.X3] = 1;
                        MatrizJuego[this.Y4 += this.Velocidad, this.X4] = 1;
                        MatrizJuego[this.Y1 - this.Velocidad, this.X1] = 0;
                        MatrizJuego[this.Y2 - this.Velocidad, this.X2] = 0;
                        MatrizJuego[this.Y3 - this.Velocidad, this.X3 - this.Velocidad] = 0;
                        MatrizJuego[this.Y4 - this.Velocidad, this.X4] = 0;
                    }
                    break;
            }


        }


    }
}
