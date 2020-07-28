using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris_expo_mep.Juego.Bala
{
    class Bala
    {
        public int Y1 { get; set; }
        public int X1 { get; set; }
        public int Tag { get; set; }
        private int velocidad = 1;
        public int Vel { get { return Vel; } }
        public bool Colision { get; set; }

        public Bala(int t)
        {
            this.Tag = t;
            this.Colision = false;
        }
        public void MoverBala(int[,] M, int Y, int X)
        {
            int pts=0;
            Y -= 1;

                while (Colision == false)
                {

                if (Y > 1)
                {
                    if (M[Y - 1, X] == 2 )
                    {
                        M[Y, X] = 0;
                        M[Y - 1, X] = 0;
                        velocidad = 0;
                        Juego.SbreakBloq.Play();
                        Juego.punt++;
                        Juego.cantBloques--;
                        break;
                    }
                    else
                    {
                        M[Y -= velocidad, X] = Tag;
                        M[Y + velocidad, X] = 0;

                    }
                }
                else { break; }
                    Thread.Sleep(50);

                }
            

        }

    }
}
