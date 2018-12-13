using Engine;

namespace GameOfLife
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalTimer = new System.Windows.Forms.Timer(this.components);
            this.Scene = new Engine.Scene();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.MainMenuStart,
            this.MainMenuPause});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuNew,
            this.toolStripMenuItem1,
            this.MainMenuExit});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // MainMenuNew
            // 
            this.MainMenuNew.Name = "MainMenuNew";
            this.MainMenuNew.Size = new System.Drawing.Size(180, 22);
            this.MainMenuNew.Text = "New...";
            this.MainMenuNew.Click += new System.EventHandler(this.MainMenuNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // MainMenuExit
            // 
            this.MainMenuExit.Name = "MainMenuExit";
            this.MainMenuExit.Size = new System.Drawing.Size(180, 22);
            this.MainMenuExit.Text = "Exit";
            this.MainMenuExit.Click += new System.EventHandler(this.MainMenuExit_Click);
            // 
            // MainMenuStart
            // 
            this.MainMenuStart.Name = "MainMenuStart";
            this.MainMenuStart.Size = new System.Drawing.Size(43, 20);
            this.MainMenuStart.Text = "Start";
            this.MainMenuStart.Click += new System.EventHandler(this.MainMenuSart_Click);
            // 
            // MainMenuPause
            // 
            this.MainMenuPause.Name = "MainMenuPause";
            this.MainMenuPause.Size = new System.Drawing.Size(50, 20);
            this.MainMenuPause.Text = "Pause";
            this.MainMenuPause.Click += new System.EventHandler(this.MainMenuPause_Click);
            // 
            // GlobalTimer
            // 
            this.GlobalTimer.Tick += new System.EventHandler(this.GlobalTimer_Tick);
            // 
            // Scene
            // 
            this.Scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scene.Location = new System.Drawing.Point(0, 24);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(800, 426);
            this.Scene.TabIndex = 1;
            this.Scene.Paint += new System.Windows.Forms.PaintEventHandler(this.Scene_Paint);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Scene);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainWindow";
            this.Text = "Game of Life";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenuExit;
        private System.Windows.Forms.Timer GlobalTimer;
        private Scene Scene;
        private System.Windows.Forms.ToolStripMenuItem MainMenuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuStart;
        private System.Windows.Forms.ToolStripMenuItem MainMenuPause;
    }
}

