﻿using CapaDatos;
using CapaModelo;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBiblioteca
{
    public partial class ModificarBibliotecario : Form
    {
        public int CodBibliotecario;
        LBibliotecario Db = new LBibliotecario();
        public ModificarBibliotecario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool valordecajas;
                valordecajas = true;

                foreach (Control Caja in this.Controls)
                {
                    if ((Caja) is TextBox)
                    {
                        if (String.IsNullOrEmpty(Caja.Text))
                        {
                            valordecajas = false;
                            break;
                        }
                    }
                }

                if (valordecajas)
                    ModificarBibliotecarios();
                else
                    Interaction.MsgBox("Complete Todos los Datos", MsgBoxStyle.Information, "Mensaje del Sistema");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void ModificarBibliotecarios()
        {
            try
            {
                Db.CodBibliotecario = CodBibliotecario;
                Db.Nombres = txtnombre.Text;
                Db.Apellidos = txtapellido.Text;
                Db.Direccion = txtdireccion.Text;
                Db.Email = txtemail.Text;
                Db.Telefono = Convert.ToInt32(txttelefono.Text);
                Db.Dni = Convert.ToInt32(txtdni.Text);

                if (DBibliotecario.ModificarBibliotecario(Db))
                    this.Close();
                else
                    Interaction.MsgBox("El Registro no fue Modificado", MsgBoxStyle.Exclamation, "Mensaje del Sistema");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
