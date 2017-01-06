namespace MyArcGIS
{
    partial class Buffer2
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buffer2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_intput = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.btn_BrowserI = new System.Windows.Forms.Button();
            this.btn_BrowserO = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Buffer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Buffer = new System.Windows.Forms.Button();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_Buffer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_BrowserO);
            this.groupBox1.Controls.Add(this.btn_BrowserI);
            this.groupBox1.Controls.Add(this.tb_output);
            this.groupBox1.Controls.Add(this.tb_intput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "输出：";
            // 
            // tb_intput
            // 
            this.tb_intput.Location = new System.Drawing.Point(72, 21);
            this.tb_intput.Name = "tb_intput";
            this.tb_intput.Size = new System.Drawing.Size(391, 21);
            this.tb_intput.TabIndex = 2;
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(74, 74);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(389, 21);
            this.tb_output.TabIndex = 3;
            // 
            // btn_BrowserI
            // 
            this.btn_BrowserI.Image = ((System.Drawing.Image)(resources.GetObject("btn_BrowserI.Image")));
            this.btn_BrowserI.Location = new System.Drawing.Point(488, 19);
            this.btn_BrowserI.Name = "btn_BrowserI";
            this.btn_BrowserI.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowserI.TabIndex = 4;
            this.btn_BrowserI.UseVisualStyleBackColor = true;
            this.btn_BrowserI.Click += new System.EventHandler(this.btn_BrowserI_Click);
            // 
            // btn_BrowserO
            // 
            this.btn_BrowserO.Image = ((System.Drawing.Image)(resources.GetObject("btn_BrowserO.Image")));
            this.btn_BrowserO.Location = new System.Drawing.Point(488, 71);
            this.btn_BrowserO.Name = "btn_BrowserO";
            this.btn_BrowserO.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowserO.TabIndex = 5;
            this.btn_BrowserO.UseVisualStyleBackColor = true;
            this.btn_BrowserO.Click += new System.EventHandler(this.btn_BrowserO_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "缓冲半径：";
            // 
            // tb_Buffer
            // 
            this.tb_Buffer.Location = new System.Drawing.Point(99, 119);
            this.tb_Buffer.Name = "tb_Buffer";
            this.tb_Buffer.Size = new System.Drawing.Size(309, 21);
            this.tb_Buffer.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "米";
            // 
            // btn_Buffer
            // 
            this.btn_Buffer.Location = new System.Drawing.Point(528, 279);
            this.btn_Buffer.Name = "btn_Buffer";
            this.btn_Buffer.Size = new System.Drawing.Size(75, 23);
            this.btn_Buffer.TabIndex = 1;
            this.btn_Buffer.Text = "缓冲";
            this.btn_Buffer.UseVisualStyleBackColor = true;
            this.btn_Buffer.Click += new System.EventHandler(this.btn_Buffer_Click);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.Location = new System.Drawing.Point(528, 334);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(75, 23);
            this.btn_EXIT.TabIndex = 2;
            this.btn_EXIT.Text = "关闭";
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // Buffer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 446);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_Buffer);
            this.Controls.Add(this.groupBox1);
            this.Name = "Buffer2";
            this.Text = "Buffer2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Buffer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_BrowserO;
        private System.Windows.Forms.Button btn_BrowserI;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TextBox tb_intput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Buffer;
        private System.Windows.Forms.Button btn_EXIT;
    }
}