namespace FridaSharp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHook = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendTextMsg = new System.Windows.Forms.Button();
            this.btnSearchWxInfo = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtV3 = new System.Windows.Forms.TextBox();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtWxId = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(146, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 21);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Script:";
            // 
            // btnHook
            // 
            this.btnHook.Location = new System.Drawing.Point(65, 13);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(75, 21);
            this.btnHook.TabIndex = 5;
            this.btnHook.Text = "Hook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(12, 40);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(234, 431);
            this.txtScript.TabIndex = 6;
            this.txtScript.Text = resources.GetString("txtScript.Text");
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(281, 12);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(551, 459);
            this.txtLog.TabIndex = 8;
            this.txtLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Log:";
            // 
            // btnSendTextMsg
            // 
            this.btnSendTextMsg.Location = new System.Drawing.Point(862, 11);
            this.btnSendTextMsg.Name = "btnSendTextMsg";
            this.btnSendTextMsg.Size = new System.Drawing.Size(131, 21);
            this.btnSendTextMsg.TabIndex = 9;
            this.btnSendTextMsg.Text = "SendTextMsg";
            this.btnSendTextMsg.UseVisualStyleBackColor = true;
            this.btnSendTextMsg.Click += new System.EventHandler(this.btnSendTextMsg_Click);
            // 
            // btnSearchWxInfo
            // 
            this.btnSearchWxInfo.Location = new System.Drawing.Point(862, 121);
            this.btnSearchWxInfo.Name = "btnSearchWxInfo";
            this.btnSearchWxInfo.Size = new System.Drawing.Size(131, 21);
            this.btnSearchWxInfo.TabIndex = 10;
            this.btnSearchWxInfo.Text = "SearchWxInfo";
            this.btnSearchWxInfo.UseVisualStyleBackColor = true;
            this.btnSearchWxInfo.Click += new System.EventHandler(this.btnSearchWxInfo_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(862, 148);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(131, 21);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.Text = "ss367263";
            // 
            // txtV3
            // 
            this.txtV3.Location = new System.Drawing.Point(862, 266);
            this.txtV3.Name = "txtV3";
            this.txtV3.Size = new System.Drawing.Size(131, 21);
            this.txtV3.TabIndex = 13;
            this.txtV3.Text = resources.GetString("txtV3.Text");
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Location = new System.Drawing.Point(862, 210);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(131, 21);
            this.btnAddFriend.TabIndex = 12;
            this.btnAddFriend.Text = "AddFriend";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(862, 239);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(131, 21);
            this.txtDesc.TabIndex = 14;
            this.txtDesc.Text = "......";
            // 
            // txtWxId
            // 
            this.txtWxId.Location = new System.Drawing.Point(862, 38);
            this.txtWxId.Name = "txtWxId";
            this.txtWxId.Size = new System.Drawing.Size(131, 21);
            this.txtWxId.TabIndex = 16;
            this.txtWxId.Text = "filehelper";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(862, 65);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(131, 21);
            this.txtMsg.TabIndex = 15;
            this.txtMsg.Text = "testestst";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 483);
            this.Controls.Add(this.txtWxId);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtV3);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSearchWxInfo);
            this.Controls.Add(this.btnSendTextMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FridaSharpWeChatHook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendTextMsg;
        private System.Windows.Forms.Button btnSearchWxInfo;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtV3;
        private System.Windows.Forms.Button btnAddFriend;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtWxId;
        private System.Windows.Forms.TextBox txtMsg;
    }
}

