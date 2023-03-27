Console.WriteLine("Hello, I'm gonna show you some data types: \n");

string[] types = {"String", "Char", "Int", "Decimal", "Bool"};

for (int i = 1; i <= types.Length; i++)
{
    Console.WriteLine($"{i} - { types[i - 1]}");
}



