using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_SHARPP
{
    abstract class VectorCreator
    {
        public VectorCreator(){ }
        abstract public Vector Create(TextBox[,] boxes);
        abstract public Vector Create();
    }

    class Vector2Creator
    { 
        public Vector Create(TextBox[,] boxes)
        {
            return new Vector2(boxes);
        }
        public Vector Create()
        {
            return new Vector2();
        }
    }

    class Vector3Creator
    {
        public Vector Create(TextBox[,] boxes)
        {
            return new Vector3(boxes);
        }
        public Vector Create()
        {
            return new Vector3();
        }
    }

    class Vector4Creator
    {
        public Vector Create(TextBox[,] boxes)
        {
            return new Vector4(boxes);
        }
        public Vector Create()
        {
            return new Vector4();
        }
    }

}
