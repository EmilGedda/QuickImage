using QuickImage.Components;

namespace QuickImage.Views
{
	sealed partial class MainView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
			this.imageBox = new System.Windows.Forms.GroupBox();
			this.imageView = new QuickImage.Components.CustomListView();
			this.thumbList = new System.Windows.Forms.ImageList(this.components);
			this.optionsBox = new System.Windows.Forms.GroupBox();
			this.deleteButton = new System.Windows.Forms.CheckBox();
			this.linkButton = new System.Windows.Forms.Button();
			this.descriptionsBox = new System.Windows.Forms.RichTextBox();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.separatorLabel = new System.Windows.Forms.Label();
			this.optionsButton = new System.Windows.Forms.Button();
			this.linkBox = new System.Windows.Forms.TextBox();
			this.linkLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageBox.SuspendLayout();
			this.optionsBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageBox
			// 
			this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageBox.Controls.Add(this.imageView);
			this.imageBox.Location = new System.Drawing.Point(12, 12);
			this.imageBox.Name = "imageBox";
			this.imageBox.Size = new System.Drawing.Size(231, 214);
			this.imageBox.TabIndex = 0;
			this.imageBox.TabStop = false;
			this.imageBox.Text = "Images";
			// 
			// imageView
			// 
			this.imageView.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.imageView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageView.LargeImageList = this.thumbList;
			this.imageView.Location = new System.Drawing.Point(3, 16);
			this.imageView.Margin = new System.Windows.Forms.Padding(0);
			this.imageView.Name = "imageView";
			this.imageView.OwnerDraw = true;
			this.imageView.Size = new System.Drawing.Size(225, 195);
			this.imageView.SmallImageList = this.thumbList;
			this.imageView.TabIndex = 0;
			this.imageView.UseCompatibleStateImageBehavior = false;
			this.imageView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.imageView_ItemSelectionChanged);
			this.imageView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageView_KeyDown);
			// 
			// thumbList
			// 
			this.thumbList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.thumbList.ImageSize = new System.Drawing.Size(200, 112);
			this.thumbList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// optionsBox
			// 
			this.optionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsBox.Controls.Add(this.deleteButton);
			this.optionsBox.Controls.Add(this.linkButton);
			this.optionsBox.Controls.Add(this.descriptionsBox);
			this.optionsBox.Controls.Add(this.descriptionLabel);
			this.optionsBox.Controls.Add(this.separatorLabel);
			this.optionsBox.Controls.Add(this.optionsButton);
			this.optionsBox.Controls.Add(this.linkBox);
			this.optionsBox.Controls.Add(this.linkLabel);
			this.optionsBox.Location = new System.Drawing.Point(248, 12);
			this.optionsBox.Name = "optionsBox";
			this.optionsBox.Size = new System.Drawing.Size(198, 214);
			this.optionsBox.TabIndex = 1;
			this.optionsBox.TabStop = false;
			this.optionsBox.Text = "Options";
			// 
			// deleteButton
			// 
			this.deleteButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.deleteButton.Location = new System.Drawing.Point(75, 62);
			this.deleteButton.Margin = new System.Windows.Forms.Padding(1);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(51, 23);
			this.deleteButton.TabIndex = 1;
			this.deleteButton.Text = "Overlay";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// linkButton
			// 
			this.linkButton.Location = new System.Drawing.Point(11, 62);
			this.linkButton.Name = "linkButton";
			this.linkButton.Size = new System.Drawing.Size(62, 23);
			this.linkButton.TabIndex = 8;
			this.linkButton.Text = "Copy Link";
			this.linkButton.UseVisualStyleBackColor = true;
			this.linkButton.Click += new System.EventHandler(this.linkButton_Click);
			// 
			// descriptionsBox
			// 
			this.descriptionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionsBox.Location = new System.Drawing.Point(11, 113);
			this.descriptionsBox.Name = "descriptionsBox";
			this.descriptionsBox.Size = new System.Drawing.Size(181, 95);
			this.descriptionsBox.TabIndex = 7;
			this.descriptionsBox.Text = "";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new System.Drawing.Point(8, 97);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
			this.descriptionLabel.TabIndex = 6;
			this.descriptionLabel.Text = "Description:";
			// 
			// separatorLabel
			// 
			this.separatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.separatorLabel.Location = new System.Drawing.Point(11, 90);
			this.separatorLabel.Name = "separatorLabel";
			this.separatorLabel.Size = new System.Drawing.Size(181, 2);
			this.separatorLabel.TabIndex = 5;
			// 
			// optionsButton
			// 
			this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsButton.Image = global::QuickImage.Properties.Resources.cog;
			this.optionsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.optionsButton.Location = new System.Drawing.Point(127, 62);
			this.optionsButton.Name = "optionsButton";
			this.optionsButton.Size = new System.Drawing.Size(65, 23);
			this.optionsButton.TabIndex = 4;
			this.optionsButton.Text = "Settings";
			this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optionsButton.UseVisualStyleBackColor = true;
			this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
			// 
			// linkBox
			// 
			this.linkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkBox.Location = new System.Drawing.Point(11, 36);
			this.linkBox.Name = "linkBox";
			this.linkBox.Size = new System.Drawing.Size(181, 20);
			this.linkBox.TabIndex = 1;
			// 
			// linkLabel
			// 
			this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel.AutoSize = true;
			this.linkLabel.Location = new System.Drawing.Point(8, 20);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(30, 13);
			this.linkLabel.TabIndex = 0;
			this.linkLabel.Text = "Link:";
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(15, 230);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(60, 13);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Status: Idle";
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(457, 250);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.optionsBox);
			this.Controls.Add(this.imageBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QuickImage - v";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.imageBox.ResumeLayout(false);
			this.optionsBox.ResumeLayout(false);
			this.optionsBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox imageBox;
        private CustomListView imageView;
        private System.Windows.Forms.GroupBox optionsBox;
		private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.RichTextBox descriptionsBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ImageList thumbList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button linkButton;
		private System.Windows.Forms.CheckBox deleteButton;
    }
}

