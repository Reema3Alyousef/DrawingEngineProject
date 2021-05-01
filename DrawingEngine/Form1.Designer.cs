
namespace DrawingEngine
{
    partial class drawingEngine
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightTab = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.penStyle = new System.Windows.Forms.GroupBox();
            this.sizePicker = new System.Windows.Forms.NumericUpDown();
            this.colorButton = new System.Windows.Forms.Button();
            this.size = new System.Windows.Forms.Label();
            this.notDashedButton = new System.Windows.Forms.Button();
            this.dashedButton = new System.Windows.Forms.Button();
            this.Tools = new System.Windows.Forms.GroupBox();
            this.handButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.Shapes = new System.Windows.Forms.GroupBox();
            this.CircleButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabs = new System.Windows.Forms.TabControl();
            this.designTab = new System.Windows.Forms.TabPage();
            this.designPanel = new System.Windows.Forms.Panel();
            this.sourceTab = new System.Windows.Forms.TabPage();
            this.sourceTextbox = new System.Windows.Forms.RichTextBox();
            this.clear_Button = new System.Windows.Forms.Button();
            this.rightTab.SuspendLayout();
            this.penStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizePicker)).BeginInit();
            this.Tools.SuspendLayout();
            this.Shapes.SuspendLayout();
            this.tabs.SuspendLayout();
            this.designTab.SuspendLayout();
            this.sourceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightTab
            // 
            this.rightTab.Controls.Add(this.saveButton);
            this.rightTab.Controls.Add(this.openButton);
            this.rightTab.Controls.Add(this.penStyle);
            this.rightTab.Controls.Add(this.Tools);
            this.rightTab.Controls.Add(this.Shapes);
            this.rightTab.Location = new System.Drawing.Point(982, 23);
            this.rightTab.Margin = new System.Windows.Forms.Padding(2);
            this.rightTab.Name = "rightTab";
            this.rightTab.Size = new System.Drawing.Size(252, 681);
            this.rightTab.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.saveButton.Location = new System.Drawing.Point(132, 51);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 45);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.openButton.Location = new System.Drawing.Point(20, 51);
            this.openButton.Margin = new System.Windows.Forms.Padding(2);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(99, 45);
            this.openButton.TabIndex = 12;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // penStyle
            // 
            this.penStyle.Controls.Add(this.sizePicker);
            this.penStyle.Controls.Add(this.colorButton);
            this.penStyle.Controls.Add(this.size);
            this.penStyle.Controls.Add(this.notDashedButton);
            this.penStyle.Controls.Add(this.dashedButton);
            this.penStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.penStyle.Location = new System.Drawing.Point(20, 434);
            this.penStyle.Margin = new System.Windows.Forms.Padding(2);
            this.penStyle.Name = "penStyle";
            this.penStyle.Padding = new System.Windows.Forms.Padding(2);
            this.penStyle.Size = new System.Drawing.Size(212, 190);
            this.penStyle.TabIndex = 12;
            this.penStyle.TabStop = false;
            this.penStyle.Text = "Pen Style";
            // 
            // sizePicker
            // 
            this.sizePicker.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sizePicker.Location = new System.Drawing.Point(140, 65);
            this.sizePicker.Margin = new System.Windows.Forms.Padding(2);
            this.sizePicker.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.sizePicker.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sizePicker.Name = "sizePicker";
            this.sizePicker.Size = new System.Drawing.Size(52, 36);
            this.sizePicker.TabIndex = 0;
            this.sizePicker.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sizePicker.ValueChanged += new System.EventHandler(this.sizePicker_ValueChanged);
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.colorButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorButton.Location = new System.Drawing.Point(49, 120);
            this.colorButton.Margin = new System.Windows.Forms.Padding(2);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(122, 45);
            this.colorButton.TabIndex = 12;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.size.Location = new System.Drawing.Point(134, 39);
            this.size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(38, 21);
            this.size.TabIndex = 0;
            this.size.Text = "Size";
            // 
            // notDashedButton
            // 
            this.notDashedButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.notDashedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.notDashedButton.Location = new System.Drawing.Point(79, 62);
            this.notDashedButton.Margin = new System.Windows.Forms.Padding(2);
            this.notDashedButton.Name = "notDashedButton";
            this.notDashedButton.Size = new System.Drawing.Size(50, 45);
            this.notDashedButton.TabIndex = 6;
            this.notDashedButton.Text = "━━";
            this.notDashedButton.UseVisualStyleBackColor = false;
            this.notDashedButton.Click += new System.EventHandler(this.notDashedButton_Click);
            // 
            // dashedButton
            // 
            this.dashedButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dashedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dashedButton.Location = new System.Drawing.Point(20, 62);
            this.dashedButton.Margin = new System.Windows.Forms.Padding(2);
            this.dashedButton.Name = "dashedButton";
            this.dashedButton.Size = new System.Drawing.Size(50, 45);
            this.dashedButton.TabIndex = 5;
            this.dashedButton.Text = "---";
            this.dashedButton.UseVisualStyleBackColor = false;
            this.dashedButton.Click += new System.EventHandler(this.dashedButton_Click);
            // 
            // Tools
            // 
            this.Tools.Controls.Add(this.clear_Button);
            this.Tools.Controls.Add(this.handButton);
            this.Tools.Controls.Add(this.drawButton);
            this.Tools.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Tools.Location = new System.Drawing.Point(20, 278);
            this.Tools.Margin = new System.Windows.Forms.Padding(2);
            this.Tools.Name = "Tools";
            this.Tools.Padding = new System.Windows.Forms.Padding(2);
            this.Tools.Size = new System.Drawing.Size(212, 136);
            this.Tools.TabIndex = 11;
            this.Tools.TabStop = false;
            this.Tools.Text = "Tools";
            // 
            // handButton
            // 
            this.handButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.handButton.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handButton.Location = new System.Drawing.Point(25, 53);
            this.handButton.Margin = new System.Windows.Forms.Padding(2);
            this.handButton.Name = "handButton";
            this.handButton.Size = new System.Drawing.Size(50, 45);
            this.handButton.TabIndex = 5;
            this.handButton.Text = "✋";
            this.handButton.UseVisualStyleBackColor = false;
            this.handButton.Click += new System.EventHandler(this.handButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.drawButton.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.drawButton.Location = new System.Drawing.Point(86, 53);
            this.drawButton.Margin = new System.Windows.Forms.Padding(2);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(50, 45);
            this.drawButton.TabIndex = 6;
            this.drawButton.Text = "✎";
            this.drawButton.UseVisualStyleBackColor = false;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // Shapes
            // 
            this.Shapes.Controls.Add(this.CircleButton);
            this.Shapes.Controls.Add(this.RectangleButton);
            this.Shapes.Controls.Add(this.lineButton);
            this.Shapes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Shapes.Location = new System.Drawing.Point(20, 126);
            this.Shapes.Margin = new System.Windows.Forms.Padding(2);
            this.Shapes.Name = "Shapes";
            this.Shapes.Padding = new System.Windows.Forms.Padding(2);
            this.Shapes.Size = new System.Drawing.Size(212, 136);
            this.Shapes.TabIndex = 10;
            this.Shapes.TabStop = false;
            this.Shapes.Text = "Shape";
            // 
            // CircleButton
            // 
            this.CircleButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CircleButton.Location = new System.Drawing.Point(20, 53);
            this.CircleButton.Margin = new System.Windows.Forms.Padding(2);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(50, 45);
            this.CircleButton.TabIndex = 7;
            this.CircleButton.Text = "○";
            this.CircleButton.UseVisualStyleBackColor = false;
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RectangleButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RectangleButton.Location = new System.Drawing.Point(142, 53);
            this.RectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(50, 45);
            this.RectangleButton.TabIndex = 9;
            this.RectangleButton.Text = "▭";
            this.RectangleButton.UseVisualStyleBackColor = false;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lineButton.Location = new System.Drawing.Point(82, 53);
            this.lineButton.Margin = new System.Windows.Forms.Padding(2);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(50, 45);
            this.lineButton.TabIndex = 8;
            this.lineButton.Text = "╱";
            this.lineButton.UseVisualStyleBackColor = false;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabs.Controls.Add(this.designTab);
            this.tabs.Controls.Add(this.sourceTab);
            this.tabs.Location = new System.Drawing.Point(24, 23);
            this.tabs.Margin = new System.Windows.Forms.Padding(2);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(953, 681);
            this.tabs.TabIndex = 0;
            // 
            // designTab
            // 
            this.designTab.Controls.Add(this.designPanel);
            this.designTab.Location = new System.Drawing.Point(4, 4);
            this.designTab.Margin = new System.Windows.Forms.Padding(2);
            this.designTab.Name = "designTab";
            this.designTab.Padding = new System.Windows.Forms.Padding(2);
            this.designTab.Size = new System.Drawing.Size(945, 643);
            this.designTab.TabIndex = 0;
            this.designTab.Text = "Design";
            this.designTab.UseVisualStyleBackColor = true;
            // 
            // designPanel
            // 
            this.designPanel.Location = new System.Drawing.Point(2, 2);
            this.designPanel.Margin = new System.Windows.Forms.Padding(2);
            this.designPanel.Name = "designPanel";
            this.designPanel.Size = new System.Drawing.Size(938, 634);
            this.designPanel.TabIndex = 0;
            this.designPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.designPanel_Paint);
            this.designPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.designPanel_MouseClick);
            this.designPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.designPanel_MouseDown);
            this.designPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.designPanel_MouseMove);
            this.designPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.designPanel_MouseUp);
            // 
            // sourceTab
            // 
            this.sourceTab.Controls.Add(this.sourceTextbox);
            this.sourceTab.Location = new System.Drawing.Point(4, 4);
            this.sourceTab.Margin = new System.Windows.Forms.Padding(2);
            this.sourceTab.Name = "sourceTab";
            this.sourceTab.Padding = new System.Windows.Forms.Padding(2);
            this.sourceTab.Size = new System.Drawing.Size(945, 643);
            this.sourceTab.TabIndex = 1;
            this.sourceTab.Text = "Source";
            this.sourceTab.UseVisualStyleBackColor = true;
            // 
            // sourceTextbox
            // 
            this.sourceTextbox.Location = new System.Drawing.Point(0, 2);
            this.sourceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.sourceTextbox.Name = "sourceTextbox";
            this.sourceTextbox.Size = new System.Drawing.Size(948, 638);
            this.sourceTextbox.TabIndex = 0;
            this.sourceTextbox.Text = "";
            this.sourceTextbox.TextChanged += new System.EventHandler(this.sourceTextbox_TextChanged);
            this.sourceTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sourceTextbox_KeyDown);
            // 
            // clear_Button
            // 
            this.clear_Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clear_Button.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clear_Button.Location = new System.Drawing.Point(149, 53);
            this.clear_Button.Margin = new System.Windows.Forms.Padding(2);
            this.clear_Button.Name = "clear_Button";
            this.clear_Button.Size = new System.Drawing.Size(50, 45);
            this.clear_Button.TabIndex = 7;
            this.clear_Button.Text = "🗑️";
            this.clear_Button.UseVisualStyleBackColor = false;
            this.clear_Button.Click += new System.EventHandler(this.clear_Button_Click);
            // 
            // drawingEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DrawingEngine.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 730);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.rightTab);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "drawingEngine";
            this.Text = "Drawing Engine";
            this.rightTab.ResumeLayout(false);
            this.penStyle.ResumeLayout(false);
            this.penStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizePicker)).EndInit();
            this.Tools.ResumeLayout(false);
            this.Shapes.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.designTab.ResumeLayout(false);
            this.sourceTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel rightTab;
        private System.Windows.Forms.GroupBox Shapes;
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button handButton;
        private System.Windows.Forms.GroupBox penStyle;
        private System.Windows.Forms.Button notDashedButton;
        private System.Windows.Forms.Button dashedButton;
        private System.Windows.Forms.GroupBox Tools;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage designTab;
        private System.Windows.Forms.TabPage sourceTab;
        private System.Windows.Forms.NumericUpDown sizePicker;
        private System.Windows.Forms.Panel designPanel;
        private System.Windows.Forms.RichTextBox sourceTextbox;
        private System.Windows.Forms.Button clear_Button;
    }
}

