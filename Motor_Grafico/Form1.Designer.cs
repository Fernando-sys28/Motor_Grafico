namespace Motor_Grafico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.traslationsXScroll = new System.Windows.Forms.TrackBar();
            this.escalarScroll = new System.Windows.Forms.TrackBar();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.camaraYScroll = new System.Windows.Forms.TrackBar();
            this.traslationsZScroll = new System.Windows.Forms.TrackBar();
            this.camaraXScroll = new System.Windows.Forms.TrackBar();
            this.camaraZScroll = new System.Windows.Forms.TrackBar();
            this.traslationsYScroll = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsXScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalarScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraYScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsZScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraXScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraZScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsYScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(290, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(741, 439);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rotar en X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rotar en Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(186, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Rotar en Z";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(186, 220);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 51);
            this.button4.TabIndex = 5;
            this.button4.Text = "Rotar en XYZ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(68, 360);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cube";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(68, 389);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Cylinder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(68, 447);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Sphere";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(68, 476);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 53);
            this.button8.TabIndex = 9;
            this.button8.Text = "Prisma pentagonal";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(68, 418);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Cone";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // traslationsXScroll
            // 
            this.traslationsXScroll.Location = new System.Drawing.Point(290, 510);
            this.traslationsXScroll.Margin = new System.Windows.Forms.Padding(2);
            this.traslationsXScroll.Maximum = 25;
            this.traslationsXScroll.Minimum = -25;
            this.traslationsXScroll.Name = "traslationsXScroll";
            this.traslationsXScroll.RightToLeftLayout = true;
            this.traslationsXScroll.Size = new System.Drawing.Size(741, 45);
            this.traslationsXScroll.TabIndex = 11;
            this.traslationsXScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.traslationsXScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.traslationsXScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseMove);
            this.traslationsXScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // escalarScroll
            // 
            this.escalarScroll.Location = new System.Drawing.Point(1034, 26);
            this.escalarScroll.Margin = new System.Windows.Forms.Padding(2);
            this.escalarScroll.Maximum = 25;
            this.escalarScroll.Minimum = -25;
            this.escalarScroll.Name = "escalarScroll";
            this.escalarScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.escalarScroll.Size = new System.Drawing.Size(45, 439);
            this.escalarScroll.TabIndex = 12;
            this.escalarScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.escalarScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseDown);
            this.escalarScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseMove);
            this.escalarScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.escalarScroll_MouseUp);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(28, 26);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(84, 24);
            this.btnBuscarArchivo.TabIndex = 13;
            this.btnBuscarArchivo.Text = "Open OBJ";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click_1);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(28, 86);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 268);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(139, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Pintar Figura";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // camaraYScroll
            // 
            this.camaraYScroll.Location = new System.Drawing.Point(1082, 26);
            this.camaraYScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraYScroll.Maximum = 25;
            this.camaraYScroll.Minimum = -25;
            this.camaraYScroll.Name = "camaraYScroll";
            this.camaraYScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.camaraYScroll.Size = new System.Drawing.Size(45, 439);
            this.camaraYScroll.TabIndex = 16;
            this.camaraYScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraYScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseDown);
            this.camaraYScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseMove);
            this.camaraYScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseUp);
            // 
            // traslationsZScroll
            // 
            this.traslationsZScroll.Location = new System.Drawing.Point(1263, 26);
            this.traslationsZScroll.Margin = new System.Windows.Forms.Padding(2);
            this.traslationsZScroll.Maximum = 25;
            this.traslationsZScroll.Minimum = -25;
            this.traslationsZScroll.Name = "traslationsZScroll";
            this.traslationsZScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.traslationsZScroll.Size = new System.Drawing.Size(45, 439);
            this.traslationsZScroll.TabIndex = 17;
            this.traslationsZScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.traslationsZScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseDown);
            this.traslationsZScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseMove);
            this.traslationsZScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseUp);
            // 
            // camaraXScroll
            // 
            this.camaraXScroll.Location = new System.Drawing.Point(290, 469);
            this.camaraXScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraXScroll.Maximum = 25;
            this.camaraXScroll.Minimum = -25;
            this.camaraXScroll.Name = "camaraXScroll";
            this.camaraXScroll.RightToLeftLayout = true;
            this.camaraXScroll.Size = new System.Drawing.Size(741, 45);
            this.camaraXScroll.TabIndex = 18;
            this.camaraXScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraXScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseDown);
            this.camaraXScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseMove);
            this.camaraXScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseUp);
            // 
            // camaraZScroll
            // 
            this.camaraZScroll.Location = new System.Drawing.Point(1141, 26);
            this.camaraZScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraZScroll.Maximum = 25;
            this.camaraZScroll.Minimum = -25;
            this.camaraZScroll.Name = "camaraZScroll";
            this.camaraZScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.camaraZScroll.Size = new System.Drawing.Size(45, 439);
            this.camaraZScroll.TabIndex = 19;
            this.camaraZScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraZScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseDown);
            this.camaraZScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseMove);
            this.camaraZScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseUp);
            // 
            // traslationsYScroll
            // 
            this.traslationsYScroll.Location = new System.Drawing.Point(1201, 26);
            this.traslationsYScroll.Margin = new System.Windows.Forms.Padding(2);
            this.traslationsYScroll.Maximum = 25;
            this.traslationsYScroll.Minimum = -25;
            this.traslationsYScroll.Name = "traslationsYScroll";
            this.traslationsYScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.traslationsYScroll.Size = new System.Drawing.Size(45, 439);
            this.traslationsYScroll.TabIndex = 20;
            this.traslationsYScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.traslationsYScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.traslationsYScroll_MouseDown);
            this.traslationsYScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.traslationsYScroll_MouseMove);
            this.traslationsYScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.traslationsYScroll_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(1057, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 120);
            this.label1.TabIndex = 21;
            this.label1.Text = "E\r\nS\r\nC\r\nA\r\nL\r\nA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(1105, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 160);
            this.label2.TabIndex = 22;
            this.label2.Text = "C\r\nA\r\nM\r\nA\r\nR\r\nA\r\n\r\nY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(1164, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 160);
            this.label3.TabIndex = 23;
            this.label3.Text = "C\r\nA\r\nM\r\nA\r\nR\r\nA\r\n\r\nZ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(1225, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 220);
            this.label4.TabIndex = 24;
            this.label4.Text = "T\r\nR\r\nA\r\nS\r\nL\r\nA\r\nD\r\nA\r\nR\r\n\r\nY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(1297, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 220);
            this.label5.TabIndex = 25;
            this.label5.Text = "T\r\nR\r\nA\r\nS\r\nL\r\nA\r\nD\r\nA\r\nR\r\n\r\nZ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(612, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "CAMARA X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(602, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "TRASLADAR X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 585);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.traslationsYScroll);
            this.Controls.Add(this.camaraZScroll);
            this.Controls.Add(this.camaraXScroll);
            this.Controls.Add(this.traslationsZScroll);
            this.Controls.Add(this.camaraYScroll);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.escalarScroll);
            this.Controls.Add(this.traslationsXScroll);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsXScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalarScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraYScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsZScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraXScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraZScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsYScroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TrackBar escalarScroll;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.TrackBar traslationsXScroll;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar camaraYScroll;
        private System.Windows.Forms.TrackBar traslationsZScroll;
        private System.Windows.Forms.TrackBar camaraXScroll;
        private System.Windows.Forms.TrackBar camaraZScroll;
        private System.Windows.Forms.TrackBar traslationsYScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

