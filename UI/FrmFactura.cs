// UI/FrmFactura.cs
using SencomFacturacion.Domain;
using SencomFacturacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SencomFacturacion.UI
{
    public partial class FrmFactura : Form
    {
        private readonly FacturaService _facturaService;
        private Factura _facturaEdicion; // null = nueva

        public FrmFactura(FacturaService facturaService, Factura facturaEdicion = null)
        {
            InitializeComponent();
            _facturaService = facturaService;
            _facturaEdicion = facturaEdicion;
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);

            if (_facturaEdicion != null)
            {
                txtNombreCliente.Text = _facturaEdicion.Cliente.Nombre;
                txtDireccion.Text = _facturaEdicion.Cliente.Direccion;

                txtTelefono.Text = _facturaEdicion.Cliente.Telefono;
                txtEmail.Text = _facturaEdicion.Cliente.Email;

                numCapacidadMensual.Value = _facturaEdicion.CapacidadMensualKw;
                numMeses.Value = _facturaEdicion.MesesFuncionamiento;
                txtProducciones.Text = string.Join(",", _facturaEdicion.ProduccionMensual);
            }
        }

        // 🔥 BOTÓN THEME
        private void btnTheme_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();              // Cambiar Light ↔ Dark
            ThemeManager.ApplyThemeToAllOpenForms(); // Repintar todos los formularios
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            decimal capacidad = numCapacidadMensual.Value;
            int meses = (int)numMeses.Value;

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Todos los campos del cliente son obligatorios (nombre, dirección, teléfono, email).");
                return;
            }

            if (meses < 1 || meses > 12)
            {
                MessageBox.Show("Los meses de funcionamiento deben estar entre 1 y 12.");
                return;
            }

            List<decimal> producciones;
            try
            {
                producciones = txtProducciones.Text
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => decimal.Parse(p.Trim()))
                    .ToList();
            }
            catch
            {
                MessageBox.Show("Formato de producción mensual inválido. Use valores separados por coma.", "Error en formato");
                return;
            }

            if (producciones.Count != meses)
            {
                MessageBox.Show("La cantidad de valores de producción debe coincidir con los meses establecidos.");
                return;
            }

            if (producciones.Any(p => p > capacidad))
            {
                MessageBox.Show("Ningún valor de producción puede superar la capacidad mensual establecida.");
                return;
            }

            var cliente = new Cliente
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            if (_facturaEdicion == null)
            {
                var nueva = new Factura
                {
                    Cliente = cliente,
                    CapacidadMensualKw = capacidad,
                    MesesFuncionamiento = meses,
                    ProduccionMensual = producciones
                };

                _facturaService.CrearFactura(nueva);
                MessageBox.Show("Factura creada correctamente.");
            }
            else
            {
                _facturaEdicion.Cliente = cliente;
                _facturaEdicion.CapacidadMensualKw = capacidad;
                _facturaEdicion.MesesFuncionamiento = meses;
                _facturaEdicion.ProduccionMensual = producciones;

                _facturaEdicion.ConsumoTotalKw = producciones.Sum();
                _facturaEdicion.MontoTotal = _facturaEdicion.ConsumoTotalKw * 0.13m;

                _facturaService.ActualizarFactura(_facturaEdicion);

                MessageBox.Show("Factura actualizada correctamente.",
                    "Factura actualizada", MessageBoxButtons.OK);
            }

            this.Close();
        }
    }
}
