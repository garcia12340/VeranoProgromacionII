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
    public partial class NuevoLibro : Form
    {
        DAutor FuncAutor = new DAutor();
        //-------------------------------------------------
        DLibros FuncLibro = new DLibros();
        LLibros DatLibro = new LLibros();
        //-------------------------------------------------
        DGenero FuncGenero = new DGenero();
        //-------------------------------------------------
        DEditorial FuncEditorial = new DEditorial();
        public NuevoLibro()
        {
            InitializeComponent();
        }

        private void NuevoLibro_Load(object sender, EventArgs e)
        {
            CargarAutor();
            CargarGenero();
            CargarEditorial();
        }

        //Este metodo sirve para cargar los autores que existe en la bd y se cargan mediante un ComboBox
        private void CargarAutor()
        {
            try
            {
                cboAutor.DataSource = FuncAutor.MostrarAutor();

                cboAutor.DisplayMember = "Autor";
                cboAutor.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGenero()
        {
            try
            {
                cboGenero.DataSource = FuncGenero.MostrarGenero();

                cboGenero.DisplayMember = "Genero";
                cboGenero.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarEditorial()
        {
            try
            {
                cboEditorial.DataSource = FuncEditorial.MostrarEditorial();

                cboEditorial.DisplayMember = "Editorial";
                cboEditorial.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
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
                    AgregarLibro();
                else
                    Interaction.MsgBox("Complete Todos los Datos", MsgBoxStyle.Information, "Mensaje del Sistema");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void AgregarLibro()
        {
            try
            {
                DatLibro.Titulo = txtTitulo.Text;
                DatLibro.CodAutor = Convert.ToInt32(cboAutor.SelectedValue.ToString());
                DatLibro.CodGenero = Convert.ToInt32(cboGenero.SelectedValue.ToString());
                DatLibro.CodEditorial = Convert.ToInt32(cboEditorial.SelectedValue.ToString());
                DatLibro.Ubicacion = txtUbicacion.Text;
                DatLibro.Cantidad = Convert.ToInt32(txtCantidad.Text);
                DatLibro.Nro_Edicion = Convert.ToInt32(txtEdicion.Text);
                DatLibro.AñoEdicion = Convert.ToInt32(txtAñoEdicion.Text);

                if (DLibros.Agregarlibro(DatLibro))
                    this.Close();
                else
                    Interaction.MsgBox("El Registro no fue Agregado", MsgBoxStyle.Exclamation, "Mensaje del Sistema");
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
