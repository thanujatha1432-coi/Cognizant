using System;

class Logger
{
    private static Logger instance;

    private Logger()
    {
        Console.WriteLine("Logger object created");
    }

    public static Logger GetInstance()
    {
        if (instance == null)
            instance = new Logger();

        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger obj1 = Logger.GetInstance();
        obj1.Log("First message");

        Logger obj2 = Logger.GetInstance();
        obj2.Log("Second message");

        if (obj1 == obj2)
            Console.WriteLine("Both are same object");
    }
}
