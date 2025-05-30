﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace APP3
{
    class Crectangle
    {
        //Datos miembros (Atributos de la clase)

        //Ancho del rectángulo
        private float mWidth;
        //Alto del rectángulo
        private float mHeight;
        //Perímetro del rectángulo
        private float mPerimeter;
        //Área del rectángulo
        private float mArea;
        //Objeto que activa el modo gráfico
        private Graphics mGraph;
        //Constante scale factor (Zoom In / Zoom Out)
        private const float SF = 20;
        //Objeto bolígrafo que dibuja o escribe en un lienzo (canvas)
        private Pen mPen;

        //Funciones Miembro (Métodos de la clase)

        //Constructor sin parámetros
        public Crectangle()
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
        }

        //Función que lee los datos de entrada del rectángulo
        public bool ReadData(TextBox txtWidth, TextBox txtHeight)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWidth.Text) || string.IsNullOrWhiteSpace(txtHeight.Text))
                {
                    MessageBox.Show("No deje los campos vacíos.", "Mensaje de error");
                    return false;
                }

                if (!float.TryParse(txtWidth.Text, out mWidth) || !float.TryParse(txtHeight.Text, out mHeight))
                {
                    MessageBox.Show("Ingrese solo números válidos (sin letras ni símbolos).", "Mensaje de error");
                    return false;
                }

                if (mWidth < 0 || mHeight < 0)
                {
                    MessageBox.Show("No se permiten valores menores a cero.", "Mensaje de error");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Mensaje de error");
                return false;
            }
        }


        public void PerimeterRectangle()
        {
            mPerimeter = 2 * mWidth + 2 * mHeight;
        }

        public void AreaRectangle()
        {
            mArea = mWidth * mHeight;
        }

        public void initializeData(TextBox txtWidth, TextBox txtHeight, TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;

            txtWidth.Text = ""; txtHeight.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            txtWidth.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            mGraph.DrawRectangle(mPen,0,0,mWidth*SF,mHeight*SF);
        }

        public void CloseForm(Form frmRectangle)
        {
            frmRectangle.Close();
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

    }
}
