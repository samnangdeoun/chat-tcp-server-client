namespace ClientChat
{
    partial class ClientForm
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
            this.UsernameTb = new System.Windows.Forms.TextBox();
            this.SendMessageTb = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SendBtn = new System.Windows.Forms.Button();
            this.DisplayChat = new System.Windows.Forms.TextBox();
            this.UsersLb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UsernameTb
            // 
            this.UsernameTb.Location = new System.Drawing.Point(12, 12);
            this.UsernameTb.Name = "UsernameTb";
            this.UsernameTb.Size = new System.Drawing.Size(432, 22);
            this.UsernameTb.TabIndex = 0;
            // 
            // SendMessageTb
            // 
            this.SendMessageTb.Location = new System.Drawing.Point(12, 416);
            this.SendMessageTb.Name = "SendMessageTb";
            this.SendMessageTb.Size = new System.Drawing.Size(432, 22);
            this.SendMessageTb.TabIndex = 1;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(450, 12);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(131, 37);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect To Server";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(466, 400);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(115, 38);
            this.SendBtn.TabIndex = 3;
            this.SendBtn.Text = "Send Message";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // DisplayChat
            // 
            this.DisplayChat.Location = new System.Drawing.Point(12, 55);
            this.DisplayChat.Multiline = true;
            this.DisplayChat.Name = "DisplayChat";
            this.DisplayChat.Size = new System.Drawing.Size(569, 339);
            this.DisplayChat.TabIndex = 4;
            // 
            // UsersLb
            // 
            this.UsersLb.FormattingEnabled = true;
            this.UsersLb.ItemHeight = 16;
            this.UsersLb.Location = new System.Drawing.Point(651, 68);
            this.UsersLb.Name = "UsersLb";
            this.UsersLb.Size = new System.Drawing.Size(120, 196);
            this.UsersLb.TabIndex = 5;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.UsersLb);
            this.Controls.Add(this.DisplayChat);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.SendMessageTb);
            this.Controls.Add(this.UsernameTb);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTb;
        private System.Windows.Forms.TextBox SendMessageTb;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox DisplayChat;
        private System.Windows.Forms.ListBox UsersLb;
    }
}

