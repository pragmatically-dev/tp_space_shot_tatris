using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_expo_mep.Juego.Figuras
{
    class FigL
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

        private int velocidad=1;
        public int Velocidad { get { return velocidad; } }


        #endregion

        public FigL(int[] PosY, int[] PosX, int Tag)
        {
            this.Y1 = PosY[0]; this.X1 = PosX[0];
            this.Y2 = PosY[1]; this.X2 = PosX[1];
            this.Y3 = PosY[2]; this.X3 = PosX[2];
            this.Y4 = PosY[3]; this.X4 = PosX[3];
            this.Tag = Tag;
            this.velocidad = 1;

        }

        public void Mover(int[,] M)
        {
            while (Y4<17)
            {

                M[Y1 += velocidad, X1] = this.Tag;

                M[Y2 += velocidad, X2] = this.Tag;

                M[Y3 += velocidad, X3] = this.Tag;

                M[Y4 += velocidad, X4] = this.Tag;



                M[Y1 - velocidad, X1] = 0;
                M[Y4 - velocidad, X4] = 0;
                System.Threading.Thread.Sleep(700);
            }
            
        }


        private void Comprob(int n) { 
        


        }
        

    }

}
