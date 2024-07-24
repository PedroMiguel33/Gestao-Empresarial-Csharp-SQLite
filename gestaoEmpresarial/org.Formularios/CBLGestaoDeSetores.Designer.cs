namespace gestaoEmpresarial.org.Formularios
{
    partial class CBLGestaoDeSetores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_turmas = new System.Windows.Forms.DataGridView();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_fechar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_imprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_salvar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_novo = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nomeSetor = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_vagas = new System.Windows.Forms.TextBox();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.cb_horario = new System.Windows.Forms.ComboBox();
            this.n_maxEmpregados = new System.Windows.Forms.NumericUpDown();
            this.cb_superiorSetor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_maxEmpregados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_turmas
            // 
            this.dgv_turmas.AllowUserToAddRows = false;
            this.dgv_turmas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_turmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_turmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turmas.EnableHeadersVisualStyles = false;
            this.dgv_turmas.Location = new System.Drawing.Point(12, 12);
            this.dgv_turmas.MultiSelect = false;
            this.dgv_turmas.Name = "dgv_turmas";
            this.dgv_turmas.ReadOnly = true;
            this.dgv_turmas.RowHeadersVisible = false;
            this.dgv_turmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turmas.Size = new System.Drawing.Size(434, 399);
            this.dgv_turmas.TabIndex = 4;
            this.dgv_turmas.SelectionChanged += new System.EventHandler(this.dgv_turmas_SelectionChanged);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 700;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.9D;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Gray;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.btn_fechar);
            this.panel2.Controls.Add(this.btn_imprimir);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_salvar);
            this.panel2.Controls.Add(this.btn_novo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 35);
            this.panel2.TabIndex = 36;
            // 
            // btn_fechar
            // 
            this.btn_fechar.Animated = true;
            this.btn_fechar.BorderColor = System.Drawing.Color.Gray;
            this.btn_fechar.BorderRadius = 2;
            this.btn_fechar.BorderThickness = 1;
            this.btn_fechar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_fechar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_fechar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_fechar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_fechar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_fechar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_fechar.ForeColor = System.Drawing.Color.White;
            this.btn_fechar.Location = new System.Drawing.Point(632, 3);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(146, 28);
            this.btn_fechar.TabIndex = 48;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Animated = true;
            this.btn_imprimir.BorderColor = System.Drawing.Color.Gray;
            this.btn_imprimir.BorderRadius = 2;
            this.btn_imprimir.BorderThickness = 1;
            this.btn_imprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_imprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_imprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_imprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_imprimir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_imprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_imprimir.ForeColor = System.Drawing.Color.White;
            this.btn_imprimir.Location = new System.Drawing.Point(480, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(146, 28);
            this.btn_imprimir.TabIndex = 47;
            this.btn_imprimir.Text = "Imprimir Setor";
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Animated = true;
            this.btn_cancelar.BorderColor = System.Drawing.Color.Gray;
            this.btn_cancelar.BorderRadius = 2;
            this.btn_cancelar.BorderThickness = 1;
            this.btn_cancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Location = new System.Drawing.Point(328, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(146, 28);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Excluir Setor";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Animated = true;
            this.btn_salvar.BorderColor = System.Drawing.Color.Gray;
            this.btn_salvar.BorderRadius = 2;
            this.btn_salvar.BorderThickness = 1;
            this.btn_salvar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_salvar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_salvar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_salvar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_salvar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_salvar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_salvar.ForeColor = System.Drawing.Color.White;
            this.btn_salvar.Location = new System.Drawing.Point(176, 3);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(146, 28);
            this.btn_salvar.TabIndex = 1;
            this.btn_salvar.Text = "Salvar Edições";
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_novo
            // 
            this.btn_novo.Animated = true;
            this.btn_novo.BorderColor = System.Drawing.Color.Gray;
            this.btn_novo.BorderRadius = 2;
            this.btn_novo.BorderThickness = 1;
            this.btn_novo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_novo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_novo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_novo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_novo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_novo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_novo.ForeColor = System.Drawing.Color.White;
            this.btn_novo.Location = new System.Drawing.Point(22, 3);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.Size = new System.Drawing.Size(148, 28);
            this.btn_novo.TabIndex = 0;
            this.btn_novo.Text = "Novo Setor";
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(449, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Nome Setor:";
            // 
            // txt_nomeSetor
            // 
            this.txt_nomeSetor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_nomeSetor.BorderRadius = 2;
            this.txt_nomeSetor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nomeSetor.DefaultText = "";
            this.txt_nomeSetor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_nomeSetor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_nomeSetor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nomeSetor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nomeSetor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txt_nomeSetor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nomeSetor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nomeSetor.ForeColor = System.Drawing.Color.White;
            this.txt_nomeSetor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nomeSetor.Location = new System.Drawing.Point(452, 31);
            this.txt_nomeSetor.Name = "txt_nomeSetor";
            this.txt_nomeSetor.PasswordChar = '\0';
            this.txt_nomeSetor.PlaceholderText = "";
            this.txt_nomeSetor.SelectedText = "";
            this.txt_nomeSetor.Size = new System.Drawing.Size(326, 20);
            this.txt_nomeSetor.TabIndex = 38;
            this.txt_nomeSetor.TextChanged += new System.EventHandler(this.txt_nomeSetor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(449, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 41;
            this.label2.Text = "Superior de Setor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(449, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 43;
            this.label6.Text = "Máximo de Empregos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(660, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(449, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "Horário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(458, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Vagas:";
            // 
            // txt_vagas
            // 
            this.txt_vagas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txt_vagas.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_vagas.ForeColor = System.Drawing.Color.White;
            this.txt_vagas.Location = new System.Drawing.Point(455, 308);
            this.txt_vagas.Name = "txt_vagas";
            this.txt_vagas.ReadOnly = true;
            this.txt_vagas.Size = new System.Drawing.Size(120, 20);
            this.txt_vagas.TabIndex = 55;
            this.txt_vagas.TabStop = false;
            // 
            // cb_status
            // 
            this.cb_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cb_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_status.ForeColor = System.Drawing.Color.White;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(663, 167);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(115, 21);
            this.cb_status.TabIndex = 58;
            // 
            // cb_horario
            // 
            this.cb_horario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cb_horario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_horario.ForeColor = System.Drawing.Color.White;
            this.cb_horario.FormattingEnabled = true;
            this.cb_horario.Location = new System.Drawing.Point(452, 243);
            this.cb_horario.Name = "cb_horario";
            this.cb_horario.Size = new System.Drawing.Size(326, 21);
            this.cb_horario.TabIndex = 59;
            this.cb_horario.SelectedIndexChanged += new System.EventHandler(this.cb_horario_SelectedIndexChanged);
            // 
            // n_maxEmpregados
            // 
            this.n_maxEmpregados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.n_maxEmpregados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.n_maxEmpregados.ForeColor = System.Drawing.Color.White;
            this.n_maxEmpregados.Location = new System.Drawing.Point(452, 167);
            this.n_maxEmpregados.Name = "n_maxEmpregados";
            this.n_maxEmpregados.Size = new System.Drawing.Size(120, 20);
            this.n_maxEmpregados.TabIndex = 60;
            this.n_maxEmpregados.ValueChanged += new System.EventHandler(this.n_maxAlunos_ValueChanged);
            // 
            // cb_superiorSetor
            // 
            this.cb_superiorSetor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cb_superiorSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_superiorSetor.ForeColor = System.Drawing.Color.White;
            this.cb_superiorSetor.FormattingEnabled = true;
            this.cb_superiorSetor.Location = new System.Drawing.Point(455, 105);
            this.cb_superiorSetor.Name = "cb_superiorSetor";
            this.cb_superiorSetor.Size = new System.Drawing.Size(323, 21);
            this.cb_superiorSetor.TabIndex = 61;
            this.cb_superiorSetor.SelectedIndexChanged += new System.EventHandler(this.cb_superiorSetor_SelectedIndexChanged);
            // 
            // CBLGestaoDeSetores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.cb_superiorSetor);
            this.Controls.Add(this.n_maxEmpregados);
            this.Controls.Add(this.cb_horario);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_vagas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nomeSetor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_turmas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CBLGestaoDeSetores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CBLGestaoDeSetores";
            this.Load += new System.EventHandler(this.CBLGestaoDeSetores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turmas)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.n_maxEmpregados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_turmas;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btn_imprimir;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        private Guna.UI2.WinForms.Guna2Button btn_salvar;
        private Guna.UI2.WinForms.Guna2Button btn_novo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_nomeSetor;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_fechar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_vagas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.ComboBox cb_horario;
        private System.Windows.Forms.NumericUpDown n_maxEmpregados;
        private System.Windows.Forms.ComboBox cb_superiorSetor;
    }
}