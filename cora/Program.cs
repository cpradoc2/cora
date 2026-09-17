using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        int ancho = Math.Min(Console.WindowWidth - 2, 100);
        int alto = Math.Min(Console.WindowHeight - 2, 40);

        double centroX = ancho / 2.0;
        double centroY = alto / 2.0;

        ConsoleColor[] colores =
        {
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.White
        };

        double rotacion = 0;

        while (true)
        {
            Console.Clear();

            int cantidad = 80;

            for (int i = 0; i < cantidad; i++)
            {
                
                double t = 2 * Math.PI * i / cantidad;

                
                double x = 16 * Math.Pow(Math.Sin(t), 3);

                double y =
                    13 * Math.Cos(t)
                    - 5 * Math.Cos(2 * t)
                    - 2 * Math.Cos(3 * t)
                    - Math.Cos(4 * t);

                
                x *= 1.8;
                y *= 0.8;

                
                double nuevoX =
                    x * Math.Cos(rotacion) -
                    y * Math.Sin(rotacion);

                double nuevoY =
                    x * Math.Sin(rotacion) +
                    y * Math.Cos(rotacion);

                int destinoX =
                    (int)(centroX + nuevoX);

                int destinoY =
                    (int)(centroY - nuevoY);

                DibujarLinea(
                    (int)centroX,
                    (int)centroY,
                    destinoX,
                    destinoY,
                    colores[i % colores.Length]
                );
            }

            
            rotacion += 0.005;

            Thread.Sleep(100);
        }
    }

    static void DibujarLinea(
        int x1,
        int y1,
        int x2,
        int y2,
        ConsoleColor color)
    {
        int pasos = Math.Max(
            Math.Abs(x2 - x1),
            Math.Abs(y2 - y1)
        );

        for (int i = 0; i <= pasos; i++)
        {
            double t = pasos == 0
                ? 0
                : (double)i / pasos;

            int x = (int)(x1 + (x2 - x1) * t);
            int y = (int)(y1 + (y2 - y1) * t);

            if (x >= 0 &&
                x < Console.WindowWidth &&
                y >= 0 &&
                y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);

                Console.ForegroundColor = color;

                if (i == pasos)
                    Console.Write("♥");
                else
                    Console.Write("·");
            }
        }
    }
}