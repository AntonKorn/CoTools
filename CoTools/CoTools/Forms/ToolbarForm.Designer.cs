namespace CoTools.Forms
{
    partial class ToolbarForm
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
            _toolbarService.LocationChanged -= OnLocationChanged;
            _toolbarService.BecameVisible -= OnBecameVisible;

            _toolbarService.Dispose();
            _dependencyInjectionContext.Dispose();

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
            this.flpWrapper = new System.Windows.Forms.FlowLayoutPanel();
            this.flpToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPositionManagement = new System.Windows.Forms.Panel();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.flpWrapper.SuspendLayout();
            this.pnlPositionManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpWrapper
            // 
            this.flpWrapper.AutoSize = true;
            this.flpWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpWrapper.Controls.Add(this.flpToolbox);
            this.flpWrapper.Controls.Add(this.pnlPositionManagement);
            this.flpWrapper.Location = new System.Drawing.Point(12, 12);
            this.flpWrapper.MinimumSize = new System.Drawing.Size(10, 70);
            this.flpWrapper.Name = "flpWrapper";
            this.flpWrapper.Size = new System.Drawing.Size(109, 71);
            this.flpWrapper.TabIndex = 0;
            this.flpWrapper.WrapContents = false;
            // 
            // flpToolbox
            // 
            this.flpToolbox.AutoSize = true;
            this.flpToolbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpToolbox.Location = new System.Drawing.Point(3, 3);
            this.flpToolbox.MinimumSize = new System.Drawing.Size(1, 65);
            this.flpToolbox.Name = "flpToolbox";
            this.flpToolbox.Size = new System.Drawing.Size(1, 65);
            this.flpToolbox.TabIndex = 0;
            // 
            // pnlPositionManagement
            // 
            this.pnlPositionManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlPositionManagement.Controls.Add(this.btnCollapse);
            this.pnlPositionManagement.Location = new System.Drawing.Point(10, 3);
            this.pnlPositionManagement.Name = "pnlPositionManagement";
            this.pnlPositionManagement.Size = new System.Drawing.Size(96, 65);
            this.pnlPositionManagement.TabIndex = 1;
            this.pnlPositionManagement.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPositionManagement_MouseDown);
            this.pnlPositionManagement.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPositionManagement_MouseMove);
            this.pnlPositionManagement.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlPositionManagement_MouseUp);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCollapse.Location = new System.Drawing.Point(3, 3);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(37, 59);
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // ToolbarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(237, 91);
            this.ControlBox = false;
            this.Controls.Add(this.flpWrapper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolbarForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolbarForm";
            this.TopMost = true;
            this.flpWrapper.ResumeLayout(false);
            this.flpWrapper.PerformLayout();
            this.pnlPositionManagement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flpWrapper;
        private FlowLayoutPanel flpToolbox;
        private Panel pnlPositionManagement;
        private Button btnCollapse;
    }
}