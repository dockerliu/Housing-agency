namespace Housing_agency.Print
{
    partial class FormPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.skinButtonPrint = new CCWin.SkinControl.SkinButton();
            this.skinButtonPrintPreview = new CCWin.SkinControl.SkinButton();
            this.axGRDisplayViewer1 = new Axgregn6Lib.AxGRDisplayViewer();
            ((System.ComponentModel.ISupportInitialize)(this.axGRDisplayViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinButtonPrint
            // 
            this.skinButtonPrint.BackColor = System.Drawing.Color.Transparent;
            this.skinButtonPrint.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtonPrint.DownBack = null;
            this.skinButtonPrint.Location = new System.Drawing.Point(460, 31);
            this.skinButtonPrint.MouseBack = null;
            this.skinButtonPrint.Name = "skinButtonPrint";
            this.skinButtonPrint.NormlBack = null;
            this.skinButtonPrint.Size = new System.Drawing.Size(75, 23);
            this.skinButtonPrint.TabIndex = 1;
            this.skinButtonPrint.Text = "打  印";
            this.skinButtonPrint.UseVisualStyleBackColor = false;
            this.skinButtonPrint.Click += new System.EventHandler(this.skinButtonPrint_Click);
            // 
            // skinButtonPrintPreview
            // 
            this.skinButtonPrintPreview.BackColor = System.Drawing.Color.Transparent;
            this.skinButtonPrintPreview.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtonPrintPreview.DownBack = null;
            this.skinButtonPrintPreview.Location = new System.Drawing.Point(575, 31);
            this.skinButtonPrintPreview.MouseBack = null;
            this.skinButtonPrintPreview.Name = "skinButtonPrintPreview";
            this.skinButtonPrintPreview.NormlBack = null;
            this.skinButtonPrintPreview.Size = new System.Drawing.Size(75, 23);
            this.skinButtonPrintPreview.TabIndex = 1;
            this.skinButtonPrintPreview.Text = "打印预览";
            this.skinButtonPrintPreview.UseVisualStyleBackColor = false;
            this.skinButtonPrintPreview.Click += new System.EventHandler(this.skinButtonPrintPreview_Click);
            // 
            // axGRDisplayViewer1
            // 
            this.axGRDisplayViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axGRDisplayViewer1.Enabled = true;
            this.axGRDisplayViewer1.Location = new System.Drawing.Point(7, 60);
            this.axGRDisplayViewer1.Name = "axGRDisplayViewer1";
            this.axGRDisplayViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGRDisplayViewer1.OcxState")));
            this.axGRDisplayViewer1.Size = new System.Drawing.Size(786, 383);
            this.axGRDisplayViewer1.TabIndex = 2;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axGRDisplayViewer1);
            this.Controls.Add(this.skinButtonPrintPreview);
            this.Controls.Add(this.skinButtonPrint);
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axGRDisplayViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinButton skinButtonPrint;
        private CCWin.SkinControl.SkinButton skinButtonPrintPreview;
        private Axgregn6Lib.AxGRDisplayViewer axGRDisplayViewer1;
    }
}