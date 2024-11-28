using System;

/* У цьому коді порушено принцип Liskov Substitution Principle */

// Виправлений код(з додатковим урахуванням Open Closed Principle):
interface IShape
{
    double GetArea();
}
class Rectangle : IShape
{
    private double width;
    private double height;
    public Rectangle(double Width, double Height) { width = Width; height = Height; }
    public double GetArea() { return width * height; }
}

class Square : IShape
{
    private double side;
    public Square(double Side) { side = Side; }
    public double GetArea() { return side * side; }
}

class Circle : IShape
{
    private double radius;
    public Circle(double Radius) { radius = Radius; }
    public double GetArea() { return Math.PI * radius * radius; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Rectangle rect = new Rectangle(4.5, 7.4);
        Square square = new Square(4.8);
        Circle circle = new Circle(3.8);

        Console.WriteLine($"Площа прямокутника: {rect.GetArea()}" +
                          $"\nПлоща квадрата: {square.GetArea()}" +
                          $"\nПлоща круга: {circle.GetArea()}");

        Console.ReadKey();
    }
}