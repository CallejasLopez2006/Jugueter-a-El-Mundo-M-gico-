namespace Juguetería_EL_Mundo_Mágico_
{
    partial class Form1
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
            Productos = new DataGridView();
            Nombretxt = new TextBox();
            PrecioUnitariotxt = new TextBox();
            ExistenciaStocktxt = new TextBox();
            Categoriatxt = new TextBox();
            MarcaIdtxt = new TextBox();
            EdadIdtxt = new TextBox();
            MaterialId = new TextBox();
            EstadoIdtxt = new TextBox();
            GuardarButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)Productos).BeginInit();
            SuspendLayout();
            // 
            // Productos
            // 
            Productos.BackgroundColor = SystemColors.ControlLightLight;
            Productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Productos.Location = new Point(483, 38);
            Productos.Name = "Productos";
            Productos.Size = new Size(315, 279);
            Productos.TabIndex = 0;
            // 
            // Nombretxt
            // 
            Nombretxt.Location = new Point(129, 38);
            Nombretxt.Name = "Nombretxt";
            Nombretxt.Size = new Size(100, 23);
            Nombretxt.TabIndex = 1;
            // 
            // PrecioUnitariotxt
            // 
            PrecioUnitariotxt.Location = new Point(129, 107);
            PrecioUnitariotxt.Name = "PrecioUnitariotxt";
            PrecioUnitariotxt.Size = new Size(100, 23);
            PrecioUnitariotxt.TabIndex = 2;
            // 
            // ExistenciaStocktxt
            // 
            ExistenciaStocktxt.Location = new Point(129, 181);
            ExistenciaStocktxt.Name = "ExistenciaStocktxt";
            ExistenciaStocktxt.Size = new Size(100, 23);
            ExistenciaStocktxt.TabIndex = 3;
            // 
            // Categoriatxt
            // 
            Categoriatxt.Location = new Point(129, 262);
            Categoriatxt.Name = "Categoriatxt";
            Categoriatxt.Size = new Size(100, 23);
            Categoriatxt.TabIndex = 4;
            // 
            // MarcaIdtxt
            // 
            MarcaIdtxt.Location = new Point(361, 38);
            MarcaIdtxt.Name = "MarcaIdtxt";
            MarcaIdtxt.Size = new Size(100, 23);
            MarcaIdtxt.TabIndex = 5;
            // 
            // EdadIdtxt
            // 
            EdadIdtxt.Location = new Point(361, 115);
            EdadIdtxt.Name = "EdadIdtxt";
            EdadIdtxt.Size = new Size(100, 23);
            EdadIdtxt.TabIndex = 6;
            // 
            // MaterialId
            // 
            MaterialId.Location = new Point(361, 181);
            MaterialId.Name = "MaterialId";
            MaterialId.Size = new Size(100, 23);
            MaterialId.TabIndex = 7;
            // 
            // EstadoIdtxt
            // 
            EstadoIdtxt.Location = new Point(361, 262);
            EstadoIdtxt.Name = "EstadoIdtxt";
            EstadoIdtxt.Size = new Size(100, 23);
            EstadoIdtxt.TabIndex = 8;
            // 
            // GuardarButton
            // 
            GuardarButton.Location = new Point(48, 368);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 9;
            GuardarButton.Text = "GUARDAR";
            GuardarButton.Click += GuardarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 41);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 10;
            label1.Text = "NOMBRE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 110);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 11;
            label2.Text = "PRECIO UNITARIO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 184);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 12;
            label3.Text = "STOCK";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 262);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 13;
            label4.Text = "CATEGORIA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(306, 38);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 14;
            label5.Text = "MARCA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(318, 118);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 15;
            label6.Text = "EDAD";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(293, 184);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 16;
            label7.Text = "MATERIAL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(305, 270);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 17;
            label8.Text = "ESTADO";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(810, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GuardarButton);
            Controls.Add(EstadoIdtxt);
            Controls.Add(MaterialId);
            Controls.Add(EdadIdtxt);
            Controls.Add(MarcaIdtxt);
            Controls.Add(Categoriatxt);
            Controls.Add(ExistenciaStocktxt);
            Controls.Add(PrecioUnitariotxt);
            Controls.Add(Nombretxt);
            Controls.Add(Productos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Productos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Productos;
        private TextBox Nombretxt;
        private TextBox PrecioUnitariotxt;
        private TextBox ExistenciaStocktxt;
        private TextBox Categoriatxt;
        private TextBox MarcaIdtxt;
        private TextBox EdadIdtxt;
        private TextBox MaterialId;
        private TextBox EstadoIdtxt;
        private Button GuardarButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
