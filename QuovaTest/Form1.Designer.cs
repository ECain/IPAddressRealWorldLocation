namespace QuovaExample
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
      this.components = new System.ComponentModel.Container();
      this.btnRouterData = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btnGetIPAddress = new System.Windows.Forms.Button();
      this.lblIP = new System.Windows.Forms.Label();
      this.txtRouterData = new System.Windows.Forms.TextBox();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.btnQuovaLocationData = new System.Windows.Forms.Button();
      this.txtLocationData = new System.Windows.Forms.TextBox();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.btnQuovaBatchData = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnRouterData
      // 
      this.btnRouterData.Location = new System.Drawing.Point(17, 126);
      this.btnRouterData.Name = "btnRouterData";
      this.btnRouterData.Size = new System.Drawing.Size(172, 65);
      this.btnRouterData.TabIndex = 0;
      this.btnRouterData.Text = "Get Router Data:";
      this.btnRouterData.UseVisualStyleBackColor = true;
      this.btnRouterData.Click += new System.EventHandler(this.btnRouterData_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(210, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(169, 26);
      this.label1.TabIndex = 1;
      this.label1.Text = "Public facing IP:";
      // 
      // btnGetIPAddress
      // 
      this.btnGetIPAddress.Location = new System.Drawing.Point(12, 12);
      this.btnGetIPAddress.Name = "btnGetIPAddress";
      this.btnGetIPAddress.Size = new System.Drawing.Size(177, 38);
      this.btnGetIPAddress.TabIndex = 2;
      this.btnGetIPAddress.Text = "Get IP Address";
      this.btnGetIPAddress.UseVisualStyleBackColor = true;
      this.btnGetIPAddress.Click += new System.EventHandler(this.btnGetIPAddress_Click);
      // 
      // lblIP
      // 
      this.lblIP.AutoSize = true;
      this.lblIP.Location = new System.Drawing.Point(414, 19);
      this.lblIP.Name = "lblIP";
      this.lblIP.Size = new System.Drawing.Size(0, 26);
      this.lblIP.TabIndex = 3;
      // 
      // txtRouterData
      // 
      this.txtRouterData.Location = new System.Drawing.Point(15, 204);
      this.txtRouterData.Multiline = true;
      this.txtRouterData.Name = "txtRouterData";
      this.txtRouterData.ReadOnly = true;
      this.txtRouterData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtRouterData.Size = new System.Drawing.Size(462, 164);
      this.txtRouterData.TabIndex = 4;
      // 
      // btnQuovaLocationData
      // 
      this.btnQuovaLocationData.Enabled = false;
      this.btnQuovaLocationData.Location = new System.Drawing.Point(17, 379);
      this.btnQuovaLocationData.Name = "btnQuovaLocationData";
      this.btnQuovaLocationData.Size = new System.Drawing.Size(172, 65);
      this.btnQuovaLocationData.TabIndex = 5;
      this.btnQuovaLocationData.Text = "Get my IP data:";
      this.btnQuovaLocationData.UseVisualStyleBackColor = true;
      this.btnQuovaLocationData.Click += new System.EventHandler(this.btnQuovaLocationData_Click);
      // 
      // txtLocationData
      // 
      this.txtLocationData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.txtLocationData.Location = new System.Drawing.Point(17, 450);
      this.txtLocationData.Multiline = true;
      this.txtLocationData.Name = "txtLocationData";
      this.txtLocationData.ReadOnly = true;
      this.txtLocationData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtLocationData.Size = new System.Drawing.Size(460, 675);
      this.txtLocationData.TabIndex = 6;
      // 
      // webBrowser1
      // 
      this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.webBrowser1.Location = new System.Drawing.Point(524, 206);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(1118, 934);
      this.webBrowser1.TabIndex = 7;
      // 
      // btnQuovaBatchData
      // 
      this.btnQuovaBatchData.Location = new System.Drawing.Point(195, 379);
      this.btnQuovaBatchData.Name = "btnQuovaBatchData";
      this.btnQuovaBatchData.Size = new System.Drawing.Size(172, 65);
      this.btnQuovaBatchData.TabIndex = 8;
      this.btnQuovaBatchData.Text = "Batch request IP data:";
      this.btnQuovaBatchData.UseVisualStyleBackColor = true;
      this.btnQuovaBatchData.Click += new System.EventHandler(this.btnQuovaBatchData_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1653, 1153);
      this.Controls.Add(this.btnQuovaBatchData);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.txtLocationData);
      this.Controls.Add(this.btnQuovaLocationData);
      this.Controls.Add(this.txtRouterData);
      this.Controls.Add(this.lblIP);
      this.Controls.Add(this.btnGetIPAddress);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnRouterData);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnRouterData;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnGetIPAddress;
    private System.Windows.Forms.Label lblIP;
    private System.Windows.Forms.TextBox txtRouterData;
    private System.Windows.Forms.BindingSource bindingSource1;
    private System.Windows.Forms.Button btnQuovaLocationData;
    private System.Windows.Forms.TextBox txtLocationData;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Button btnQuovaBatchData;
  }
}

