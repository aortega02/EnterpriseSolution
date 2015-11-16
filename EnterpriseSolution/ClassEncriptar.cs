using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace EnterpriseSolution
{
    //#####  CLASE PARA ENCRIPTAR LOS DATOS INPORTANTES EN LA APLICACION
    class ClassEncriptar
    {
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private byte[] VarKey;
        private byte[] VarIV;

        //#####  CONSTRUYE LAS CALVES DE ENCRIPTACION DE LA APLICACION  #####
        public ClassEncriptar()
        {
            VarKey = Encoding.ASCII.GetBytes("Nikwi*32-2014NoMiNa_ProgVer.01*#"); //Tamaño 32 Caracteres
            VarIV = Encoding.ASCII.GetBytes("Cripto.NkAes*V-1"); //Tamaño 16 Caracteres
        }

        //#####  ENCRIPTA TODO EL TEXTO ENVIADO POR MEDIO DE LA VARIABLE EntTexto  #####
        public string Encriptar(string EntTexto)
        {
            byte[] BytTexto = Encoding.ASCII.GetBytes(EntTexto);
            byte[] Encriptado = null;
            RijndaelManaged Cripto = new RijndaelManaged();

            try
            {
                using (MemoryStream ms = new MemoryStream(BytTexto.Length))
                {
                    using (CryptoStream Encriptador = new CryptoStream(ms, Cripto.CreateEncryptor(VarKey, VarIV), CryptoStreamMode.Write))
                    {
                        Encriptador.Write(BytTexto, 0, BytTexto.Length);
                        Encriptador.FlushFinalBlock();
                        Encriptador.Close();
                    }
                    Encriptado = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR003-01", ex.ToString());
            }
            return Convert.ToBase64String(Encriptado);
        }


        //#####  DESENCRIPTA TODO EL TEXTO ENVIADO POR MEDIO DE LA VARIABLE EntTexto  #####
        public string Desencriptar(string EntCripto)
        {
            byte[] BytCripto = Convert.FromBase64String(EntCripto);
            byte[] resultBytes = new byte[BytCripto.Length];
            string SalTexto = String.Empty;
            RijndaelManaged Cripto = new RijndaelManaged();

            try
            {
                using (MemoryStream ms = new MemoryStream(BytCripto))
                {
                    using (CryptoStream DesemCriptador = new CryptoStream(ms, Cripto.CreateDecryptor(VarKey, VarIV), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(DesemCriptador, true))
                        {
                            SalTexto = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR003-02", ex.ToString());
            }

            return SalTexto;
        }

    }
}
