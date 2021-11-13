using System;

namespace RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            var rubiksCode = new Features.RubiksCube.RubiksCube();
            Console.WriteLine(rubiksCode.PrintState());
            Console.WriteLine("Please hit 'Enter' to apply the required rotations to this Rubik's Cube");
            Console.ReadLine();

            rubiksCode.ApplyRequiredFaceRotations();
            Console.WriteLine(rubiksCode.PrintState());
            Console.WriteLine("Please hit 'Enter' to exit");
            Console.ReadLine();
            return;
        }
    }
}
