namespace WinFullStackTo.Forms
{
    partial class NotesForm
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
            listNote = new ListBox();
            txtNote = new RichTextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnUpdate = new Button();
            label1 = new Label();
            lblUser = new Label();
            txtStock = new TextBox();
            lblText = new Label();
            SuspendLayout();
            // 
            // listNote
            // 
            listNote.FormattingEnabled = true;
            listNote.ItemHeight = 14;
            listNote.Location = new Point(28, 12);
            listNote.Name = "listNote";
            listNote.Size = new Size(286, 354);
            listNote.TabIndex = 0;
            listNote.SelectedIndexChanged += listNote_SelectedIndexChanged;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(329, 29);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(334, 96);
            txtNote.TabIndex = 1;
            txtNote.Text = "";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(329, 187);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(334, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(329, 289);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(334, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Sil";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(329, 239);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(334, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Güncele";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 343);
            label1.Name = "label1";
            label1.Size = new Size(161, 14);
            label1.TabIndex = 3;
            label1.Text = "Giriş Yapan Kullanıcı:";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(504, 343);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(49, 14);
            lblUser.TabIndex = 4;
            lblUser.Text = "label2";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(329, 140);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(325, 22);
            txtStock.TabIndex = 5;
            txtStock.TextChanged += txtStock_TextChanged;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(614, 352);
            lblText.Name = "lblText";
            lblText.Size = new Size(49, 14);
            lblText.TabIndex = 6;
            lblText.Text = "label2";
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 420);
            Controls.Add(lblText);
            Controls.Add(txtStock);
            Controls.Add(lblUser);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(txtNote);
            Controls.Add(listNote);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "NotesForm";
            Text = "NoteForm";
            FormClosed += NotesForm_FormClosed;
            Load += NoteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listNote;
        private RichTextBox txtNote;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnUpdate;
        private Label label1;
        private Label lblUser;
        private TextBox txtStock;
        private Label lblText;
    }
}