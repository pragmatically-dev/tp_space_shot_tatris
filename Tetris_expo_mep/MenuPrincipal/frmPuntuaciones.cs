using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_expo_mep;
namespace Tetris_expo_mep
{
    public partial class frmPuntuaciones : Form
    {
        public frmPuntuaciones()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Puntuaciones_Load(object sender, EventArgs e)
        {
            DB puntajeDB = new DB();
            List<JugadorDB> player = new List<JugadorDB>();
            player = puntajeDB.LeerPuntajes(player);
            dg1.DataSource = player;

        }
    }
}