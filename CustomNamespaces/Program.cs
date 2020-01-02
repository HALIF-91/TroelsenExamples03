using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
using Chapter14.My3DShapes;

// устранить неодназначность, используя специальный псевдоним
using The3DHexagon = Chapter14.My3DShapes.Hexagon;

namespace CustomNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // для устранения неоднозначностей
            Chapter14.My3DShapes.Hexagon h = new Chapter14.My3DShapes.Hexagon();
            Chapter14.My3DShapes.Circle с = new Chapter14.My3DShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();

            // Это на самом деле создает экземпляр класс My3DShapes.Hexagon
            The3DHexagon h2 = new The3DHexagon();
        }
    }
}
/*
 Если в свойствах проекта изменить название стандартного пространства имен, любой новый элемент, вставляемый в проект, будет размещаться внутри нового пространства имен
     */