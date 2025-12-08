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

                // 🔹 NUEVO: cargar teléfono y email
                txtTelefono.Text = _facturaEdicion.Cliente.Telefono;
                txtEmail.Text = _facturaEdicion.Cliente.Email;

                numCapacidadMensual.Value = _facturaEdicion.CapacidadMensualKw;
                numMeses.Value = _facturaEdicion.MesesFuncionamiento;
                txtProducciones.Text = string.Join(",", _facturaEdicion.ProduccionMensual);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();   // 🔹 NUEVO
            string email = txtEmail.Text.Trim();         // 🔹 NUEVO

            decimal capacidad = numCapacidadMensual.Value;
            int meses = (int)numMeses.Value;

            // VALIDACIONES
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

            // Producciones separadas por coma
            List<decimal> producciones;
            try
            {
                producciones = txtProducciones.Text
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
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

            // OBJETO CLIENTE COMPLETO
            var cliente = new Cliente
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,   // 🔹 NUEVO
                Email = email          // 🔹 NUEVO
            };

            // NUEVA FACTURA
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
            else // EDICIÓN DE FACTURA
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

        private void FrmFactura_Load_1(object sender, EventArgs e)
        {

        }

        private void lblProduccion_Click(object sender, EventArgs e)
        {

        }
    }
}
