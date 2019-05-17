namespace PlaneCrash
{
    partial class NewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            #region Windows Form Designer generated code
        }
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>

            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
                this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.lblLifes = new System.Windows.Forms.Label();
                this.statusStrip1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // statusStrip1
                // 
                this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
                this.statusStrip1.Location = new System.Drawing.Point(0, 424);
                this.statusStrip1.Name = "statusStrip1";
                this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
                this.statusStrip1.Size = new System.Drawing.Size(963, 26);
                this.statusStrip1.TabIndex = 0;
                this.statusStrip1.Text = "statusStrip1";
                // 
                // toolStripSplitButton1
                // 
                this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.toolStripSplitButton1.DropDownButtonWidth = 0;
                this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
                this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.toolStripSplitButton1.Name = "toolStripSplitButton1";
                this.toolStripSplitButton1.Size = new System.Drawing.Size(25, 24);
                this.toolStripSplitButton1.Text = "toolStripSplitButton1";
                this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
                // 
                // pictureBox1
                // 
                this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
                this.pictureBox1.Image = global::PlaneCrash.Properties.Resources.heart;
                this.pictureBox1.InitialImage = global::PlaneCrash.Properties.Resources.heart;
                this.pictureBox1.Location = new System.Drawing.Point(0, 1);
                this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
                this.pictureBox1.Name = "pictureBox1"; this.pictureBox1.Size = new System.Drawing.Size(40, 38);
                this.pictureBox1.TabIndex = 2;
                this.pictureBox1.TabStop = false;
                // 
                // lblLifes
                // 
                this.lblLifes.AutoSize = true;
                this.lblLifes.BackColor = System.Drawing.Color.Transparent;
                this.lblLifes.Location = new System.Drawing.Point(49, 16);
                this.lblLifes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.lblLifes.Name = "lblLifes";
                this.lblLifes.Size = new System.Drawing.Size(0, 17);
                this.lblLifes.TabIndex = 3;
                // 
                // NewGame
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackgroundImage = global::PlaneCrash.Properties.Resources.sky;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(963, 450);
                this.Controls.Add(this.lblLifes);
                this.Controls.Add(this.pictureBox1);
                this.Controls.Add(this.statusStrip1);
                this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                this.Name = "NewGame";
                this.Text = "NewGame";
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGame_Paint);
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGame_KeyDown);
                this.statusStrip1.ResumeLayout(false);
                this.statusStrip1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

         }
        

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLifes;
    }
}