using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard.Models;
using dashboard.Services;
using dashboard.UI;

namespace dashboard
{
    public partial class Form1 : Form
    {
        private readonly AlumnoApiClient _apiClient;
        private List<Persona> _alumnosCache = new List<Persona>();
        private bool _isEditing = false;
        private int _selectedId = 0;

        public Form1()
        {
            InitializeComponent();
            _apiClient = new AlumnoApiClient(txtApiUrl.Text);

            SetupCustomStyles();
            SetupEventHandlers();
            ConfigureDataGridView();
        }

        private void SetupCustomStyles()
        {
            // Aplicar temas modernos a botones
            UITheme.StyleButton(btnGuardar, UITheme.Success, Color.White, UITheme.SuccessDark);
            UITheme.StyleButton(btnActualizar, UITheme.Primary, Color.White, UITheme.PrimaryDark);
            UITheme.StyleButton(btnEliminar, UITheme.Danger, Color.White, UITheme.DangerDark);
            UITheme.StyleButton(btnNuevo, UITheme.NeutralMedium, Color.White, UITheme.NeutralDark);
            UITheme.StyleButton(btnRefrescar, UITheme.Primary, Color.White, UITheme.PrimaryDark);
            UITheme.StyleButton(btnTestConnection, Color.FromArgb(67, 56, 202), Color.White, Color.FromArgb(79, 70, 229));

            // Aplicar tema moderno a la cuadrícula de datos
            UITheme.StyleDataGrid(dgvAlumnos);

            // Card backgrounds
            UITheme.StyleCard(pnlFormCard);
            UITheme.StyleCard(pnlGridCard);

            // Textboxes
            UITheme.StyleTextBox(txtNombres);
            UITheme.StyleTextBox(txtApellidos);
            UITheme.StyleTextBox(txtCedula);
            UITheme.StyleTextBox(txtBuscar);

            cmbFiltroEstado.SelectedIndex = 0;
            chkActivo.CheckedChanged += (s, e) =>
            {
                if (chkActivo.Checked)
                {
                    chkActivo.Text = "✓ Alumno Activo / Matriculado";
                    chkActivo.ForeColor = UITheme.Success;
                }
                else
                {
                    chkActivo.Text = "✗ Alumno Inactivo / Suspendido";
                    chkActivo.ForeColor = UITheme.Danger;
                }
            };
        }

        private void SetupEventHandlers()
        {
            Load += async (s, e) =>
            {
                await ProbarConexionAsync(silencioso: true);
                await CargarAlumnosAsync();
            };

            // Probar conexión
            btnTestConnection.Click += async (s, e) =>
            {
                _apiClient.SetBaseUrl(txtApiUrl.Text);
                await ProbarConexionAsync(silencioso: false);
            };

            txtApiUrl.TextChanged += (s, e) =>
            {
                _apiClient.SetBaseUrl(txtApiUrl.Text);
            };

            // CRUD Handlers
            btnRefrescar.Click += async (s, e) => await CargarAlumnosAsync();
            btnGuardar.Click += async (s, e) => await GuardarNuevoAlumnoAsync();
            btnActualizar.Click += async (s, e) => await ActualizarAlumnoAsync();
            btnEliminar.Click += async (s, e) => await EliminarAlumnoAsync();

            btnNuevo.Click += (s, e) => ResetearFormulario();
            btnLimpiar.Click += (s, e) => ResetearFormulario();

            // Filtros y Búsqueda en tiempo real
            txtBuscar.TextChanged += (s, e) => FiltrarAlumnos();
            cmbFiltroEstado.SelectedIndexChanged += (s, e) => FiltrarAlumnos();

            // Selección en DataGrid
            dgvAlumnos.SelectionChanged += (s, e) => OnAlumnoSeleccionadoEnGrid();
            dgvAlumnos.CellClick += (s, e) => OnAlumnoSeleccionadoEnGrid();

            // Formateo de celdas para columnas
            dgvAlumnos.CellFormatting += DgvAlumnos_CellFormatting;
        }

        private void ConfigureDataGridView()
        {
            dgvAlumnos.AutoGenerateColumns = false;
            dgvAlumnos.Columns.Clear();

            // 1. Columna ID
            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Idpersonas",
                HeaderText = "ID",
                Name = "Idpersonas",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = UITheme.FontBodyBold,
                    ForeColor = UITheme.NeutralMedium
                }
            };
            dgvAlumnos.Columns.Add(colId);

