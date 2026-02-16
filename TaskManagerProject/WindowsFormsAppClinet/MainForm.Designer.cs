namespace WindowsFormsAppClinet
{
    partial class MainForm
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
            this.btnCreateReq = new System.Windows.Forms.Button();
            this.btnStatusReq = new System.Windows.Forms.Button();
            this.btnListReq = new System.Windows.Forms.Button();
            this.btnEditReq = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEditUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateReq
            // 
            this.btnCreateReq.Location = new System.Drawing.Point(13, 14);
            this.btnCreateReq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateReq.Name = "btnCreateReq";
            this.btnCreateReq.Size = new System.Drawing.Size(393, 35);
            this.btnCreateReq.TabIndex = 0;
            this.btnCreateReq.Text = "Создать запрос";
            this.btnCreateReq.UseVisualStyleBackColor = true;
            // 
            // btnStatusReq
            // 
            this.btnStatusReq.Location = new System.Drawing.Point(13, 59);
            this.btnStatusReq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStatusReq.Name = "btnStatusReq";
            this.btnStatusReq.Size = new System.Drawing.Size(393, 35);
            this.btnStatusReq.TabIndex = 1;
            this.btnStatusReq.Text = "Статус запроса";
            this.btnStatusReq.UseVisualStyleBackColor = true;
            // 
            // btnListReq
            // 
            this.btnListReq.Location = new System.Drawing.Point(13, 104);
            this.btnListReq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnListReq.Name = "btnListReq";
            this.btnListReq.Size = new System.Drawing.Size(393, 35);
            this.btnListReq.TabIndex = 2;
            this.btnListReq.Text = "Список запросов";
            this.btnListReq.UseVisualStyleBackColor = true;
            // 
            // btnEditReq
            // 
            this.btnEditReq.Location = new System.Drawing.Point(13, 149);
            this.btnEditReq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditReq.Name = "btnEditReq";
            this.btnEditReq.Size = new System.Drawing.Size(393, 35);
            this.btnEditReq.TabIndex = 3;
            this.btnEditReq.Text = "Редактирование запроса";
            this.btnEditReq.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 365);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(393, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnEditUsers
            // 
            this.btnEditUsers.Location = new System.Drawing.Point(13, 194);
            this.btnEditUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditUsers.Name = "btnEditUsers";
            this.btnEditUsers.Size = new System.Drawing.Size(393, 35);
            this.btnEditUsers.TabIndex = 4;
            this.btnEditUsers.Text = "Редактирование пользователей";
            this.btnEditUsers.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 414);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEditUsers);
            this.Controls.Add(this.btnEditReq);
            this.Controls.Add(this.btnListReq);
            this.Controls.Add(this.btnStatusReq);
            this.Controls.Add(this.btnCreateReq);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateReq;
        private System.Windows.Forms.Button btnStatusReq;
        private System.Windows.Forms.Button btnListReq;
        private System.Windows.Forms.Button btnEditReq;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEditUsers;
    }
}