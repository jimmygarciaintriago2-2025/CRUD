using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace dashboard.UI
{
    public static class UITheme
    {
        // Paleta de colores moderna (Slate & Indigo / Modern SaaS)
        public static readonly Color Primary = Color.FromArgb(79, 70, 229);       // Indigo 600
        public static readonly Color PrimaryDark = Color.FromArgb(67, 56, 202);   // Indigo 700
        public static readonly Color PrimaryLight = Color.FromArgb(238, 242, 255); // Indigo 50

        public static readonly Color Success = Color.FromArgb(16, 185, 129);      // Emerald 500
        public static readonly Color SuccessDark = Color.FromArgb(5, 150, 105);   // Emerald 600
        public static readonly Color SuccessLight = Color.FromArgb(236, 253, 245);// Emerald 50

        public static readonly Color Warning = Color.FromArgb(245, 158, 11);     // Amber 500
        public static readonly Color WarningLight = Color.FromArgb(254, 243, 199);// Amber 50

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);        // Red 500
        public static readonly Color DangerDark = Color.FromArgb(220, 38, 38);    // Red 600
        public static readonly Color DangerLight = Color.FromArgb(254, 242, 242); // Red 50

        public static readonly Color NeutralDark = Color.FromArgb(30, 41, 59);    // Slate 800 (Header / Text primary)
        public static readonly Color NeutralMedium = Color.FromArgb(100, 116, 139);// Slate 500 (Text secondary / borders)
        public static readonly Color NeutralLight = Color.FromArgb(241, 245, 249); // Slate 100 (Background canvas)
        public static readonly Color SurfaceWhite = Color.FromArgb(255, 255, 255); // White cards
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);  // Slate 200

        // Tipografías
        public static readonly Font FontTitle = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FontCardTitle = new Font("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontSection = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font FontKPI = new Font("Segoe UI", 18F, FontStyle.Bold);

        /// <summary>
        /// Aplica estilo moderno a un botón con bordes redondeados y colores planos
        /// </summary>
        public static void StyleButton(Button btn, Color bg, Color text, Color hoverBg)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bg;
            btn.ForeColor = text;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(8, 4, 8, 4);

            btn.MouseEnter += (s, e) => { btn.BackColor = hoverBg; };
            btn.MouseLeave += (s, e) => { btn.BackColor = bg; };
        }

        /// <summary>
        /// Aplica estilo moderno al DataGridView
        /// </summary>
        public static void StyleDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = SurfaceWhite;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 38;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = FontBody;

            // Encabezado
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = NeutralDark;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBodyBold;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Filas
            dgv.DefaultCellStyle.BackColor = SurfaceWhite;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255); // Indigo 100
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 27, 75);    // Indigo 950
            dgv.DefaultCellStyle.Padding = new Padding(10, 4, 10, 4);

            // Filas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 27, 75);
        }

        /// <summary>
        /// Aplica diseño de tarjeta contenedor (borde sutil y fondo blanco)
        /// </summary>
        public static void StyleCard(Panel panel)
        {
            panel.BackColor = SurfaceWhite;
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(BorderColor, 1.5f);
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                g.DrawRectangle(pen, rect);
            };
        }

        /// <summary>
        /// Aplica estilo a TextBox moderno
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = FontBody;
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.ForeColor = NeutralDark;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
