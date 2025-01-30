namespace ComercialSys
{
    partial class FrmConsultarPedido
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
            dgvConsultar = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            usuario_id = new DataGridViewTextBoxColumn();
            cliente_id = new DataGridViewTextBoxColumn();
            data = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            desconto = new DataGridViewTextBoxColumn();
            valorPedido = new DataGridViewTextBoxColumn();
            lblFiltrar = new Label();
            txtInfo = new TextBox();
            BtnBuscar = new Button();
            btnID = new RadioButton();
            btnCPF = new RadioButton();
            btnstatus = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvConsultar).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultar
            // 
            dgvConsultar.AllowUserToAddRows = false;
            dgvConsultar.AllowUserToDeleteRows = false;
            dgvConsultar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultar.Columns.AddRange(new DataGridViewColumn[] { Id, usuario_id, cliente_id, data, status, desconto, valorPedido });
            dgvConsultar.Location = new Point(12, 12);
            dgvConsultar.Name = "dgvConsultar";
            dgvConsultar.ReadOnly = true;
            dgvConsultar.RowHeadersVisible = false;
            dgvConsultar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultar.Size = new Size(654, 426);
            dgvConsultar.TabIndex = 9;
            // 
            // Id
            // 
            Id.Frozen = true;
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 50;
            // 
            // usuario_id
            // 
            usuario_id.Frozen = true;
            usuario_id.HeaderText = "Usuario_id";
            usuario_id.Name = "usuario_id";
            usuario_id.ReadOnly = true;
            // 
            // cliente_id
            // 
            cliente_id.Frozen = true;
            cliente_id.HeaderText = "Cliente_id";
            cliente_id.Name = "cliente_id";
            cliente_id.ReadOnly = true;
            // 
            // data
            // 
            data.Frozen = true;
            data.HeaderText = "Data";
            data.Name = "data";
            data.ReadOnly = true;
            // 
            // status
            // 
            status.Frozen = true;
            status.HeaderText = "Status";
            status.Name = "status";
            status.ReadOnly = true;
            // 
            // desconto
            // 
            desconto.Frozen = true;
            desconto.HeaderText = "Desconto";
            desconto.Name = "desconto";
            desconto.ReadOnly = true;
            // 
            // valorPedido
            // 
            valorPedido.Frozen = true;
            valorPedido.HeaderText = "Valor_Pedido";
            valorPedido.Name = "valorPedido";
            valorPedido.ReadOnly = true;
            // 
            // lblFiltrar
            // 
            lblFiltrar.AutoSize = true;
            lblFiltrar.Location = new Point(672, 42);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(61, 15);
            lblFiltrar.TabIndex = 11;
            lblFiltrar.Text = "Filtrar por:";
            lblFiltrar.Click += label1_Click;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(672, 387);
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(123, 23);
            txtInfo.TabIndex = 12;
            txtInfo.Visible = false;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Location = new Point(692, 416);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(75, 23);
            BtnBuscar.TabIndex = 13;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Visible = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // btnID
            // 
            btnID.AutoSize = true;
            btnID.Location = new Point(673, 60);
            btnID.Name = "btnID";
            btnID.Size = new Size(36, 19);
            btnID.TabIndex = 14;
            btnID.TabStop = true;
            btnID.Text = "ID";
            btnID.UseVisualStyleBackColor = true;
            btnID.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // btnCPF
            // 
            btnCPF.AutoSize = true;
            btnCPF.Location = new Point(672, 85);
            btnCPF.Name = "btnCPF";
            btnCPF.Size = new Size(46, 19);
            btnCPF.TabIndex = 14;
            btnCPF.TabStop = true;
            btnCPF.Text = "CPF";
            btnCPF.UseVisualStyleBackColor = true;
            btnCPF.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // btnstatus
            // 
            btnstatus.AutoSize = true;
            btnstatus.Location = new Point(672, 110);
            btnstatus.Name = "btnstatus";
            btnstatus.Size = new Size(63, 19);
            btnstatus.TabIndex = 14;
            btnstatus.TabStop = true;
            btnstatus.Text = "STATUS";
            btnstatus.UseVisualStyleBackColor = true;
            btnstatus.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // FrmConsultarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnstatus);
            Controls.Add(btnCPF);
            Controls.Add(btnID);
            Controls.Add(BtnBuscar);
            Controls.Add(txtInfo);
            Controls.Add(lblFiltrar);
            Controls.Add(dgvConsultar);
            Name = "FrmConsultarPedido";
            Text = "FrmComsultarPedido";
            Load += FrmConsultarPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsultar;
        private CheckBox chkcpf;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn usuario_id;
        private DataGridViewTextBoxColumn cliente_id;
        private DataGridViewTextBoxColumn data;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn desconto;
        private DataGridViewTextBoxColumn valorPedido;
        private Label lblFiltrar;
        private CheckBox chkid;
        private CheckBox chkstatus;
        private TextBox txtInfo;
        private Button BtnBuscar;
        private RadioButton btnID;
        private RadioButton btnCPF;
        private RadioButton btnstatus;
    }
}