using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YooxExercise
{
    public class Result
    {
        public List<string> TriangleType(List<string> triangleToy)
        {

            return TriangleType(triangleToy.ToArray()).ToList();


        }

        public string[] TriangleType(string[] triangleToy)
        {
            if (triangleToy == null)
            {
                throw new ArgumentNullException(nameof(triangleToy));

            }
            if (triangleToy.Length == 0 || triangleToy.Length > 5000)
            {
                throw new ArgumentOutOfRangeException(nameof(triangleToy));

            }
            int size = triangleToy.Length;
            int StartPosition = 0;
            //check if first value contains the size, if yes and is consisten use as base for output array
            if (!triangleToy[0].Contains(" "))
            {
                if(int.TryParse(triangleToy[0], out size))
                {
                    if(size == 0 || size != triangleToy.Length - 1) //inconsistency in declared size and actual size
                    {
                        size = triangleToy.Length - 1;
                    }
                }
                //exclude the first row from input 
                StartPosition = 1;
            }
            string[] result = new string[size];
            int j = 0;
            for (int i = StartPosition; i<triangleToy.Length; i++ )
            {
                j = i - StartPosition;
                Triangle t = GetTriangle(triangleToy[i]);
                result[j] = t.TriangleType();
            }

            return result;
        }

        /// <summary>
        /// Method to get the sides size of the triangle. return the 3 sides and do a validation on input parameter
        /// Not null or empty
        /// has 3 values split by space
        /// all sides between 1 and 2000
        /// if one of the above condition is not met, the input is not valid
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public Triangle GetTriangle(string triangle)
        {
            try
            {
                Triangle result = new Triangle(); //instantiate a new Triangle with default values with validity flag to false
                if (triangle is null || string.IsNullOrEmpty(triangle)) //invalid input
                {
                    return result;
                }
                string[] sides = triangle.Trim().Split(' ');
                if (sides.Length != 3) //not enoudgh values
                {
                    return result;
                }
                int a = 0;
                int b = 0;
                int c = 0;
                int.TryParse(sides[0], out a);
                int.TryParse(sides[1], out b);
                int.TryParse(sides[2], out c);
                if (a == 0 || b == 0 || c == 0) //one of the size is 0
                {
                    return result;
                }
                if (a > 2000 || b > 2000 || c > 2000)
                {
                    return result;
                }

                //all validity check passed
                result.a = a;
                result.b = b;
                result.c = c;
                result.isValid = true;
                return result;
            }
            catch (Exception ex)
            {
                Triangle result = new Triangle();
                return result;
            }
        }


    }

    public class Triangle
    {
        public Triangle()
        {
            this.a = 0;
            this.b = 0;
            this.c = 0;
            this.isValid = false;
        }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public bool isValid { get; set; }

        public string TriangleType()
        {
            if (this.isValid)
            {
                if (this.a == this.b || this.a == this.c || this.b == this.c) //is Isosceles or Equilateral
                {
                    if (this.a == this.b && this.b == this.c) //is Equilateral
                    {
                        return "Equilateral";
                    }
                    else
                    {
                        return "Isosceles";
                    }
                }
                else
                {
                    return "None of these";
                }
            }
            else //triangle input is not valid, use "None of these" as default value
            {
                return "None of these";
            }

        }

    }

}
