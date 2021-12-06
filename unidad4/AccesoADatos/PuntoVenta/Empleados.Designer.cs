
namespace PuntoVenta
{
    partial class Empleados
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
            this.btnAgregarEmp = new System.Windows.Forms.Button();
            this.btnEditarEmp = new System.Windows.Forms.Button();
            this.btnEliminarEmp = new System.Windows.Forms.Button();
            this.DgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarEmp
            // 
            this.btnAgregarEmp.Location = new System.Drawing.Point(27, 48);
            this.btnAgregarEmp.Name = "btnAgregarEmp";
            this.btnAgregarEmp.Size = new System.Drawing.Size(75, 33);
            this.btnAgregarEmp.TabIndex = 0;
            this.btnAgregarEmp.Text = "Agregar";
            this.btnAgregarEmp.UseVisualStyleBackColor = true;
            this.btnAgregarEmp.Click += new System.EventHandler(this.btnAgregarEmp_Click);
            // 
            // btnEditarEmp
            // 
            this.btnEditarEmp.Location = new System.Drawing.Point(131, 47);
            this.btnEditarEmp.Name = "btnEditarEmp";
            this.btnEditarEmp.Size = new System.Drawing.Size(75, 34);
            this.btnEditarEmp.TabIndex = 1;
            this.btnEditarEmp.Text = "Editar";
            this.btnEditarEmp.UseVisualStyleBackColor = true;
            this.btnEditarEmp.Click += new System.EventHandler(this.btnEditarEmp_Click);
            // 
            // btnEliminarEmp
            // 
            this.btnEliminarEmp.Location = new System.Drawing.Point(234, 47);
            this.btnEliminarEmp.Name = "btnEliminarEmp";
            this.btnEliminarEmp.Size = new System.Drawing.Size(75, 33);
            this.btnEliminarEmp.TabIndex = 2;
            this.btnEliminarEmp.Text = "Eliminar";
            this.btnEliminarEmp.UseVisualStyleBackColor = true;
            this.btnEliminarEmp.Click += new System.EventHandler(this.btnEliminarEmp_Click);
            // 
            // DgvEmpleados
            // 
            this.DgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmpleados.Location = new System.Drawing.Point(12, 99);
            this.DgvEmpleados.Name = "DgvEmpleados";
            this.DgvEmpleados.Size = new System.Drawing.Size(673, 339);
            this.DgvEmpleados.TabIndex = 3;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(600, 47);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 33);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.DgvEmpleados);
            this.Controls.Add(this.btnEliminarEmp);
            this.Controls.Add(this.btnEditarEmp);
            this.Controls.Add(this.btnAgregarEmp);
            this.Name = "Empleados";
            this.Text = "Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEmp;
        private System.Windows.Forms.Button btnEditarEmp;
        private System.Windows.Forms.Button btnEliminarEmp;
        private System.Windows.Forms.DataGridView DgvEmpleados;
        private System.Windows.Forms.Button btnVolver;
    }
}