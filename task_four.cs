using System;
class Program
{
    // Overloaded Area methods for different shapes
    static double Area(double baseLength, double height) // Triangle
    {
        return baseLength * height * 0.5;
    }

    static double Area(double length, double width, bool isRectangle) // In overloading ran into an issue params of triangle and rec where the same so introduced a bool for distinction
    {
        return length * width;
    }

    static double Area(double radius) // Circle
    {
        return Math.PI * radius * radius;
    }

    static void Main()
    {
        const int maxAttempts = 3;
        int attempts = 0;
        bool validChoice = false;

        while (attempts < maxAttempts && !validChoice)
        {
            Console.WriteLine("Choose shape to calculate area:");
            Console.WriteLine("1. Triangle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Circle");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Triangle
                    validChoice = true;
                    Console.WriteLine("Enter base of the triangle:");
                    double triBase = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter height of the triangle:");
                    double triHeight = Convert.ToDouble(Console.ReadLine());

                    double triArea = Area(triBase, triHeight); // Call overloaded method
                    Console.WriteLine($"The area of the Triangle is: {triArea}");
                    break;

                case "2": // Rectangle
                    validChoice = true;
                    Console.WriteLine("Enter length of the rectangle:");
                    double rectLength = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter width of the rectangle:");
                    double rectWidth = Convert.ToDouble(Console.ReadLine());

                    double rectArea = Area(rectLength, rectWidth, true); // Call overloaded method
                    Console.WriteLine($"The area of the Rectangle is: {rectArea}");
                    break;

                case "3": // Circle
                    validChoice = true;
                    Console.WriteLine("Enter radius of the circle:");
                    double radius = Convert.ToDouble(Console.ReadLine());

                    double circleArea = Area(radius); // Call overloaded method
                    break;

                default:
                    attempts++;
                    Console.WriteLine($"Invalid input. {maxAttempts - attempts} attempts remaining.");
                    if (attempts == maxAttempts)
                    {
                        Console.WriteLine("No attempts remaining. Exiting the program.");
                    }
                    break;
            }
        }
    }
}