            // 2. Columna Nombres
            var colNombres = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombres",
                HeaderText = "Nombres",
                Name = "Nombres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            };
            dgvAlumnos.Columns.Add(colNombres);

            // 3. Columna Apellidos
            var colApellidos = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellidos",
                HeaderText = "Apellidos",
                Name = "Apellidos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            };
            dgvAlumnos.Columns.Add(colApellidos);

            // 4. Columna Cédula
            var colCedula = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cedula",
                HeaderText = "Cédula",
                Name = "Cedula",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = UITheme.FontBody
                }
            };
            dgvAlumnos.Columns.Add(colCedula);

            // 5. Columna Estado
            var colEstado = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoTexto",
                HeaderText = "Estado",
                Name = "EstadoTexto",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = UITheme.FontBodyBold
                }
            };
            dgvAlumnos.Columns.Add(colEstado);
        }

        private void DgvAlumnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvAlumnos.Rows.Count) return;

            // Formatear celda de estado con color distintivo
            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "EstadoTexto" && e.Value != null)
            {
                string estado = e.Value.ToString() ?? "";
                if (estado == "Activo")
                {
                    e.Value = "● Activo";
                    e.CellStyle.ForeColor = UITheme.SuccessDark;
                }
                else
                {
                    e.Value = "○ Inactivo";
                    e.CellStyle.ForeColor = UITheme.Danger;
                }
            }
        }

        #region Conexión y Diagnóstico

        private async Task ProbarConexionAsync(bool silencioso)
        {
            lblConnectionStatus.Text = "⏳ Comprobando...";
            lblConnectionStatus.ForeColor = UITheme.Warning;

            var (conectado, mensaje, latencia) = await _apiClient.ProbarConexionAsync();

            if (conectado)
            {
                lblConnectionStatus.Text = _apiClient.IsApiOnline ? $"🟢 API REST ({latencia}ms)" : $"🟢 SQL Server ({latencia}ms)";
                lblConnectionStatus.ForeColor = UITheme.Success;
                lblKpiApiVal.Text = _apiClient.IsApiOnline ? "API REST (200 OK)" : "SQL Server Directo";
                lblKpiApiVal.ForeColor = UITheme.Success;
                SetStatus($"✓ {mensaje}", isError: false);
                lblLastEndpoint.Text = $"Modo Activo: {_apiClient.ActiveModeDescription}";

                if (!silencioso)
                {
                    MessageBox.Show(
                        $"Diagnóstico de Conexión:\n\n{mensaje}\n\nModo activo: {_apiClient.ActiveModeDescription}",
                        "Conexión Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                lblConnectionStatus.Text = "🔴 Desconectado";
                lblConnectionStatus.ForeColor = UITheme.Danger;
                lblKpiApiVal.Text = "Sin Conexión";
                lblKpiApiVal.ForeColor = UITheme.Danger;
                SetStatus($"⚠ {mensaje}", isError: true);

                if (!silencioso)
                {
                    MessageBox.Show(
                        $"No se pudo conectar ni con la API REST ni con SQL Server.\n\nDetalle: {mensaje}\n\nVerifique que SQL Server Express (.\\SQLEXPRESS) o la API estén en ejecución.",
                        "Sin Conexión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Operaciones CRUD (4 Endpoints)

        /// <summary>
        /// ENDPOINT 1 (GET): Cargar todos los alumnos
        /// </summary>
        private async Task CargarAlumnosAsync()
        {
            btnRefrescar.Enabled = false;
            btnRefrescar.Text = "⏳ Cargando...";
            SetStatus("Consultando listado de alumnos...");

            try
            {
                var (exito, datos, mensaje) = await _apiClient.ObtenerTodosAsync();

                if (exito)
                {
                    _alumnosCache = datos ?? new List<Persona>();
                    FiltrarAlumnos();
                    ActualizarKPIs();
                    SetStatus($"✓ {mensaje}");
                    lblLastEndpoint.Text = $"Modo: {_apiClient.ActiveModeDescription}";
                    lblConnectionStatus.Text = _apiClient.IsApiOnline ? "🟢 API REST" : "🟢 SQL Server";
                    lblConnectionStatus.ForeColor = UITheme.Success;
                    lblKpiApiVal.Text = _apiClient.IsApiOnline ? "API REST (200 OK)" : "SQL Server Directo";
                    lblKpiApiVal.ForeColor = UITheme.Success;
                }
                else
                {
                    SetStatus($"⚠ Error al consultar alumnos: {mensaje}", isError: true);
                    lblLastEndpoint.Text = "Última acción: Error de Conexión";
                }
            }
            finally
            {
                btnRefrescar.Enabled = true;
                btnRefrescar.Text = "🔄 Recargar (GET)";
            }
        }

        /// <summary>
        /// ENDPOINT 2 (POST): Registrar nuevo alumno
        /// </summary>
        private async Task GuardarNuevoAlumnoAsync()
        {
            if (!ValidarFormulario()) return;

            var nuevo = new Persona
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Activo = chkActivo.Checked
            };

            btnGuardar.Enabled = false;
            btnGuardar.Text = "⏳ Guardando...";
            SetStatus("Enviando petición POST para registrar alumno...");

            try
            {
                var (exito, mensaje, _) = await _apiClient.InsertarAsync(nuevo);

                if (exito)
                {
                    MessageBox.Show($"¡Alumno '{nuevo.NombreCompleto}' registrado exitosamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                    await CargarAlumnosAsync();
                    lblLastEndpoint.Text = "Última acción: POST /api/alumnocontroller (200 OK)";
                }
                else
                {
                    MessageBox.Show($"No se pudo registrar el alumno.\n\n{mensaje}", "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetStatus($"⚠ Error POST: {mensaje}", isError: true);
                }
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "💾 Guardar (POST)";
            }
        }

        /// <summary>
        /// ENDPOINT 3 (PUT): Actualizar alumno seleccionado
        /// </summary>
        private async Task ActualizarAlumnoAsync()
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Por favor seleccione un alumno de la tabla para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormulario()) return;

            var actualizado = new Persona
            {
                Idpersonas = _selectedId,
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Activo = chkActivo.Checked
            };

            btnActualizar.Enabled = false;
            btnActualizar.Text = "⏳ Actualizando...";
            SetStatus($"Enviando petición PUT para actualizar alumno #{_selectedId}...");

            try
            {
                var (exito, mensaje) = await _apiClient.ActualizarAsync(actualizado);

                if (exito)
                {
                    MessageBox.Show($"¡Alumno #{_selectedId} actualizado exitosamente!", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                    await CargarAlumnosAsync();
                    lblLastEndpoint.Text = $"Última acción: PUT /api/alumnocontroller/{_selectedId} (200 OK)";
                }
                else
                {
                    MessageBox.Show($"No se pudo actualizar el alumno.\n\n{mensaje}", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetStatus($"⚠ Error PUT: {mensaje}", isError: true);
                }
            }
            finally
            {
                btnActualizar.Enabled = _isEditing;
                btnActualizar.Text = "✏️ Actualizar (PUT)";
            }
        }

        /// <summary>
        /// ENDPOINT 4 (DELETE): Inactivar alumno seleccionado (Borrado Lógico)
        /// </summary>
        private async Task EliminarAlumnoAsync()
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Por favor seleccione un alumno de la tabla para inactivar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"¿Está seguro de que desea cambiar el estado del alumno a INACTIVO?\n\nID: {_selectedId}\nNombre: {txtNombres.Text} {txtApellidos.Text}\nCédula: {txtCedula.Text}\n\nEsta acción ejecutará el borrado lógico (DELETE /api/alumnocontroller/{_selectedId}) cambiando su estado a Inactivo sin borrar los datos del sistema.",
                "Confirmar Inactivación de Alumno",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            btnEliminar.Enabled = false;
            btnEliminar.Text = "⏳ Inactivando...";
            SetStatus($"Enviando petición DELETE para inactivar alumno #{_selectedId}...");

            try
            {
                var (exito, mensaje) = await _apiClient.EliminarAsync(_selectedId);

                if (exito)
                {
                    MessageBox.Show($"¡Alumno #{_selectedId} marcado como INACTIVO exitosamente!", "Inactivación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearFormulario();
                    await CargarAlumnosAsync();
                    lblLastEndpoint.Text = $"Última acción: DELETE /api/alumnocontroller/{_selectedId} (Inactivado 200 OK)";
                }
                else
                {
                    MessageBox.Show($"No se pudo inactivar el alumno.\n\n{mensaje}", "Error al Inactivar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetStatus($"⚠ Error DELETE: {mensaje}", isError: true);
                }
            }
            finally
            {
                btnEliminar.Enabled = _isEditing;
                btnEliminar.Text = "⏸️ Inactivar (DELETE)";
            }
        }

        #endregion

        #region Búsqueda, Filtros y UI Helpers

        private void FiltrarAlumnos()
        {
            string filtroTexto = txtBuscar.Text.Trim().ToLowerInvariant();
            int filtroEstado = cmbFiltroEstado.SelectedIndex; // 0: Todos, 1: Activos, 2: Inactivos

            var consulta = _alumnosCache.AsEnumerable();

            // Filtro por texto
            if (!string.IsNullOrWhiteSpace(filtroTexto))
            {
                consulta = consulta.Where(a =>
                    a.Idpersonas.ToString().Contains(filtroTexto) ||
                    (a.Nombres != null && a.Nombres.ToLowerInvariant().Contains(filtroTexto)) ||
                    (a.Apellidos != null && a.Apellidos.ToLowerInvariant().Contains(filtroTexto)) ||
                    (a.Cedula != null && a.Cedula.ToLowerInvariant().Contains(filtroTexto))
                );
            }

            // Filtro por estado
            if (filtroEstado == 1)
            {
                consulta = consulta.Where(a => a.Activo);
            }
            else if (filtroEstado == 2)
            {
                consulta = consulta.Where(a => !a.Activo);
            }

            var filtrados = consulta.ToList();
            dgvAlumnos.DataSource = filtrados;

            lblContador.Text = $"Mostrando: {filtrados.Count} de {_alumnosCache.Count} alumnos";
        }

        private void ActualizarKPIs()
        {
            int total = _alumnosCache.Count;
            int activos = _alumnosCache.Count(a => a.Activo);
            int inactivos = _alumnosCache.Count(a => !a.Activo);

            lblKpiTotalVal.Text = total.ToString();
            lblKpiActivosVal.Text = activos.ToString();
            lblKpiInactivosVal.Text = inactivos.ToString();
        }

        private void OnAlumnoSeleccionadoEnGrid()
        {
            if (dgvAlumnos.CurrentRow == null || dgvAlumnos.CurrentRow.DataBoundItem is not Persona alumno)
            {
                return;
            }

            _selectedId = alumno.Idpersonas;
            _isEditing = true;

            txtId.Text = alumno.Idpersonas.ToString();
            txtNombres.Text = alumno.Nombres;
            txtApellidos.Text = alumno.Apellidos;
            txtCedula.Text = alumno.Cedula;
            chkActivo.Checked = alumno.Activo;

            // Cambiar modo visual a Edición
            lblFormModeBadge.Text = $"[ MODO: EDITANDO #{alumno.Idpersonas} ]";
            lblFormModeBadge.BackColor = UITheme.WarningLight;
            lblFormModeBadge.ForeColor = Color.FromArgb(180, 83, 9); // Amber 700

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;

            SetStatus($"Alumno #{alumno.Idpersonas} seleccionado para edición.");
        }

        private void ResetearFormulario()
        {
            _selectedId = 0;
            _isEditing = false;

            txtId.Text = "Automático";
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            chkActivo.Checked = true;

            // Cambiar modo visual a Nuevo Registro
            lblFormModeBadge.Text = "[ MODO: NUEVO REGISTRO ]";
            lblFormModeBadge.BackColor = UITheme.PrimaryLight;
            lblFormModeBadge.ForeColor = UITheme.Primary;

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvAlumnos.ClearSelection();
            txtNombres.Focus();

            SetStatus("Formulario restablecido en modo Nuevo Registro.");
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("El campo 'Nombres' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El campo 'Apellidos' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El campo 'Cédula' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return false;
            }

            return true;
        }

        private void SetStatus(string mensaje, bool isError = false)
        {
            lblStatusMessage.Text = mensaje;
            lblStatusMessage.ForeColor = isError ? Color.FromArgb(248, 113, 113) : Color.FromArgb(203, 213, 225);
        }

        #endregion
    }
}
