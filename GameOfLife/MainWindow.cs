using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameComponents;
using Engine;

namespace GameOfLife
{
    public partial class MainWindow : Form
    {
        private Game Game;
        private Camera Camera;

        public MainWindow()
        {
            InitializeComponent();

            ClientSize = Screen.PrimaryScreen.Bounds.Size;

            Game = new Game();
        }

        // Game Loop //

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {
            Task iterateTask = new Task(new Action(Game.Iterate));
            iterateTask.RunSynchronously();

            Task paintTask = new Task(new Action(PaintAction));
            paintTask.RunSynchronously();
        }

        private void PaintAction()
        {
            Scene.Invalidate();
        }

        // Rendering //

        private void Scene_Paint(object sender, PaintEventArgs e)
        {
            if (Game.IsStarted)
            {
                PaintGreed(e.Graphics, new Pen(Color.Green), Game.World.MapHeight + 1, Game.World.MapWidth + 1);
                PaintMap(e.Graphics, new SolidBrush(Color.Green));
            }
        }

        private void PaintGreed(Graphics render, Pen pen, int rowsCount, int columnsCount)
        {
            for (int i = Scene.Location.Y; i < Scene.Location.Y + rowsCount; ++i)
            {
                render.DrawLine(pen, Camera.Location.X - Scene.Location.X, i * Camera.Scale,
                    Camera.Location.X + Camera.Bounds.Width - Scene.Location.X, i * Camera.Scale);
            }
            for (int i = Scene.Location.X; i < Scene.Location.X + columnsCount; ++i)
            {
                render.DrawLine(pen, i * Camera.Scale, Camera.Location.Y - Scene.Location.Y,
                    i * Camera.Scale, Camera.Location.Y + Camera.Bounds.Height - Scene.Location.Y);
            }
        }

        private void PaintMap(Graphics render, Brush brush)
        {
            for (int y = 0; y < Game.World.MapHeight; ++y)
            {
                for (int x = 0; x < Game.World.MapWidth; ++x)
                {
                    if ((x >= Camera.Location.X) && (x <= Camera.Location.X + Camera.Bounds.Width) &&
                        (y >= Camera.Location.Y) && (x <= Camera.Location.Y + Camera.Bounds.Height) &&
                        (Game.World.Map[y, x] == 1))
                    {
                        PaintObject(render, brush, (x - Scene.Location.X) * Camera.Scale, (y - Scene.Location.Y) * Camera.Scale, Camera.Scale, Camera.Scale);
                    }
                }
            }
        }

        private void PaintObject(Graphics render, Brush brush, int x, int y, int width, int height)
        {
            render.FillRectangle(brush, x, y, width, height);
        }

        // Main Menu Items //

        private void MainMenuNew_Click(object sender, EventArgs e)
        {
            GlobalTimer.Enabled = false;

            Settings settings = new Settings();
            settings.ShowDialog();

            if (settings.IsHandled)
            {
                if (Camera == null)
                {
                    Camera = new Camera(Scene.Location, Scene.Bounds.Size, settings.CameraScale);
                }
                else
                {
                    Camera.ChangeScale(settings.CameraScale);
                    Camera.Reshape(Scene.Bounds.Size);
                    Camera.Relocate(Scene.Location);
                }

                Game.StartNew(settings.Seed, (Scene.Height + 1) / Camera.Scale, (Scene.Width + 1) / Camera.Scale, settings.PopulationRate);
                GlobalTimer.Interval = 50;
                Scene.Invalidate();
            }
        }

        private void MainMenuSart_Click(object sender, EventArgs e)
        {
            GlobalTimer.Enabled = true;
        }

        private void MainMenuPause_Click(object sender, EventArgs e)
        {
            GlobalTimer.Enabled = false;
        }

        private void MainMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Camera.Relocate(new Point(Camera.Location.X + 5, Camera.Location.Y));
            }
        }
    }
}
