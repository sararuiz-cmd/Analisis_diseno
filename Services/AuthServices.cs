using SencomFacturacion.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SencomFacturacion.Services
{
    public class AuthServices
    {
        private readonly string _filePath;

        public AuthServices()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public bool RegistrarUsuario(string username, string password)
        {
            var usuarios = ObtenerUsuarios();
            if (usuarios.Exists(u => u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return false;

            string hash = HashPassword(password);
            File.AppendAllLines(_filePath, new[] { $"{username};{hash}" });
            return true;
        }

        public bool ValidarLogin(string username, string password)
        {
            string hash = HashPassword(password);
            foreach (var u in ObtenerUsuarios())
                if (u.NombreUsuario.Equals(username, StringComparison.OrdinalIgnoreCase) && u.HashPassword == hash)
                    return true;
            return false;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var lista = new List<Usuario>();
            foreach (var linea in File.ReadAllLines(_filePath))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                var partes = linea.Split(';');
                lista.Add(new Usuario { NombreUsuario = partes[0], HashPassword = partes[1] });
            }
            return lista;
        }

        private string HashPassword(string password)
        {
            var sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
