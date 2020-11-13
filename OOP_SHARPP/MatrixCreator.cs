using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    abstract class MatrixCreator
    {
        public MatrixCreator() { }

        abstract public Matrix Create(TextBox[,] boxes);
        abstract public Matrix Create();
    }

    class Matrix2Creator
    {
        public Matrix Create(TextBox[,] boxes)
        {
            return new Matrix2(boxes);
        }
        public Matrix Create()
        {
            return new Matrix2();
        }
    }

    class Matrix3Creator
    {
        public Matrix Create(TextBox[,] boxes)
        {
            return new Matrix3(boxes);
        }
        public Matrix Create()
        {
            return new Matrix3();
        }
    }
    class Matrix4Creator
    {
        public Matrix Create(TextBox[,] boxes)
        {
            return new Matrix4(boxes);
        }
        public Matrix Create()
        {
            return new Matrix4();
        }
    }
}
