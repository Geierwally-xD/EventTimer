using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Media;

namespace imageviewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button Imagepath;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private string [] folderFile = null;
        private string[] folderSound = null;
        private int selected = 0;
		private int end = 0;
        private int selectedSound = 0;
        private int endSound = 0;
        private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button4;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button SoundPath;
        private System.ComponentModel.IContainer components;
        private string[] config = { " ", " ", " " };
        private string countDownString;
        Font countDownStringFont;
        SolidBrush countDownBrush;
        private DateTime eventTime;
        private Timer eventTimer;
        private SoundPlayer simpleSound;

        public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Imagepath = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.SoundPath = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 481);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<< vorheriges";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Imagepath
            // 
            this.Imagepath.Location = new System.Drawing.Point(280, 499);
            this.Imagepath.Name = "Imagepath";
            this.Imagepath.Size = new System.Drawing.Size(128, 23);
            this.Imagepath.TabIndex = 2;
            this.Imagepath.Text = "Fotos";
            this.Imagepath.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 499);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "nächstes >>";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 528);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(262, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "<< START Diashow >>";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(569, 501);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 21);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(801, 501);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(87, 21);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // SoundPath
            // 
            this.SoundPath.AutoEllipsis = true;
            this.SoundPath.Location = new System.Drawing.Point(414, 499);
            this.SoundPath.Name = "SoundPath";
            this.SoundPath.Size = new System.Drawing.Size(128, 23);
            this.SoundPath.TabIndex = 8;
            this.SoundPath.Text = "Musik";
            this.SoundPath.Click += new System.EventHandler(this.SoundPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(937, 550);
            this.Controls.Add(this.SoundPath);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Imagepath);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JoKi Gottesdienst";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            folderBrowserDialog1.SelectedPath = config[0];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
                config[0] = folderBrowserDialog1.SelectedPath;
                System.IO.File.WriteAllLines("Event.cfg", config);
                fillImageList();
			}
		}

        private void fillImageList ()
        {
            string[] part1 = null, part2 = null, part3 = null;
            part1 = Directory.GetFiles(config[0], "*.jpg");
            part2 = Directory.GetFiles(config[0], "*.jpeg");
            part3 = Directory.GetFiles(config[0], "*.bmp");

            folderFile = new string[part1.Length + part2.Length + part3.Length];
            
            Array.Copy(part1, 0, folderFile, 0, part1.Length);
            Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
            Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

            selected = 0;
            end = folderFile.Length;
            if (folderFile.GetLength(0) > 0)
            {
                showImage(folderFile[selected]);
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void fillSoundList()
        {
            string[] part1 = null, part2 = null/*, part3 = null*/;
            part1 = Directory.GetFiles(config[1], "*.mp3");
            part2 = Directory.GetFiles(config[1], "*.wav");
           // part3 = Directory.GetFiles(config[0], "*.xxx");

            folderSound = new string[part1.Length + part2.Length /*+ part3.Length*/];

            Array.Copy(part1, 0, folderSound, 0, part1.Length);
            Array.Copy(part2, 0, folderSound, part1.Length, part2.Length);
           // Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

            selectedSound = 0;
            endSound = folderSound.Length;
        }

        private void showImage(string path)
		{
            //PictureBox1.Location = Screen.PrimaryScreen.WorkingArea.Location;
            Image imgtemp = Image.FromFile(path);
            if (timer1.Enabled == true)
            {
                pictureBox1.Height = Screen.PrimaryScreen.WorkingArea.Height;
                pictureBox1.Width = Screen.PrimaryScreen.WorkingArea.Width;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Width = imgtemp.Width;
                pictureBox1.Height = imgtemp.Height;
            }
			pictureBox1.Image = imgtemp;
		}

		private void prevImage()
		{
			if(selected == 0)
			{
				selected = folderFile.Length - 1;
				showImage(folderFile[selected]);		
			}
			else
			{
				selected = selected - 1;                				
				showImage(folderFile[selected]);
			}
		}

		private void nextImage()
		{
			if(selected == folderFile.Length - 1)
			{
				selected = 0;				
				showImage(folderFile[selected]);
			}
			else
			{
				selected = selected + 1;                				
				showImage(folderFile[selected]);
			}
		}

        private void nextSound()
        {

            if (selectedSound == folderSound.Length - 1)
            {
                selectedSound = 0;
            }
            else
            {
                selectedSound = selectedSound + 1;
            }
            simpleSound = new SoundPlayer(folderSound[selectedSound]);
            simpleSound.Play();
            simpleSound.PlayLooping();
        }


        private void button1_Click(object sender, System.EventArgs e)
		{
			prevImage();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			nextImage();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			nextImage();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(timer1.Enabled == true)
			{
				timer1.Enabled = false;
				button4.Text = "<< START Diashow >>";
			}
			else
			{
				timer1.Enabled = true;
				button4.Text = "<< STOP Diashow >>";
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            if (File.Exists("Event.cfg"))
            {
                config = System.IO.File.ReadAllLines("Event.cfg");
                if (Directory.Exists(config[0]))
                {
                    fillImageList();
                }
                else
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                if(Directory.Exists(config[1]))
                {
                    fillSoundList();
                }
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            initializeEventTimer();
        }

        private void Form1_Resize(object sender, EventArgs e)
        { 
           if (this.WindowState == FormWindowState.Maximized)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                SoundPath.Enabled = false;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                SoundPath.Visible = false;
                if (folderSound != null)
                {
                    nextSound();
                }
            }
            else
            {
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                SoundPath.Enabled = true;
                if ((folderFile != null)&&(folderFile.GetLength(0)>0))
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                SoundPath.Visible = true;
                if (simpleSound != null)
                {
                    simpleSound.Stop();
                }
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Size stringSize = Size.Ceiling(e.Graphics.MeasureString(countDownString, countDownStringFont));
            e.Graphics.DrawString(countDownString, countDownStringFont,
                countDownBrush, ((this.Width - 4) / 2) - (stringSize.Width / 2),
                ((this.Height - 32) / 2) - (stringSize.Height / 2));
        }

        private void initializeEventTimer()
        {
            // Initialisieren
            if (config[2].Length > 2)
            {
                eventTime = DateTime.Parse(config[2]);
            }
            else
            {
                eventTime = DateTime.Now;
            }
            dateTimePicker1.Value = eventTime;
            dateTimePicker2.Value = eventTime;

            eventTimer = new Timer();
            countDownStringFont = new Font(new FontFamily("Arial"), 50,
                                           FontStyle.Bold);
            countDownBrush = new SolidBrush(Color.White);
            // Events registrieren
            eventTimer.Tick += new EventHandler(eventTimer_Tick);

            // Eigenschaften setzen und Timer starten
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            eventTimer.Interval = 50;
            if (eventTime > DateTime.Now)
            {
                eventTimer.Start();
            }
        }

        private void eventTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan leftTime = eventTime.Subtract(DateTime.Now);
            if (leftTime.TotalSeconds < 0)
            {
                countDownString = "00:00:00:00";
                Refresh();
                eventTimer.Stop();
                if (simpleSound != null)
                {
                    simpleSound.Stop();
                }
                Application.Exit();
            }
            else
            {
                countDownString = leftTime.Hours.ToString("00") + ":" +
                  leftTime.Minutes.ToString("00") + ":" +
                  leftTime.Seconds.ToString("00") + ":" +
                   (leftTime.Milliseconds / 10).ToString("00");
                Refresh();
            }
        }
 
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (eventTimer != null)
            {
                eventTimer.Stop();
                eventTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                config[2] = eventTime.ToString();
                if (eventTime > DateTime.Now)
                {
                    System.IO.File.WriteAllLines("Event.cfg", config);
                    eventTimer.Start();
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (eventTimer != null)
            {

                eventTimer.Stop();
                eventTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                config[2] = eventTime.ToString();
                if (eventTime > DateTime.Now)
                {
                    System.IO.File.WriteAllLines("Event.cfg", config);
                    eventTimer.Start();
                }
            }
        }

        private void SoundPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = config[1];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                config[1] = folderBrowserDialog1.SelectedPath;
                System.IO.File.WriteAllLines("Event.cfg", config);
                fillSoundList();
            }
        }
    }
}
