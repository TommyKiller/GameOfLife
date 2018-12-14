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
                PaintGreed(e.Graphics, new Pen(Color.Green), Game.World.MapHeight, Game.World.MapWidth,
                    Game.World.MapWidth * Camera.Scale, Game.World.MapHeight * Camera.Scale);
                PaintMap(e.Graphics, new SolidBrush(Color.Green));
            }
        }

        private void PaintGreed(Graphics render, Pen pen, int rowsCount, int columnsCount, int width, int height) // BUG
        {
            for (int y = 0; y < rowsCount; ++y)
            {
                if ((y >= Camera.Location.Y - Scene.Location.Y) && (y <= Camera.Location.Y + Camera.Bounds.Height - Scene.Location.Y))
                {
                    render.DrawLine(pen, Scene.Location.X - Camera.Location.X, (y * Camera.Scale) + Scene.Location.Y - Camera.Location.Y,
                        Scene.Location.X + width - Camera.Location.X, (y * Camera.Scale) + Scene.Location.Y - Camera.Location.Y);
                }
            }
            for (int x = 0; x < columnsCount; ++x)
            {
                if ((x >= Camera.Location.X - Scene.Location.X) && (x <= Camera.Location.X + Camera.Bounds.Width - Scene.Location.X))
                {
                    render.DrawLine(pen, (x * Camera.Scale) + Scene.Location.X - Camera.Location.X, Scene.Location.Y - Camera.Location.Y,
                        (x * Camera.Scale) + Scene.Location.X - Camera.Location.X, Scene.Location.Y + height - Camera.Location.Y);
                }
            }
        }

        private void PaintMap(Graphics render, Brush brush)
        {
            for (int y = 0; y < Game.World.MapHeight; ++y)
            {
                for (int x = 0; x < Game.World.MapWidth; ++x)
                {
                    if ((x >= Camera.Location.X - Scene.Location.X) && (x <= Camera.Location.X + Camera.Bounds.Width - Scene.Location.X) &&
                        (y >= Camera.Location.Y - Scene.Location.Y) && (y <= Camera.Location.Y + Camera.Bounds.Height - Scene.Location.Y) &&
                        (Game.World.Map[y, x] == 1))
                    {
                        PaintObject(render, brush, (x + Scene.Location.X - Camera.Location.X) * Camera.Scale, (y + Scene.Location.Y - Camera.Location.Y) * Camera.Scale, Camera.Scale, Camera.Scale);
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

                Game.StartNew(settings.Seed, Scene.Height / Camera.Scale + 1, Scene.Width / Camera.Scale + 1, settings.PopulationRate);
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
                Camera.Relocate(new Point(Camera.Location.X + Camera.Scale, Camera.Location.Y));
                Scene.Invalidate();
            }
            else if (e.KeyCode == Keys.S)
            {
                Camera.Relocate(new Point(Camera.Location.X, Camera.Location.Y + Camera.Scale));
                Scene.Invalidate();
            }
            else if (e.KeyCode == Keys.W)
            {
                Camera.Relocate(new Point(Camera.Location.X, Camera.Location.Y - Camera.Scale));
                Scene.Invalidate();
            }
            else if (e.KeyCode == Keys.A)
            {
                Camera.Relocate(new Point(Camera.Location.X - Camera.Scale, Camera.Location.Y));
                Scene.Invalidate();
            }
        }
    }
}
