
namespace DesApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null; // экземпляр интерфейса, показывающий есть ли посторонии компоненты интерфейса
        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) // Освобождает все ресурсы, занятые модулем component.
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // удаляет, высвобождает или сбрасывает неуправляемые ресурсы.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1)); // Обеспечивает простые функциональные возможности для перечисления ресурсов компонента или объекта.
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Encryption = new System.Windows.Forms.Button();
            this.Decryption = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openOrClose = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.bErr = new System.Windows.Forms.Label();
            this.SuspendLayout(); // приостанавливает логику макета, пока все элемнты не построются
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ключ:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(266, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 27);
            this.textBox1.TabIndex = 1;
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.openFile.Location = new System.Drawing.Point(375, 183);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(62, 32);
            this.openFile.TabIndex = 4;
            this.openFile.Text = "обзор";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Encryption
            // 
            this.Encryption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Encryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Encryption.Location = new System.Drawing.Point(33, 272);
            this.Encryption.Name = "Encryption";
            this.Encryption.Size = new System.Drawing.Size(137, 56);
            this.Encryption.TabIndex = 5;
            this.Encryption.Text = "Зашифровать";
            this.Encryption.UseVisualStyleBackColor = false;
            this.Encryption.Click += new System.EventHandler(this.Encryption_Click);
            // 
            // Decryption
            // 
            this.Decryption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Decryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Decryption.Location = new System.Drawing.Point(300, 272);
            this.Decryption.Name = "Decryption";
            this.Decryption.Size = new System.Drawing.Size(137, 56);
            this.Decryption.TabIndex = 6;
            this.Decryption.Text = "Расшифровать";
            this.Decryption.UseVisualStyleBackColor = false;
            this.Decryption.Click += new System.EventHandler(this.Decryption_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выберете текстовый файл";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(199, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // Source
            // 
            this.Source.BackColor = System.Drawing.SystemColors.Window;
            this.Source.Location = new System.Drawing.Point(33, 190);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(336, 20);
            this.Source.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(30, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Путь:";
            // 
            // openOrClose
            // 
            this.openOrClose.AutoSize = true;
            this.openOrClose.Location = new System.Drawing.Point(33, 236);
            this.openOrClose.Name = "openOrClose";
            this.openOrClose.Size = new System.Drawing.Size(181, 17);
            this.openOrClose.TabIndex = 11;
            this.openOrClose.Text = "Открыть файл по завершению";
            this.openOrClose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            // 
            // bErr
            // 
            this.bErr.AutoSize = true;
            this.bErr.ForeColor = System.Drawing.Color.DarkRed;
            this.bErr.Location = new System.Drawing.Point(33, 217);
            this.bErr.Name = "bErr";
            this.bErr.Size = new System.Drawing.Size(0, 13);
            this.bErr.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(462, 356);
            this.Controls.Add(this.bErr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.openOrClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Decryption);
            this.Controls.Add(this.Encryption);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(478, 395);
            this.MinimumSize = new System.Drawing.Size(478, 395);
            this.Name = "Form1";
            this.Text = "DES";
            this.ResumeLayout(false); //Возобновляет обычную логику макета, без выполнения отложенных запросов макета
            this.PerformLayout(); //принудительное применение логики макета ко всем его дочерним элементам управления

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Encryption;
        private System.Windows.Forms.Button Decryption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Source;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox openOrClose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label bErr;
    }
}

