using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SharpGL;

namespace OOP_SHARPP
{
    public partial class Form1 : Form
    {
        TextBox[,] leftBoxes = new TextBox[4, 4];
        TextBox[,] rightBoxes = new TextBox[4, 4];
        TextBox[,] centerBoxes = new TextBox[4, 4];

        Vector2Creator Vector2Creator = new Vector2Creator();
        Vector3Creator Vector3Creator = new Vector3Creator();
        Vector4Creator Vector4Creator = new Vector4Creator();

        Matrix2Creator Matrix2Creator = new Matrix2Creator();
        Matrix3Creator Matrix3Creator = new Matrix3Creator();
        Matrix4Creator Matrix4Creator = new Matrix4Creator();

       Vector3 drawVector1, drawVector2, drawVector3;


        private float angleX=0, angleY=0, angleZ;
        public Form1()
        {
            InitializeComponent();

            drawVector1 = (Vector3)Vector3Creator.Create();
            drawVector2 = (Vector3)Vector3Creator.Create();
            drawVector3 = (Vector3)Vector3Creator.Create();


            centerBoxes[0, 0] = textBox17;
            centerBoxes[0, 1] = textBox18;
            centerBoxes[0, 2] = textBox19;
            centerBoxes[0, 3] = textBox20;
                                      
            centerBoxes[1, 0] = textBox21;
            centerBoxes[1, 1] = textBox22;
            centerBoxes[1, 2] = textBox23;
            centerBoxes[1, 3] = textBox24;
                                      
            centerBoxes[2, 0] = textBox25;
            centerBoxes[2, 1] = textBox26;
            centerBoxes[2, 2] = textBox27;
            centerBoxes[2, 3] = textBox28;
                                      
            centerBoxes[3, 0] = textBox29;
            centerBoxes[3, 1] = textBox30;
            centerBoxes[3, 2] = textBox31;
            centerBoxes[3, 3] = textBox32;


            //---
            leftBoxes[0, 0] = textBox1;
            leftBoxes[0, 1] = textBox2;
            leftBoxes[0, 2] = textBox3;
            leftBoxes[0, 3] = textBox4;

            leftBoxes[1, 0] = textBox5;
            leftBoxes[1, 1] = textBox6;
            leftBoxes[1, 2] = textBox7;
            leftBoxes[1, 3] = textBox8;

            leftBoxes[2, 0] = textBox9;
            leftBoxes[2, 1] = textBox10;
            leftBoxes[2, 2] = textBox11;
            leftBoxes[2, 3] = textBox12;

            leftBoxes[3, 0] = textBox13;
            leftBoxes[3, 1] = textBox14;
            leftBoxes[3, 2] = textBox15;
            leftBoxes[3, 3] = textBox16;

            //---

            rightBoxes[0, 0] = textBox33;
            rightBoxes[0, 1] = textBox34;
            rightBoxes[0, 2] = textBox35;
            rightBoxes[0, 3] = textBox36;

            rightBoxes[1, 0] = textBox37;
            rightBoxes[1, 1] = textBox38;
            rightBoxes[1, 2] = textBox39;
            rightBoxes[1, 3] = textBox40;

            rightBoxes[2, 0] = textBox41;
            rightBoxes[2, 1] = textBox42;
            rightBoxes[2, 2] = textBox43;
            rightBoxes[2, 3] = textBox44;

            rightBoxes[3, 0] = textBox45;
            rightBoxes[3, 1] = textBox46;
            rightBoxes[3, 2] = textBox47;
            rightBoxes[3, 3] = textBox48;


            comboBox1.Items.Add("Число");
            comboBox1.Items.Add("Вектор 2х2");
            comboBox1.Items.Add("Вектор 3х3");
            comboBox1.Items.Add("Вектор 4х4");
            comboBox1.Items.Add("Матрица 2х2");
            comboBox1.Items.Add("Матрица 3х3");
            comboBox1.Items.Add("Матрица 4х4");
            comboBox1.SelectedIndex = 0;

            menuStrip1.Items[0].Click += OpenHelp;
            menuStrip1.Items[1].Click += ClearAllBoxes;
        }
        void ClearAllBoxes(object sender, EventArgs e)
        {
            ClearBoxes(leftBoxes);
            ClearBoxes(centerBoxes);
            ClearBoxes(rightBoxes);
        }
        void OpenHelp(object sender, EventArgs e)
        {
            Help help = new Help(this);
            help.Show();
        }
        private bool ValidateTextBoxes(TextBox[,] which)
        {
            bool result = true; ;
            foreach(var item in which)
            {
                double t;
                item.BackColor = Color.White;
                if (!double.TryParse(item.Text, out t))
                {
                    if (t.ToString() != item.Text)
                    {
                        result = false;
                        item.BackColor = Color.Red;
                    }
                }
            }
            return result;
        }
        private void ShowVector2(TextBox[,] which)
        {
            HideAll(which);
            which[0, 0].Enabled = true;
            which[0, 1].Enabled = true;
        }
        private void ShowVector3(TextBox[,] which)
        {
            ShowVector2(which);
            which[0, 2].Enabled = true;
        }
        private void ShowVector4(TextBox[,] which)
        {
            ShowVector3(which);
            which[0, 3].Enabled = true;
        }
        private void ShowMatrix2(TextBox[,] which)
        {
            ShowVector2(which);
            which[1, 0].Enabled = true;
            which[1, 1].Enabled = true;
        }
        private void ShowMatrix3(TextBox[,] which)
        {
            ShowVector3(which);
            which[1, 0].Enabled = true;
            which[1, 1].Enabled = true;
            which[1, 2].Enabled = true;
            which[2, 0].Enabled = true;
            which[2, 1].Enabled = true;
            which[2, 2].Enabled = true;
        }
        private void ShowMatrix4(TextBox[,] which)
        {
            ShowMatrix3(which);
            which[0, 3].Enabled = true;
            which[1, 3].Enabled = true;
            which[2, 3].Enabled = true;

            which[3, 0].Enabled = true;
            which[3, 1].Enabled = true;
            which[3, 2].Enabled = true;
            which[3, 3].Enabled = true;
        }
        private void HideAll(TextBox[,] which)
        {
            foreach(TextBox item in which)
            {
                item.Enabled = false;
            }
        }
        private void ClearBoxes(TextBox[,] which)
        {
            foreach (TextBox item in which)
            {
                item.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes(leftBoxes) && ValidateTextBoxes(centerBoxes))
            {
                ClearBoxes(rightBoxes);
                switch (comboBox1.Text)
                {
                    case "Число":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 2х2":
                                    {
                                        //умножить
                                        ShowVector2(rightBoxes);
                                        Vector2 vec = (Vector2)Vector2Creator.Create(centerBoxes);
                                        double ertt = Convert.ToDouble(textBox1.Text);
                                        vec = vec * Convert.ToDouble(textBox1.Text);
                                        vec.Show(rightBoxes);

                                        drawVector3.X = vec.X;
                                        drawVector3.Y = vec.Y;
                                        drawVector3.Z = 0;

                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();

                                        break;
                                    }
                                case "Вектор 3х3":
                                    {
                                        //умножить
                                        ShowVector3(rightBoxes);
                                        Vector3 vec = (Vector3)Vector3Creator.Create(centerBoxes);
                                        vec = vec * Convert.ToDouble(textBox1.Text);
                                        vec.Show(rightBoxes);
                                        drawVector3 = vec;
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        break;
                                    }
                                case "Вектор 4х4":
                                    {
                                        //умножить
                                        ShowVector4(rightBoxes);
                                        Vector4 vec = (Vector4)Vector4Creator.Create(centerBoxes);
                                        vec = vec * Convert.ToDouble(textBox1.Text);
                                        vec.Show(rightBoxes);
                                        drawVector3 = (Vector3)vec;
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        break;
                                    }
                                case "Матрица 2х2":
                                    {
                                        //умножить
                                        ShowMatrix2(rightBoxes);
                                        Matrix2 mat = (Matrix2)Matrix2Creator.Create(centerBoxes);
                                        mat = mat * Convert.ToDouble(textBox1.Text);
                                        mat.Show(rightBoxes);
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        break;
                                    }
                                case "Матрица 3х3":
                                    {
                                        //умножить
                                        ShowMatrix3(rightBoxes);
                                        Matrix3 mat = (Matrix3)Matrix3Creator.Create(centerBoxes);
                                        mat = mat * Convert.ToDouble(textBox1.Text);
                                        mat.Show(rightBoxes);
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        break;
                                    }
                                case "Матрица 4х4":
                                    {
                                        //умножить
                                        ShowMatrix4(rightBoxes);
                                        Matrix4 mat = (Matrix4)Matrix4Creator.Create(centerBoxes);
                                        mat = mat * Convert.ToDouble(textBox1.Text);
                                        mat.Show(rightBoxes);
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        break;
                                    }
                                case "Число":
                                    {
                                        //умножить
                                        //сложить
                                        //вычесть
                                        HideAll(rightBoxes);
                                        textBox33.Enabled = true;
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        switch (comboBox2.Text)
                                        {
                                            case "Умножить":
                                                {
                                                    textBox33.Text = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox17.Text)).ToString();
                                                    break;
                                                }
                                            case "Сложить":
                                                {
                                                    textBox33.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox17.Text)).ToString();
                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    textBox33.Text = (Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox17.Text)).ToString();
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Вектор 2х2":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 2х2":
                                    {
                                        ShowVector2(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Vector2 vec1 = (Vector2)Vector2Creator.Create(leftBoxes);
                                                    Vector2 vec2 = (Vector2)Vector2Creator.Create(centerBoxes);
                                                    Vector2 vec = vec1 + vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1.X = vec1.X;
                                                    drawVector1.Y = vec1.Y;
                                                    drawVector1.Z = 0;

                                                    drawVector2.X = vec2.X;
                                                    drawVector2.Y = vec2.Y;
                                                    drawVector2.Z = 0;

                                                    drawVector3.X = vec.X;
                                                    drawVector3.Y = vec.Y;
                                                    drawVector3.Z = 0;

                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Vector2 vec1 = (Vector2)Vector2Creator.Create(leftBoxes);
                                                    Vector2 vec2 = (Vector2)Vector2Creator.Create(centerBoxes);
                                                    Vector2 vec = vec1 - vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1.X = vec1.X;
                                                    drawVector1.Y = vec1.Y;
                                                    drawVector1.Z = 0;

                                                    drawVector2.X = vec2.X;
                                                    drawVector2.Y = vec2.Y;
                                                    drawVector2.Z = 0;

                                                    drawVector3.X = vec.X;
                                                    drawVector3.Y = vec.Y;
                                                    drawVector3.Z = 0;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Число":
                                    {
                                        ShowVector2(rightBoxes);
                                        Vector2 vec1 = (Vector2)Vector2Creator.Create(leftBoxes);
                                        Vector2 vec = vec1 * Convert.ToDouble(textBox17.Text); 
                                        vec.Show(rightBoxes);
                                        drawVector1.X = vec1.X;
                                        drawVector1.Y = vec1.Y;
                                        drawVector1.Z = 0;

                                        drawVector2.X = 0;
                                        drawVector2.Y = 0;
                                        drawVector2.Z = 0;

                                        drawVector3.X = vec.X;
                                        drawVector3.Y = vec.Y;
                                        drawVector3.Z = 0;
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Вектор 3х3":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 3х3":
                                    {
                                        ShowVector3(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Vector3 vec1 = (Vector3)Vector3Creator.Create(leftBoxes);
                                                    Vector3 vec2 = (Vector3)Vector3Creator.Create(centerBoxes);
                                                    Vector3 vec = vec1 + vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1 = vec1;
                                                    drawVector2 = vec2;
                                                    drawVector3 = vec;

                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Vector3 vec1 = (Vector3)Vector3Creator.Create(leftBoxes);
                                                    Vector3 vec2 = (Vector3)Vector3Creator.Create(centerBoxes);
                                                    Vector3 vec = vec1 - vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1 = vec1;
                                                    drawVector2 = vec2;
                                                    drawVector3 = vec;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Число":
                                    {
                                        ShowVector3(rightBoxes);
                                        Vector3 vec1 = (Vector3)Vector3Creator.Create(leftBoxes);
                                        Vector3 vec = vec1 * Convert.ToDouble(textBox17.Text); ;
                                        vec.Show(rightBoxes);

                                        drawVector1 = vec1;
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = vec;
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Вектор 4х4":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 4х4":
                                    {
                                        ShowVector4(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Vector4 vec1 = (Vector4)Vector4Creator.Create(leftBoxes);
                                                    Vector4 vec2 = (Vector4)Vector4Creator.Create(centerBoxes);
                                                    Vector4 vec = vec1 + vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1 = (Vector3)vec1;
                                                    drawVector2 = (Vector3)vec2;
                                                    drawVector3 = (Vector3)vec;
                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Vector4 vec1 = (Vector4)Vector4Creator.Create(leftBoxes);
                                                    Vector4 vec2 = (Vector4)Vector4Creator.Create(centerBoxes);
                                                    Vector4 vec = vec1 - vec2;
                                                    vec.Show(rightBoxes);
                                                    drawVector1 = (Vector3)vec1;
                                                    drawVector2 = (Vector3)vec2;
                                                    drawVector3 = (Vector3)vec;
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Число":
                                    {
                                        ShowVector4(rightBoxes);
                                        Vector4 vec1 = (Vector4)Vector4Creator.Create(leftBoxes);
                                        Vector4 vec = vec1 * Convert.ToDouble(textBox17.Text); ;
                                        vec.Show(rightBoxes);

                                        drawVector1 = (Vector3)vec1;
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)vec;
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Матрица 2х2":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 2х2":
                                    {
                                        ShowVector2(rightBoxes);
                                        Vector2 vec1 = (Vector2)Vector2Creator.Create(centerBoxes);
                                        Vector2 vec = (Matrix2)Matrix2Creator.Create(leftBoxes) * vec1;
                                        vec.Show(rightBoxes);

                                        drawVector1 = (Vector3)Vector3Creator.Create();

                                        drawVector2.X = vec1.X;
                                        drawVector2.Y = vec1.Y;
                                        drawVector2.Z = 0;

                                        drawVector3.X = vec.X;
                                        drawVector3.Y = vec.Y;
                                        drawVector3.Z = 0;
                                        //умножить
                                        break;
                                    }
                                case "Матрица 2х2":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix2(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Matrix2 mat = (Matrix2)Matrix2Creator.Create(leftBoxes) + (Matrix2)Matrix2Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Matrix2 mat = (Matrix2)Matrix2Creator.Create(leftBoxes) - (Matrix2)Matrix2Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                            case "Умножить":
                                                {
                                                    Matrix2 mat = (Matrix2)Matrix2Creator.Create(leftBoxes) * (Matrix2)Matrix2Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                        }
                                        //умножить
                                        //сложить
                                        //вычесть
                                        break;
                                    }
                                case "Число":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix2(rightBoxes);
                                        Matrix2 mat = (Matrix2)Matrix2Creator.Create(leftBoxes) * Convert.ToDouble(textBox17.Text);
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Матрица 3х3":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 3х3":
                                    {
                                        ShowVector3(rightBoxes);
                                        Vector3 vec1 = (Vector3)Vector3Creator.Create(centerBoxes);
                                        Vector3 vec = (Matrix3)Matrix3Creator.Create(leftBoxes) * vec1;
                                        vec.Show(rightBoxes);
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = vec1;
                                        drawVector3 = vec;
                                        //умножить
                                        break;
                                    }
                                case "Матрица 3х3":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix3(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Matrix3 mat = (Matrix3)Matrix3Creator.Create(leftBoxes) + (Matrix3)Matrix3Creator.Create(centerBoxes);
                                                    mat.Show(leftBoxes);
                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Matrix3 mat = (Matrix3)Matrix3Creator.Create(leftBoxes) - (Matrix3)Matrix3Creator.Create(centerBoxes);
                                                    mat.Show(leftBoxes);
                                                    break;
                                                }
                                            case "Умножить":
                                                {
                                                    Matrix3 mat = (Matrix3)Matrix3Creator.Create(leftBoxes) * (Matrix3)Matrix3Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                        }
                                        //умножить
                                        //сложить
                                        //вычесть
                                        break;
                                    }
                                case "Число":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix3(rightBoxes);
                                        Matrix3 mat = (Matrix3)Matrix3Creator.Create(leftBoxes) * Convert.ToDouble(textBox17.Text); ;
                                        mat.Show(leftBoxes);
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Матрица 4х4":
                        {
                            switch (comboBox3.Text)
                            {
                                case "Вектор 4х4":
                                    {
                                        ShowVector4(rightBoxes);
                                        Vector4 vec1 = (Vector4)Vector4Creator.Create(centerBoxes);
                                        Vector4 vec = (Matrix4)Matrix4Creator.Create(leftBoxes) * vec1;
                                        vec.Show(rightBoxes);
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)vec1;
                                        drawVector3 = (Vector3)vec;
                                        //умножить
                                        break;
                                    }
                                case "Матрица 4х4":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix4(rightBoxes);
                                        switch (comboBox2.Text)
                                        {
                                            case "Сложить":
                                                {
                                                    Matrix4 mat = (Matrix4)Matrix4Creator.Create(leftBoxes) + (Matrix4)Matrix4Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                            case "Вычесть":
                                                {
                                                    Matrix4 mat = (Matrix4)Matrix4Creator.Create(leftBoxes) - (Matrix4)Matrix4Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                            case "Умножить":
                                                {
                                                    Matrix4 mat = (Matrix4)Matrix4Creator.Create(leftBoxes) * (Matrix4)Matrix4Creator.Create(centerBoxes);
                                                    mat.Show(rightBoxes);
                                                    break;
                                                }
                                        }
                                        //умножить
                                        //сложить
                                        //вычесть
                                        break;
                                    }
                                case "Число":
                                    {
                                        drawVector1 = (Vector3)Vector3Creator.Create();
                                        drawVector2 = (Vector3)Vector3Creator.Create();
                                        drawVector3 = (Vector3)Vector3Creator.Create();
                                        ShowMatrix4(rightBoxes);
                                        Matrix4 mat = (Matrix4)Matrix4Creator.Create(leftBoxes) * Convert.ToDouble(textBox17.Text); ;
                                        mat.Show(leftBoxes);
                                        //умножить
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBoxes(leftBoxes);
            ClearBoxes(centerBoxes);
            ClearBoxes(rightBoxes);
            ValidateTextBoxes(leftBoxes);
            ValidateTextBoxes(centerBoxes);
            comboBox3.Items.Clear();

            switch (comboBox1.Text)
            {
                case "Число":
                    {
                        HideAll(leftBoxes);
                        comboBox3.Items.Add("Вектор 2х2");
                        comboBox3.Items.Add("Вектор 3х3");
                        comboBox3.Items.Add("Вектор 4х4");
                        comboBox3.Items.Add("Матрица 2х2");
                        comboBox3.Items.Add("Матрица 3х3");
                        comboBox3.Items.Add("Матрица 4х4");
                        textBox1.Enabled = true;
                        break;
                    }
                case "Вектор 2х2":
                    {
                        comboBox3.Items.Add("Вектор 2х2");
                        ShowVector2(leftBoxes);
                        //groupBox6.Visible = true;
                        break;
                    }
                case "Вектор 3х3":
                    {
                        comboBox3.Items.Add("Вектор 3х3");
                        ShowVector3(leftBoxes);
                        //roupBox5.Visible = true;
                        break;
                    }
                case "Вектор 4х4":
                    {
                        comboBox3.Items.Add("Вектор 4х4");
                        ShowVector4(leftBoxes);
                        //groupBox2.Visible = true;
                        break;
                    }
                case "Матрица 2х2":
                    {
                        comboBox3.Items.Add("Вектор 2х2");
                        comboBox3.Items.Add("Матрица 2х2");
                        ShowMatrix2(leftBoxes);
                        //groupBox4.Visible = true;
                        break;
                    }
                case "Матрица 3х3":
                    {
                        comboBox3.Items.Add("Вектор 3х3");
                        comboBox3.Items.Add("Матрица 3х3");
                        ShowMatrix3(leftBoxes);
                        //groupBox3.Visible = true;
                        break;
                    }
                case "Матрица 4х4":
                    {
                        comboBox3.Items.Add("Вектор 4х4");
                        comboBox3.Items.Add("Матрица 4х4");
                        ShowMatrix4(leftBoxes);
                        ///groupBox1.Visible = true;
                        break;
                    }
            }
            comboBox3.Items.Add("Число");
            comboBox3.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBoxes(leftBoxes);
            ClearBoxes(centerBoxes);
            ClearBoxes(rightBoxes);
            ValidateTextBoxes(leftBoxes);
            ValidateTextBoxes(centerBoxes);
            comboBox2.Items.Clear();
            switch (comboBox3.Text)
            {
                case "Число":
                    {
                        HideAll(centerBoxes);
                        textBox17.Enabled = true;
                        switch(comboBox1.Text)
                        {
                            case "Вектор 2х2":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Вектор 3х3":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Вектор 4х4":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Матрица 2х2":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Матрица 3х3":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Матрица 4х4":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Вектор 2х2":
                    {
                        ShowVector2(centerBoxes);
                        switch (comboBox1.Text)
                        {
                            case "Вектор 2х2":
                                {
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Матрица 2х2":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Вектор 3х3":
                    {
                        ShowVector3(centerBoxes);

                        switch (comboBox1.Text)
                        {
                            case "Вектор 3х3":
                                {
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Матрица 3х3":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Вектор 4х4":
                    {
                        ShowVector4(centerBoxes);

                        switch (comboBox1.Text)
                        {
                            case "Вектор 4х4":
                                {
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Матрица 4х4":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Матрица 2х2":
                    {
                        ShowMatrix2(centerBoxes);

                        switch (comboBox1.Text)
                        {
                            case "Матрица 2х2":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Матрица 3х3":
                    {
                        ShowMatrix3(centerBoxes);

                        switch (comboBox1.Text)
                        {
                            case "Матрица 3х3":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
                case "Матрица 4х4":
                    {
                        ShowMatrix4(centerBoxes);

                        switch (comboBox1.Text)
                        {
                            case "Матрица 4х4":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    comboBox2.Items.Add("Сложить");
                                    comboBox2.Items.Add("Вычесть");
                                    break;
                                }
                            case "Число":
                                {
                                    comboBox2.Items.Add("Умножить");
                                    break;
                                }
                        }
                        comboBox2.SelectedIndex = 0;
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) && !Char.IsControl(number) && !(number == '-') && !(number == ','))
            {
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBoxes(leftBoxes);
            ClearBoxes(centerBoxes);
            ClearBoxes(rightBoxes);
            ValidateTextBoxes(leftBoxes);
            ValidateTextBoxes(centerBoxes);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openGLControl2_OpenGLDraw(object sender, RenderEventArgs args)
        {

            OpenGL gl = this.openGLControl2.OpenGL;
            gl.ClearColor(0.94f, 0.94f, 0.94f, 0.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();

            // Двигаем перо вглубь экрана
            gl.Translate(0.0f, 0.0f, -5.0f);
            gl.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(angleY, 0.0f, 1.0f, 0.0f);

            gl.LineWidth(1);
            //Ось X
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(-100, 0, 0);
            gl.Vertex(100, 0, 0);
            gl.End();
            //Ось Y
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, -100, 0);
            gl.Vertex(0, 100, 0);
            gl.End();
            //Ось Z
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, 0, -100);
            gl.Vertex(0, 0, 100);
            gl.End();
            gl.LineWidth(3);
            gl.Color(0f, 0f, 1f);
            switch (comboBox3.Text)
            {
                case "Вектор 2х2":
                    {
                        double t;
                        if (double.TryParse(centerBoxes[0, 0].Text, out t) && double.TryParse(centerBoxes[0, 1].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(centerBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(centerBoxes[0, 1].Text)));
                            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(centerBoxes[0, 0].Text), Convert.ToDouble(centerBoxes[0, 1].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
                case "Вектор 3х3":
                    {
                        double t;
                        if (double.TryParse(centerBoxes[0, 0].Text, out t) && double.TryParse(centerBoxes[0, 1].Text, out t) && double.TryParse(centerBoxes[0, 2].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(centerBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(centerBoxes[0, 1].Text)), Math.Abs(Convert.ToDouble(centerBoxes[0, 2].Text)));
                            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(centerBoxes[0, 0].Text), Convert.ToDouble(centerBoxes[0, 1].Text), Convert.ToDouble(centerBoxes[0, 2].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
                case "Вектор 4х4":
                    {
                        double t;
                        if (double.TryParse(centerBoxes[0, 0].Text, out t) && double.TryParse(centerBoxes[0, 1].Text, out t) && double.TryParse(centerBoxes[0, 2].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(centerBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(centerBoxes[0, 1].Text)), Math.Abs(Convert.ToDouble(centerBoxes[0, 2].Text)));
                            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(centerBoxes[0, 0].Text), Convert.ToDouble(centerBoxes[0, 1].Text), Convert.ToDouble(centerBoxes[0, 2].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
            }
        }

        public double MaxParams(params double[] list)
        {
            double result =list[0] ;
            for(int i=0;i<list.Length;i++)
            {
                if (list[i] >= result) result = list[i];
            }
            return result;
        }

        private void openGLControl3_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl3.OpenGL;
            gl.ClearColor(0.94f, 0.94f, 0.94f, 0.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();

            // Двигаем перо вглубь экрана
            gl.Translate(0.0f, 0.0f, -5.0f);
            gl.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(angleY, 0.0f, 1.0f, 0.0f);

            gl.LineWidth(1);
            //Ось X
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(-100, 0, 0);
            gl.Vertex(100, 0, 0);
            gl.End();
            //Ось Y
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, -100, 0);
            gl.Vertex(0, 100, 0);
            gl.End();
            //Ось Z
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, 0, -100);
            gl.Vertex(0, 0, 100);
            gl.End();

            gl.LineWidth(3);
            gl.Color(1f, 0f, 0f);

            double scale = MaxParams(drawVector1.X, drawVector1.Y, drawVector1.Z, drawVector2.X, drawVector2.Y, drawVector2.Z, drawVector3.X, drawVector3.Y, drawVector3.Z);
            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);


            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1f, 0f, 0f);
            gl.Vertex(drawVector1.X, drawVector1.Y, drawVector1.Z);
            gl.Vertex(0f, 0f,0f);
            gl.Color(0f, 0f, 1f);
            gl.Vertex(drawVector2.X, drawVector2.Y, drawVector2.Z);
            gl.Vertex(0f, 0f, 0f);
            gl.Color(0f, 1f, 0f);
            gl.Vertex(drawVector3.X, drawVector3.Y, drawVector3.Z);
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(0f, 0f);

            gl.End();

        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            angleX = 20;
            angleY += 4;
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.ClearColor(0.94f, 0.94f, 0.94f, 0.0f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();

            gl.Translate(0.0f, 0.0f, -5.0f);
            gl.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(angleY, 0.0f, 1.0f, 0.0f);

            gl.LineWidth(1);
            //Ось X
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(-100,0,0);
            gl.Vertex(100, 0, 0);
            gl.End();
            //Ось Y
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, -100, 0);
            gl.Vertex(0, 100, 0);
            gl.End();
            //Ось Z
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 0f, 0f);
            gl.Vertex(0, 0, -100);
            gl.Vertex(0, 0, 100);
            gl.End();

            gl.LineWidth(3);
            gl.Color(1f, 0f, 0f);
            switch (comboBox1.Text)
            {
                case "Вектор 2х2":
                    {
                        double t;
                        if(double.TryParse(leftBoxes[0,0].Text,out t) && double.TryParse(leftBoxes[0, 1].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(leftBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(leftBoxes[0, 1].Text)));
                            gl.Scale(1.5/scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(leftBoxes[0, 0].Text), Convert.ToDouble(leftBoxes[0, 1].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
                case "Вектор 3х3":
                    {
                        double t;
                        if (double.TryParse(leftBoxes[0, 0].Text, out t) && double.TryParse(leftBoxes[0, 1].Text, out t) && double.TryParse(leftBoxes[0, 2].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(leftBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(leftBoxes[0, 1].Text)), Math.Abs(Convert.ToDouble(leftBoxes[0, 2].Text)));
                            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(leftBoxes[0, 0].Text), Convert.ToDouble(leftBoxes[0, 1].Text), Convert.ToDouble(leftBoxes[0, 2].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
                case "Вектор 4х4":
                    {
                        double t;
                        if (double.TryParse(leftBoxes[0, 0].Text, out t) && double.TryParse(leftBoxes[0, 1].Text, out t) && double.TryParse(leftBoxes[0, 2].Text, out t))
                        {
                            double scale = MaxParams(Math.Abs(Convert.ToDouble(leftBoxes[0, 0].Text)), Math.Abs(Convert.ToDouble(leftBoxes[0, 1].Text)), Math.Abs(Convert.ToDouble(leftBoxes[0, 2].Text)));
                            gl.Scale(1.5 / scale, 1.5 / scale, 1.5 / scale);
                            gl.Begin(OpenGL.GL_LINES);
                            gl.Vertex(Convert.ToDouble(leftBoxes[0, 0].Text), Convert.ToDouble(leftBoxes[0, 1].Text), Convert.ToDouble(leftBoxes[0, 2].Text));
                            gl.Vertex(0f, 0f);
                            gl.End();
                        }
                        break;
                    }
            }


        }
    }
}
