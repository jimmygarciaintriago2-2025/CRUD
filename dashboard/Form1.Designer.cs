namespace dashboard
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Header controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblApiUrl;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblConnectionStatus;

        // KPI controls
        private System.Windows.Forms.Panel pnlKPIContainer;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblKpiTotalVal;
        private System.Windows.Forms.Label lblKpiTotalTit;
        private System.Windows.Forms.Panel cardActivos;
        private System.Windows.Forms.Label lblKpiActivosVal;
        private System.Windows.Forms.Label lblKpiActivosTit;
        private System.Windows.Forms.Panel cardInactivos;
        private System.Windows.Forms.Label lblKpiInactivosVal;
        private System.Windows.Forms.Label lblKpiInactivosTit;
        private System.Windows.Forms.Panel cardApi;
        private System.Windows.Forms.Label lblKpiApiVal;
        private System.Windows.Forms.Label lblKpiApiTit;

        // Main layout
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFormCard;
        private System.Windows.Forms.Panel pnlGridCard;

        // Form controls (Left card)
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormModeBadge;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFormHint;

        // Grid controls (Right card)
        private System.Windows.Forms.Panel pnlGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.DataGridView dgvAlumnos;

        // Footer
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblLastEndpoint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblApiUrl = new System.Windows.Forms.Label();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();

            this.pnlKPIContainer = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalVal = new System.Windows.Forms.Label();
            this.lblKpiTotalTit = new System.Windows.Forms.Label();
            this.cardActivos = new System.Windows.Forms.Panel();
            this.lblKpiActivosVal = new System.Windows.Forms.Label();
            this.lblKpiActivosTit = new System.Windows.Forms.Label();
            this.cardInactivos = new System.Windows.Forms.Panel();
            this.lblKpiInactivosVal = new System.Windows.Forms.Label();
            this.lblKpiInactivosTit = new System.Windows.Forms.Label();
            this.cardApi = new System.Windows.Forms.Panel();
            this.lblKpiApiVal = new System.Windows.Forms.Label();
            this.lblKpiApiTit = new System.Windows.Forms.Label();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFormCard = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFormModeBadge = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFormHint = new System.Windows.Forms.Label();

            this.pnlGridCard = new System.Windows.Forms.Panel();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblContador = new System.Windows.Forms.Label();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.lblLastEndpoint = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlKPIContainer.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardActivos.SuspendLayout();
            this.cardInactivos.SuspendLayout();
            this.cardApi.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            this.pnlGridCard.SuspendLayout();
            this.pnlGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblApiUrl);
            this.pnlHeader.Controls.Add(this.txtApiUrl);
            this.pnlHeader.Controls.Add(this.btnTestConnection);
            this.pnlHeader.Controls.Add(this.lblConnectionStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 72);
            this.pnlHeader.TabIndex = 0;

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(360, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "🎓 Dashboard CRUD - Gestión de Alumnos";

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 40);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(430, 15);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Integración completa con los 4 endpoints REST: GET, POST, PUT y DELETE (ADO.NET)";

            // lblApiUrl
            this.lblApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApiUrl.AutoSize = true;
            this.lblApiUrl.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApiUrl.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblApiUrl.Location = new System.Drawing.Point(620, 26);
            this.lblApiUrl.Name = "lblApiUrl";
            this.lblApiUrl.Size = new System.Drawing.Size(56, 15);
            this.lblApiUrl.TabIndex = 2;
            this.lblApiUrl.Text = "API Host:";

            // txtApiUrl
            this.txtApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiUrl.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtApiUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApiUrl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtApiUrl.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtApiUrl.Location = new System.Drawing.Point(682, 23);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(260, 23);
            this.txtApiUrl.TabIndex = 3;
            this.txtApiUrl.Text = "http://localhost:5292/api/alumnocontroller";

            // btnTestConnection
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Location = new System.Drawing.Point(950, 20);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(120, 28);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "⚡ Probar API";
            this.btnTestConnection.UseVisualStyleBackColor = false;

            // lblConnectionStatus
            this.lblConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblConnectionStatus.Location = new System.Drawing.Point(1078, 26);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(95, 15);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "⚪ Sin consultar";

            // 
            // pnlKPIContainer
            // 
            this.pnlKPIContainer.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlKPIContainer.Controls.Add(this.cardTotal);
            this.pnlKPIContainer.Controls.Add(this.cardActivos);
            this.pnlKPIContainer.Controls.Add(this.cardInactivos);
            this.pnlKPIContainer.Controls.Add(this.cardApi);
            this.pnlKPIContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPIContainer.Location = new System.Drawing.Point(0, 72);
            this.pnlKPIContainer.Name = "pnlKPIContainer";
            this.pnlKPIContainer.Padding = new System.Windows.Forms.Padding(18, 12, 18, 8);
            this.pnlKPIContainer.Size = new System.Drawing.Size(1200, 80);
            this.pnlKPIContainer.TabIndex = 1;

            // cardTotal
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.cardTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotal.Controls.Add(this.lblKpiTotalVal);
            this.cardTotal.Controls.Add(this.lblKpiTotalTit);
            this.cardTotal.Location = new System.Drawing.Point(18, 10);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(260, 60);
            this.cardTotal.TabIndex = 0;

            this.lblKpiTotalVal.AutoSize = true;
            this.lblKpiTotalVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalVal.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblKpiTotalVal.Location = new System.Drawing.Point(14, 6);
            this.lblKpiTotalVal.Name = "lblKpiTotalVal";
            this.lblKpiTotalVal.Size = new System.Drawing.Size(26, 30);
            this.lblKpiTotalVal.TabIndex = 0;
            this.lblKpiTotalVal.Text = "0";

            this.lblKpiTotalTit.AutoSize = true;
            this.lblKpiTotalTit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiTotalTit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKpiTotalTit.Location = new System.Drawing.Point(16, 36);
            this.lblKpiTotalTit.Name = "lblKpiTotalTit";
            this.lblKpiTotalTit.Size = new System.Drawing.Size(148, 15);
            this.lblKpiTotalTit.TabIndex = 1;
            this.lblKpiTotalTit.Text = "👥 TOTAL REGISTRADOS";

            // cardActivos
            this.cardActivos.BackColor = System.Drawing.Color.FromArgb(236, 253, 245);
            this.cardActivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardActivos.Controls.Add(this.lblKpiActivosVal);
            this.cardActivos.Controls.Add(this.lblKpiActivosTit);
            this.cardActivos.Location = new System.Drawing.Point(292, 10);
            this.cardActivos.Name = "cardActivos";
            this.cardActivos.Size = new System.Drawing.Size(260, 60);
            this.cardActivos.TabIndex = 1;

            this.lblKpiActivosVal.AutoSize = true;
            this.lblKpiActivosVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiActivosVal.ForeColor = System.Drawing.Color.FromArgb(6, 95, 70);
            this.lblKpiActivosVal.Location = new System.Drawing.Point(14, 6);
            this.lblKpiActivosVal.Name = "lblKpiActivosVal";
            this.lblKpiActivosVal.Size = new System.Drawing.Size(26, 30);
            this.lblKpiActivosVal.TabIndex = 0;
            this.lblKpiActivosVal.Text = "0";

            this.lblKpiActivosTit.AutoSize = true;
            this.lblKpiActivosTit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiActivosTit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKpiActivosTit.Location = new System.Drawing.Point(16, 36);
            this.lblKpiActivosTit.Name = "lblKpiActivosTit";
            this.lblKpiActivosTit.Size = new System.Drawing.Size(131, 15);
            this.lblKpiActivosTit.TabIndex = 1;
            this.lblKpiActivosTit.Text = "✅ ALUMNOS ACTIVOS";

            // cardInactivos
            this.cardInactivos.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.cardInactivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardInactivos.Controls.Add(this.lblKpiInactivosVal);
            this.cardInactivos.Controls.Add(this.lblKpiInactivosTit);
            this.cardInactivos.Location = new System.Drawing.Point(566, 10);
            this.cardInactivos.Name = "cardInactivos";
            this.cardInactivos.Size = new System.Drawing.Size(260, 60);
            this.cardInactivos.TabIndex = 2;

            this.lblKpiInactivosVal.AutoSize = true;
            this.lblKpiInactivosVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiInactivosVal.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.lblKpiInactivosVal.Location = new System.Drawing.Point(14, 6);
            this.lblKpiInactivosVal.Name = "lblKpiInactivosVal";
            this.lblKpiInactivosVal.Size = new System.Drawing.Size(26, 30);
            this.lblKpiInactivosVal.TabIndex = 0;
            this.lblKpiInactivosVal.Text = "0";

            this.lblKpiInactivosTit.AutoSize = true;
            this.lblKpiInactivosTit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiInactivosTit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKpiInactivosTit.Location = new System.Drawing.Point(16, 36);
            this.lblKpiInactivosTit.Name = "lblKpiInactivosTit";
            this.lblKpiInactivosTit.Size = new System.Drawing.Size(145, 15);
            this.lblKpiInactivosTit.TabIndex = 1;
            this.lblKpiInactivosTit.Text = "⏸️ ALUMNOS INACTIVOS";

            // cardApi
            this.cardApi.BackColor = System.Drawing.Color.FromArgb(245, 243, 255);
            this.cardApi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardApi.Controls.Add(this.lblKpiApiVal);
            this.cardApi.Controls.Add(this.lblKpiApiTit);
            this.cardApi.Location = new System.Drawing.Point(840, 10);
            this.cardApi.Name = "cardApi";
            this.cardApi.Size = new System.Drawing.Size(340, 60);
            this.cardApi.TabIndex = 3;

            this.lblKpiApiVal.AutoSize = true;
            this.lblKpiApiVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiApiVal.ForeColor = System.Drawing.Color.FromArgb(91, 33, 182);
            this.lblKpiApiVal.Location = new System.Drawing.Point(14, 10);
            this.lblKpiApiVal.Name = "lblKpiApiVal";
            this.lblKpiApiVal.Size = new System.Drawing.Size(144, 21);
            this.lblKpiApiVal.TabIndex = 0;
            this.lblKpiApiVal.Text = "Endpoints Listos";

            this.lblKpiApiTit.AutoSize = true;
            this.lblKpiApiTit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKpiApiTit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblKpiApiTit.Location = new System.Drawing.Point(16, 36);
            this.lblKpiApiTit.Name = "lblKpiApiTit";
            this.lblKpiApiTit.Size = new System.Drawing.Size(177, 15);
            this.lblKpiApiTit.TabIndex = 1;
            this.lblKpiApiTit.Text = "⚡ ESTADO DE 4 ENDPOINTS";

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlMain.Controls.Add(this.pnlGridCard);
            this.pnlMain.Controls.Add(this.pnlFormCard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 152);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(18, 6, 18, 12);
            this.pnlMain.Size = new System.Drawing.Size(1200, 528);
            this.pnlMain.TabIndex = 2;

            // 
            // pnlFormCard (Formulario a la Izquierda)
            // 
            this.pnlFormCard.BackColor = System.Drawing.Color.White;
            this.pnlFormCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormCard.Controls.Add(this.lblFormTitle);
            this.pnlFormCard.Controls.Add(this.lblFormModeBadge);
            this.pnlFormCard.Controls.Add(this.lblId);
            this.pnlFormCard.Controls.Add(this.txtId);
            this.pnlFormCard.Controls.Add(this.lblNombres);
            this.pnlFormCard.Controls.Add(this.txtNombres);
            this.pnlFormCard.Controls.Add(this.lblApellidos);
            this.pnlFormCard.Controls.Add(this.txtApellidos);
            this.pnlFormCard.Controls.Add(this.lblCedula);
            this.pnlFormCard.Controls.Add(this.txtCedula);
            this.pnlFormCard.Controls.Add(this.lblEstado);
            this.pnlFormCard.Controls.Add(this.chkActivo);
            this.pnlFormCard.Controls.Add(this.btnNuevo);
            this.pnlFormCard.Controls.Add(this.btnGuardar);
            this.pnlFormCard.Controls.Add(this.btnActualizar);
            this.pnlFormCard.Controls.Add(this.btnEliminar);
            this.pnlFormCard.Controls.Add(this.btnLimpiar);
            this.pnlFormCard.Controls.Add(this.lblFormHint);
            this.pnlFormCard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormCard.Location = new System.Drawing.Point(18, 6);
            this.pnlFormCard.Name = "pnlFormCard";
            this.pnlFormCard.Size = new System.Drawing.Size(380, 510);
            this.pnlFormCard.TabIndex = 0;

            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblFormTitle.Location = new System.Drawing.Point(18, 16);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(185, 21);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "📝 Datos del Alumno";

            // lblFormModeBadge
            this.lblFormModeBadge.AutoSize = true;
            this.lblFormModeBadge.BackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.lblFormModeBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormModeBadge.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblFormModeBadge.Location = new System.Drawing.Point(215, 20);
            this.lblFormModeBadge.Name = "lblFormModeBadge";
            this.lblFormModeBadge.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblFormModeBadge.Size = new System.Drawing.Size(140, 17);
            this.lblFormModeBadge.TabIndex = 1;
            this.lblFormModeBadge.Text = "[ MODO: NUEVO REGISTRO ]";

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblId.Location = new System.Drawing.Point(20, 52);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(71, 15);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "ID Registro:";

            // txtId
            this.txtId.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.txtId.Location = new System.Drawing.Point(20, 70);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(335, 23);
            this.txtId.TabIndex = 3;
            this.txtId.Text = "Automático";

            // lblNombres
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNombres.Location = new System.Drawing.Point(20, 102);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(69, 15);
            this.lblNombres.TabIndex = 4;
            this.lblNombres.Text = "Nombres *:";

            // txtNombres
            this.txtNombres.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombres.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombres.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNombres.Location = new System.Drawing.Point(20, 120);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(335, 24);
            this.txtNombres.TabIndex = 5;

            // lblApellidos
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblApellidos.Location = new System.Drawing.Point(20, 154);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(68, 15);
            this.lblApellidos.TabIndex = 6;
            this.lblApellidos.Text = "Apellidos *:";

            // txtApellidos
            this.txtApellidos.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtApellidos.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtApellidos.Location = new System.Drawing.Point(20, 172);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(335, 24);
            this.txtApellidos.TabIndex = 7;

            // lblCedula
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCedula.Location = new System.Drawing.Point(20, 206);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(56, 15);
            this.lblCedula.TabIndex = 8;
            this.lblCedula.Text = "Cédula *:";

            // txtCedula
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCedula.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtCedula.Location = new System.Drawing.Point(20, 224);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(335, 24);
            this.txtCedula.TabIndex = 9;

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblEstado.Location = new System.Drawing.Point(20, 258);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(107, 15);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado Académico:";

            // chkActivo
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.chkActivo.Location = new System.Drawing.Point(24, 278);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(200, 21);
            this.chkActivo.TabIndex = 11;
            this.chkActivo.Text = "✓ Alumno Activo / Matriculado";
            this.chkActivo.UseVisualStyleBackColor = true;

            // btnNuevo
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(20, 315);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(162, 34);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "➕ Nuevo / Limpiar";
            this.btnNuevo.UseVisualStyleBackColor = false;

            // btnGuardar (POST)
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(193, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(162, 34);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "💾 Guardar (POST)";
            this.btnGuardar.UseVisualStyleBackColor = false;

            // btnActualizar (PUT)
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnActualizar.Enabled = false;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(20, 358);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(162, 34);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "✏️ Actualizar (PUT)";
            this.btnActualizar.UseVisualStyleBackColor = false;

            // btnEliminar (DELETE)
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(193, 358);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(162, 34);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "⏸️ Inactivar (DELETE)";
            this.btnEliminar.UseVisualStyleBackColor = false;

            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLimpiar.Location = new System.Drawing.Point(20, 401);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(335, 28);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "🔄 Restablecer Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = false;

            // lblFormHint
            this.lblFormHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFormHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFormHint.Location = new System.Drawing.Point(20, 440);
            this.lblFormHint.Name = "lblFormHint";
            this.lblFormHint.Size = new System.Drawing.Size(335, 55);
            this.lblFormHint.TabIndex = 17;
            this.lblFormHint.Text = "💡 Consejo UX: Haga clic en cualquier fila del listado para cargar sus datos en este formulario y habilitar las opciones de Actualizar y Eliminar.";

            // 
            // pnlGridCard (Listado a la Derecha)
            // 
            this.pnlGridCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridCard.BackColor = System.Drawing.Color.White;
            this.pnlGridCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGridCard.Controls.Add(this.dgvAlumnos);
            this.pnlGridCard.Controls.Add(this.pnlGridHeader);
            this.pnlGridCard.Location = new System.Drawing.Point(412, 6);
            this.pnlGridCard.Name = "pnlGridCard";
            this.pnlGridCard.Size = new System.Drawing.Size(770, 510);
            this.pnlGridCard.TabIndex = 1;

            // pnlGridHeader
            this.pnlGridHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Controls.Add(this.lblBuscar);
            this.pnlGridHeader.Controls.Add(this.txtBuscar);
            this.pnlGridHeader.Controls.Add(this.cmbFiltroEstado);
            this.pnlGridHeader.Controls.Add(this.btnRefrescar);
            this.pnlGridHeader.Controls.Add(this.lblContador);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Size = new System.Drawing.Size(768, 85);
            this.pnlGridHeader.TabIndex = 0;

            // lblGridTitle
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridTitle.Location = new System.Drawing.Point(14, 14);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(220, 21);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "📋 Listado Global de Alumnos";

            // lblContador
            this.lblContador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblContador.Location = new System.Drawing.Point(595, 18);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(155, 15);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "Mostrando: 0 registros";
            this.lblContador.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblBuscar.Location = new System.Drawing.Point(14, 48);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(60, 15);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "🔍 Buscar:";

            // txtBuscar
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtBuscar.Location = new System.Drawing.Point(76, 45);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Filtrar por ID, nombres, apellidos o cédula...";
            this.txtBuscar.Size = new System.Drawing.Size(260, 23);
            this.txtBuscar.TabIndex = 3;

            // cmbFiltroEstado
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos los estados",
            "Solo Activos",
            "Solo Inactivos"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(350, 45);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(140, 23);
            this.cmbFiltroEstado.TabIndex = 4;

            // btnRefrescar (GET)
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(628, 43);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(125, 28);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "🔄 Recargar (GET)";
            this.btnRefrescar.UseVisualStyleBackColor = false;

            // dgvAlumnos
            this.dgvAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.Location = new System.Drawing.Point(0, 85);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.Size = new System.Drawing.Size(768, 423);
            this.dgvAlumnos.TabIndex = 1;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlFooter.Controls.Add(this.lblStatusMessage);
            this.pnlFooter.Controls.Add(this.lblLastEndpoint);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 680);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1200, 32);
            this.pnlFooter.TabIndex = 3;

            // lblStatusMessage
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatusMessage.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblStatusMessage.Location = new System.Drawing.Point(16, 8);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(365, 15);
            this.lblStatusMessage.TabIndex = 0;
            this.lblStatusMessage.Text = "✓ Dashboard iniciado. Listo para interactuar con la API REST.";

            // lblLastEndpoint
            this.lblLastEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastEndpoint.AutoSize = true;
            this.lblLastEndpoint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLastEndpoint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLastEndpoint.Location = new System.Drawing.Point(920, 8);
            this.lblLastEndpoint.Name = "lblLastEndpoint";
            this.lblLastEndpoint.Size = new System.Drawing.Size(260, 15);
            this.lblLastEndpoint.TabIndex = 1;
            this.lblLastEndpoint.Text = "4 Endpoints: GET | POST | PUT | DELETE";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1200, 712);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlKPIContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1080, 680);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Alumnos - Dashboard CRUD";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKPIContainer.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardActivos.ResumeLayout(false);
            this.cardActivos.PerformLayout();
            this.cardInactivos.ResumeLayout(false);
            this.cardInactivos.PerformLayout();
            this.cardApi.ResumeLayout(false);
            this.cardApi.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlFormCard.ResumeLayout(false);
            this.pnlFormCard.PerformLayout();
            this.pnlGridCard.ResumeLayout(false);
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
