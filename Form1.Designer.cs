using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace ChanGan
{
    partial class Form1
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer checkDeviceTimer;
        private bool notificationShown = false;

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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkDeviceTimer = new System.Windows.Forms.Timer();
            checkDeviceTimer.Interval = 3000; // Интервал в миллисекундах (здесь 5000 мс = 5 секунд)
            checkDeviceTimer.Tick += CheckForWord;
            checkDeviceTimer.Start();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(520, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 636);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.DragOver += new System.Windows.Forms.DragEventHandler(this.label1_DragOver);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(709, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Инструкция:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(470, 75);
            this.button1.TabIndex = 9;
            this.button1.Text = "Установка драйвера ADB (ADB RUN)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(470, 75);
            this.button2.TabIndex = 10;
            this.button2.Text = "Проверить соединенние с ГУ по ADB";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(470, 75);
            this.button3.TabIndex = 11;
            this.button3.Text = "Установка файлового менеджера";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 255);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(471, 440);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 707);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Changan App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await RunCommandAsync("devices");
        }

        private async Task RunCommandAsync(string command)
        {
            try
            {
                string adbDirectory = @"C:\adb"; // Путь к папке с файлами adb
                string fullCommand = command;

                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                processInfo.Arguments = $"-NoLogo -NoProfile -Command \"cd '{adbDirectory}'; .\\adb.exe {fullCommand}\"";
                processInfo.RedirectStandardOutput = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.OutputDataReceived += (sender, args) => AppendText(args.Data + Environment.NewLine);

                    process.Start();
                    process.BeginOutputReadLine();
                    await Task.Run(() => process.WaitForExit());
                }
            }
            catch (Exception ex)
            {
                AppendText("Error: " + ex.Message + Environment.NewLine);
            }
        }

        private void CheckForWord(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;

            // Перебираем строки в richTextBox1
            foreach (string line in lines)
            {
                // Ищем слово "device" в строке (игнорируем регистр)
                if (line.IndexOf("device", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Проверяем, что слово "device" находится как слово, а не часть другого слова
                    string[] words = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    bool containsOnlyDevice = false;

                    foreach (string word in words)
                    {
                        // Проверяем, является ли слово "device"
                        if (string.Equals(word, "device", StringComparison.OrdinalIgnoreCase))
                        {
                            containsOnlyDevice = true;
                            break;
                        }
                    }

                    // Если нашли только слово "device" и уведомление не было показано
                    if (containsOnlyDevice && !notificationShown)
                    {
                        // Показываем всплывающее окно с сообщением
                        MessageBox.Show("Слово 'device' обнаружено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Останавливаем таймер, чтобы всплывающее окно не появлялось снова
                        checkDeviceTimer.Stop();

                        // Устанавливаем флаг, что всплывающее окно было показано
                        notificationShown = true;
                        break; // Выходим из цикла, чтобы проверять только первую строку с "device"
                    }
                }
            }
        }

        private void AppendText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                if (!this.IsDisposed && !richTextBox1.IsDisposed)
                {
                    richTextBox1.AppendText(text);
                }
            }
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private RichTextBox richTextBox1;
    }
}

