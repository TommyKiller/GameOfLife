using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Settings : Form
    {
        public bool IsHandled { get; private set; }
        public int CameraScale { get; private set; }
        public int Seed { get; private set; }
        public int PopulationRate { get; private set; }

        public Settings()
        {
            InitializeComponent();
        }
        private void DigitInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void CheckInput()
        {
            int occupancy = Int32.Parse(OccupancyIn.Text);
            if (occupancy < 1 && occupancy > 100)
                throw new Exception("Occupancy must be in (1, 100]!");
            if (Int32.Parse(ScaleIn.Text) < 1)
                throw new Exception("Scale must be 1 or more!");
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            try
            {
                CheckInput();
                PopulationRate = Int32.Parse(OccupancyIn.Text);
                CameraScale = Int32.Parse(ScaleIn.Text) + 1;
                if (SeedIn.Text != String.Empty)
                {
                    Seed = Int32.Parse(SeedIn.Text);
                }
                else
                {
                    Seed = DateTime.Now.Millisecond;
                }
                IsHandled = true;
                Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            IsHandled = false;
            Close();
        }
    }
}
