using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Media;
using System.Diagnostics;
using StreamAlive;
using StreamAlive.Google.Apis.YouTube.Samples;
using System.Reflection;

namespace EventTimer
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form, IMessageFilter
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Imagepath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private string[] folderFile = null;
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
        private string[] config = { " ", " ", " ", " " };
        private string JokiAutomationPath = Environment.GetEnvironmentVariable("JokiAutomation");
        private string countDownString;
        private string breakTxt1 = "Dieser Teil des Gottesdienstes wird aus Datenschutzgründen nicht live übertragen.";
        private string breakTxt2 = "Die Liveübertragung wird in Kürze fortgesetzt, wir bitten um Ihr Verständnis!";
        Font countDownStringFont;
        SolidBrush countDownBrush;
        private DateTime eventTime = DateTime.Now;
        private Timer eventTimer;
        private Timer streamAlivetimer;
        private Timer shutdowntimer; // shut down sequence timer 10 seconds
        private SoundPlayer simpleSound;
        private bool SoundPlayerOn = false;
        private bool breakTxt1Active = false;
        private bool commandLineCall = false;
        private bool ShutDownSequence = false;
		private bool SwitchJoKiAutomation = false;
        private static Form1 JET;
        private static Search SEARCH;
        private bool StartSound = false;
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_LBUTTONDBLCLK = 0x203;
        const int WM_RBUTTONDOWN = 0x204;
        const int WM_RBUTTONUP = 0x205;
        const int WM_RBUTTONDBLCLK = 0x206;

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            return (
            m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONUP ||
            m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_RBUTTONDOWN ||
            m.Msg == WM_RBUTTONUP || m.Msg == WM_RBUTTONDBLCLK);
        }

        public void MausAktivieren()
        {
           //Cursor.Clip = altesRect; 
           Cursor.Show();
           Application.RemoveMessageFilter(this);
        }

        public void MausDeaktivieren()
        {
            //altesRect = Cursor.Clip;
            //neuesRect = new Rectangle(100, 100, 1, 1);
            //Cursor.Clip = neuesRect; 
            Cursor.Hide();
            Application.AddMessageFilter(this);
        }       

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.panel1.Size = new System.Drawing.Size(937, 551);
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
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(10, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<< vorheriges";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Imagepath
            // 
            this.Imagepath.BackColor = System.Drawing.Color.White;
            this.Imagepath.Location = new System.Drawing.Point(278, 430);
            this.Imagepath.Name = "Imagepath";
            this.Imagepath.Size = new System.Drawing.Size(128, 23);
            this.Imagepath.TabIndex = 2;
            this.Imagepath.Text = "Fotos";
            this.Imagepath.UseVisualStyleBackColor = false;
            this.Imagepath.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(144, 430);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "nächstes >>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.Location = new System.Drawing.Point(11, 497);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(262, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "<< START Diashow >>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(546, 430);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 22);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(778, 429);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(87, 22);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // SoundPath
            // 
            this.SoundPath.AutoEllipsis = true;
            this.SoundPath.BackColor = System.Drawing.Color.White;
            this.SoundPath.Location = new System.Drawing.Point(412, 430);
            this.SoundPath.Name = "SoundPath";
            this.SoundPath.Size = new System.Drawing.Size(128, 23);
            this.SoundPath.TabIndex = 8;
            this.SoundPath.Text = "Musik";
            this.SoundPath.UseVisualStyleBackColor = false;
            this.SoundPath.Click += new System.EventHandler(this.SoundPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(885, 550);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Imagepath);
            this.Controls.Add(this.SoundPath);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JoKi Gottesdienst";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormKeyPress);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {

            JET = new Form1();
            SEARCH = new Search();
            if (args.Length > 0)
            {
                JET.CommandInterpreter(Environment.GetCommandLineArgs());
            }
            JET.MausDeaktivieren();
            Application.ApplicationExit += new EventHandler(JET.OnApplicationExit);
            Application.Run(JET);
        }

        // write error information to logfile
        public static void writeLog(String path, String str)
        {
            String filename = Path.GetDirectoryName(path).ToString() + "\\EventTimerLog.txt";
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, str + "\n");
            }
            else
            {
                File.AppendAllText(filename, str + "\n");
            }
            return;
        }
        // checks live stream is active
        private static async void checkLiveStream()
        {
            try
            {
                await SEARCH.Run();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                string app_path = Assembly.GetExecutingAssembly().Location;
                writeLog(app_path, ex.Message);
                SEARCH.youtubeException = true;
            }
        }

        // interprets command line arguments if called from JokiAutomation - App
        private void CommandInterpreter(string[] commands)
        {
            commandLineCall = true;
            try
            {
                string cmd = commands[1];
                if ((cmd == "Pause") && (commands.Length == 4))
                {
                    if (commands[2].Length > 10)
                    {
                        breakTxt1 = commands[2];
                    }
                    if (commands[3].Length > 10)
                    {
                        breakTxt2 = commands[3];
                    }
                }
                else if (cmd == "Timer")
                {
                    DateTime dateNow = DateTime.Now;
                    eventTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, Convert.ToUInt16(commands[2].Substring(0, 2)), Convert.ToUInt16(commands[2].Substring(3, 2)), 0);
                }
                else
                {
                    throw new System.ArgumentException(" ", "original");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("JoKi EventTimer\nFormatfehler in Kommandozeilenaufruf");
            }
        }

        // eventhandler Button 'Fotos' (adapt path to fotos directory)
        private void button2_Click(object sender, System.EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = config[0];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                config[0] = folderBrowserDialog1.SelectedPath;
                System.IO.File.WriteAllLines(JokiAutomationPath + "Event.cfg", config);
                fillImageList();
            }
        }

        // read in images from configured Foto path for slide show
        private void fillImageList()
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
            string[] part1 = null/*, part2 = null, part3 = null*/;
            part1 = Directory.GetFiles(config[1], "*.wav");
            // part2 = Directory.GetFiles(config[1], "*.wav");
            // part3 = Directory.GetFiles(config[0], "*.xxx");

            folderSound = new string[part1.Length /* + part2.Length + part3.Length*/];
            Array.Copy(part1, 0, folderSound, 0, part1.Length);
            // Array.Copy(part2, 0, folderSound, part1.Length, part2.Length);
            // Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

            selectedSound = 0;
            endSound = folderSound.Length;
        }

        private void showImage(string path)
        {
            //PictureBox1.Location = Screen.PrimaryScreen.WorkingArea.Location;
            Image imgtemp = Image.FromFile(path);
            if (this.WindowState == FormWindowState.Maximized)
            {
                pictureBox1.Height = Screen.PrimaryScreen.WorkingArea.Height - Screen.PrimaryScreen.WorkingArea.Height / 24;
                pictureBox1.Width = Screen.PrimaryScreen.WorkingArea.Width - Screen.PrimaryScreen.WorkingArea.Width / 80;
            }
            else
            {
                pictureBox1.Width = imgtemp.Width / 3;
                pictureBox1.Height = imgtemp.Height / 3;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = imgtemp;
        }

        // show previous image, if format is supported
        private void prevImage()
        {
            try
            {
                if (selected == 0)
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
            catch (Exception)
            {
                MessageBox.Show("Nicht unterstütztes Image - Format!\njpeg, bmp und jpg sind möglich");
            }
        }

        // show next image, if format is supported
        private void nextImage()
        {
            try
            {
                if (selected == folderFile.Length - 1)
                {
                    selected = 0;
                    showImage(folderFile[selected]);
                }
                else
                {
                    selected = selected + 1;
                    showImage(folderFile[selected]);
                }
                if (eventTimer.Enabled == false)
                {  //show break text 1 or 2 if eventtimer is not active
                    breakTxt1Active = !breakTxt1Active;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nicht unterstütztes Image - Format!\njpeg, bmp und jpg sind möglich");
            }
        }

        // play next sound if sound format is supported
        private void nextSound()
        {
            try
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
                SoundPlayerOn = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Nicht unterstütztes Audioformat!\nEs wird nur *.wav unterstützt");
            }
        }

        // eventhandler Button 'vorheriges'
        private void button1_Click(object sender, System.EventArgs e)
        {
            prevImage();
        }

        // eventhandler Button 'nächstes'
        private void button3_Click(object sender, System.EventArgs e)
        {
            nextImage();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            nextImage();
        }

        // eventhandler Button 'Start / Stop Diashow' (start and stop slide show)
        private void button4_Click(object sender, System.EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button4.Text = "<< START Diashow >>";
                button4.BackColor = Color.Green;
            }
            else
            {
                timer1.Enabled = true;
                button4.Text = "<< STOP Diashow >>";
                button4.BackColor = Color.Red;
            }
        }

        //eventhandler form load, read in configfile and initialize slice and sound lists
        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (File.Exists(JokiAutomationPath + "Event.cfg"))
            {
                config = System.IO.File.ReadAllLines(JokiAutomationPath + "Event.cfg");
                if (Directory.Exists(config[0]))
                {
                    fillImageList();
                    this.ResumeLayout(false);
                    this.Focus();
                }
                else
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                if (Directory.Exists(config[1]))
                {
                    fillSoundList();
                }
                initializeEventTimer();

                if (commandLineCall)
                {
                    JET.WindowState = FormWindowState.Maximized;
                }
                ShutDownSequence = false;
                SwitchJoKiAutomation = false;
            }
            else
            {
                MessageBox.Show("Fehler bei Lesen Konfigurationsfile\nSystemvariable JokiAutomation fehlt\nbzw. zeigt auf falschen Pfad");
                Application.Exit();
            }
        }

        //form resize event handler controls features during maximize or minimize window eg. start\stop dia show and music enable buttons
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                button4.Text = "<< STOP Diashow >>";
                button4.BackColor = Color.Red;
                button1.Enabled = false;
                Imagepath.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                SoundPath.Enabled = false;
                button1.Visible = false;
                Imagepath.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                SoundPath.Visible = false;
                if (folderSound != null)
                {
                    nextSound();       // start sound
                }
                timer1.Enabled = true; // start slide show                 
            }
            else
            {
                button1.Visible = true;
                Imagepath.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                SoundPath.Enabled = true;
                if ((folderFile != null) && (folderFile.GetLength(0) > 0))
                {
                    button1.Enabled = true;
                    Imagepath.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                SoundPath.Visible = true;
                if (simpleSound != null)
                {
                    simpleSound.Stop(); // stop sound
                    SoundPlayerOn = false;
                }
            }
            if (folderFile != null)
            {
                showImage(folderFile[selected]);
                this.Focus();
            }
        }

        //paint event handler, writes text or countdown information into state line
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (eventTimer.Enabled == false)
                {   // no event timer running , set break text 
                    if (breakTxt1Active == false)
                    {
                        countDownString = breakTxt1;
                    }
                    else
                    {
                        countDownString = breakTxt2;
                    }
                }

                Size stringSize = Size.Ceiling(e.Graphics.MeasureString(countDownString, countDownStringFont));

                // Create solid brush.
                SolidBrush grayBrush = new SolidBrush(Color.Gray);
                // Create rectangle.
                //Rectangle rect = new Rectangle(pictureBox1.Width - 4 - stringSize.Width, pictureBox1.Height - 4 - stringSize.Height, stringSize.Width, stringSize.Height);
                Rectangle rect = new Rectangle(4, pictureBox1.Height - 4 - stringSize.Height, pictureBox1.Width, stringSize.Height);
                // Fill rectangle to screen.
                e.Graphics.FillRectangle(grayBrush, rect);
                e.Graphics.DrawString(countDownString, countDownStringFont,
                    countDownBrush, ((pictureBox1.Width - 4)) - (stringSize.Width),
                    ((pictureBox1.Height - 4)) - (stringSize.Height));
                string retString;
                int retStringSize = 4;
                if (SoundPlayerOn == false)
                {
                    if (StartSound == false)
                    {
                        StartSound = true;
                        nextSound();
                    }
                    else
                    {
                        retString = "M ";
                        e.Graphics.DrawString(retString, countDownStringFont, new SolidBrush(Color.Red), retStringSize, ((pictureBox1.Height - 4)) - (stringSize.Height));
                        stringSize = Size.Ceiling(e.Graphics.MeasureString(retString, countDownStringFont));
                        retStringSize += stringSize.Width;
                    }
                }
                if ((SEARCH.streamAlive == false)&& (eventTimer.Enabled == true))// no live stream
                {
                    retString = "I ";
                    e.Graphics.DrawString(retString, countDownStringFont, new SolidBrush(Color.Red), retStringSize, ((pictureBox1.Height - 4)) - (stringSize.Height));
                    stringSize = Size.Ceiling(e.Graphics.MeasureString(retString, countDownStringFont));
                    retStringSize += stringSize.Width;
                }
                if (SEARCH.youtubeException == true) // youtube exception
                {
                    retString = "Ex ";
                    e.Graphics.DrawString(retString, countDownStringFont, new SolidBrush(Color.Red), retStringSize, ((pictureBox1.Height - 4)) - (stringSize.Height));
                    stringSize = Size.Ceiling(e.Graphics.MeasureString(retString, countDownStringFont));
                    retStringSize += stringSize.Width;
                }
                if (ShutDownSequence == true)
                {
                    retString = "S ";
                    e.Graphics.DrawString(retString, countDownStringFont, new SolidBrush(Color.Red), retStringSize, ((pictureBox1.Height - 4)) - (stringSize.Height));
                    stringSize = Size.Ceiling(e.Graphics.MeasureString(retString, countDownStringFont));
                    retStringSize += stringSize.Width;
                }
            }
        }

        //keyboard press event handler for controlling some features eg.music on off
        private void FormKeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 0x000d) //<ctrl + 'M'>
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    if (SoundPlayerOn)
                    {
                        simpleSound.Stop(); // stop sound
                        SoundPlayerOn = false;
                    }
                    else
                    {
                        if (folderSound != null)
                        {
                            nextSound();       // start sound
                        }
                    }
                    showImage(folderFile[selected]);
                }
                e.Handled = true;
            }
            else if (e.KeyChar == 0x0006) //<ctrl + 'F'>
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 0x0013) //<ctrl + 'S'>
            {
                if (!ShutDownSequence)
                {
                    ShutDownSequence = true;
                    System.Diagnostics.ProcessStartInfo JoKiAutomation = new ProcessStartInfo();
                    JoKiAutomation.FileName = Environment.GetEnvironmentVariable("JokiAutomation") + "JokiAutomation.exe";
                    JoKiAutomation.Arguments = "Altar";
                    Process.Start(JoKiAutomation);
                    shutdowntimer.Interval = 10000;  //elapsed event after 10 seconds
                    shutdowntimer.Start();
                }
                e.Handled = true;
                showImage(folderFile[selected]);
            }

        }

        // shutdown timer event
        void _shutdowntimer_Elapsed(object sender, EventArgs e) 
        {
            if (simpleSound != null)
            {
                simpleSound.Stop();
                SoundPlayerOn = false;
            }
            eventTimer.Stop();
            Application.Exit();
        }

        // stream alive timer event
        void _streamAlivetimer_Elapsed(object sender, EventArgs e)
        {
            if ((SEARCH.youtubeException == false)&&(SEARCH.streamAlive == false)&&(eventTimer.Enabled == true))
            {
                checkLiveStream();
            }
            else
            {
                streamAlivetimer.Stop();
            }
        }

        //initialize event timer and starts timer if eventtime is in future
        private void initializeEventTimer()
        {

            if ((config[2].Length > 2) && (!commandLineCall))
            {
                eventTime = DateTime.Parse(config[2]);
            }

            dateTimePicker1.Value = eventTime;
            dateTimePicker2.Value = eventTime;

            eventTimer = new Timer();
            shutdowntimer = new Timer(); // shut down sequence timer 10 seconds
            streamAlivetimer = new Timer(); // check live stream started each 10 seconds
            countDownStringFont = new Font(new FontFamily("Arial"), 25,
                                           FontStyle.Bold);
            countDownBrush = new SolidBrush(Color.White);
            // Events registrieren
            eventTimer.Tick += new EventHandler(eventTimer_Tick);
            shutdowntimer.Tick += new EventHandler(_shutdowntimer_Elapsed);
            streamAlivetimer.Tick += new EventHandler(_streamAlivetimer_Elapsed);
            streamAlivetimer.Interval = 60000;  // stream alive timer elapsed event after 60 seconds
            streamAlivetimer.Start();

            // Eigenschaften setzen und Timer starten
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            eventTimer.Interval = 50;
            if (eventTime > DateTime.Now)
            {
                eventTimer.Start();
            }
        }

        //eventhandler Timer tick for event countdown calculates remaining minutes seconds and writes result into countdown string 
        private void eventTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan leftTime = eventTime.Subtract(DateTime.Now);
            if (leftTime.TotalSeconds < 0)
            {
                //countDownString = "00:00:00:00";
                countDownString = "00:00:00";
                Refresh();
                if (simpleSound != null)
                {
                    simpleSound.Stop();
                    SoundPlayerOn = false;
                }
                eventTimer.Stop();
                Application.Exit();
            }
            else
            {
                if (leftTime.TotalSeconds < 30)
                {
                    if (!SwitchJoKiAutomation)
                    {
                        SwitchJoKiAutomation = true;
                        ShutDownSequence = true;
                        System.Diagnostics.ProcessStartInfo JoKiAutomation = new ProcessStartInfo();
                        JoKiAutomation.FileName = Environment.GetEnvironmentVariable("JokiAutomation") + "JokiAutomation.exe";
                        JoKiAutomation.Arguments = "Altar";
                        Process.Start(JoKiAutomation);
                    }
                }
                if ((leftTime.TotalSeconds < 24) && (simpleSound != null))
                {
                    simpleSound.Stop();
                    SoundPlayerOn = false;
                }
                if(leftTime.TotalSeconds < 18)
                {
                    eventTimer.Stop();
                    Application.Exit();
                }
                countDownString = /*leftTime.Hours.ToString("00") + ":" +*/
                "JoKi Hersbruck Livegottesdienst beginnt in " +
                leftTime.Minutes.ToString("00") + ":" +
                leftTime.Seconds.ToString("00") + ":" +
                (leftTime.Milliseconds / 10).ToString("00") + " Minuten";
                Refresh();
            }
        }

        // eventhandler Button 'Date' (adapt event date)
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (eventTimer != null)
            {
                eventTimer.Stop();
                eventTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                config[2] = eventTime.ToString();
                if (eventTime > DateTime.Now)
                {
                    System.IO.File.WriteAllLines(JokiAutomationPath + "Event.cfg", config);
                    eventTimer.Start();
                }
            }
        }

        // eventhandler Button 'Time' (adapt event time)
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (eventTimer != null)
            {

                eventTimer.Stop();
                eventTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
                config[2] = eventTime.ToString();
                if (eventTime > DateTime.Now)
                {
                    System.IO.File.WriteAllLines(JokiAutomationPath + "Event.cfg", config);
                    eventTimer.Start();
                }
            }
        }

        // eventhandler Button 'Musik' (adapt path to sound directory)
        private void SoundPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = config[1];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                config[1] = folderBrowserDialog1.SelectedPath;
                System.IO.File.WriteAllLines(JokiAutomationPath + "Event.cfg", config);
                fillSoundList();
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
                try
                {
                    if (!ShutDownSequence)
                    {
                        ShutDownSequence = true;
                        System.Diagnostics.ProcessStartInfo JoKiAutomation = new ProcessStartInfo();
                        JoKiAutomation.FileName = Environment.GetEnvironmentVariable("JokiAutomation") + "JokiAutomation.exe";
                        JoKiAutomation.Arguments = "Altar";
                        Process.Start(JoKiAutomation);
                    }
                JET.MausAktivieren();
                }
                catch (Exception)
                {
                    MessageBox.Show("JoKiAutomation\nFehler in JoKi Automation Kommandozeilenaufruf");
                }
        }

        private const int WS_SYSMENU = 0x80000; //disable windows close on menu

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }
    }
}
