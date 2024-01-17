// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


string path = @"C:\Windows\System32\drivers\etc\hosts";

main();

void main() 
{
    Console.WriteLine("===============");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.WriteLine("ACME HostEditor");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("===============");
    Console.WriteLine();
    Console.WriteLine("Please, select what you want to do:");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("1. Read HOTS");
    Console.WriteLine("2. Edit HOTS data");
    Console.WriteLine("3. Clear HOTS data");
    Console.WriteLine("4. Exit");

    Console.Write("Select an option: ");
    string option = Console.ReadLine();


    switch (option)
    {
        case "1": 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            List<string> lines = fileValues();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            main();
            break;

        case "2":
            Console.Clear();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName  = "notepad.exe",
                Arguments = path,
                Verb      = "runas",
                
            };
            Process.Start(startInfo);

            main();
            break;

        case "3":
            File.WriteAllText(path, string.Empty);
            warningOutput("Hosts deleted!");
            main();
            break;

        case "4":
            System.Environment.Exit(0);
            break;

        default: errorOutput("No ha seleccionado un valor de la lista, por favor, seleccione uno."); main(); break;

    }
}

List<string> fileValues()
{
    string[] fileContent = File.ReadAllLines(path);

    List<string> textLines = new List<string>();
    foreach (string line in fileContent)
    {
        textLines.Add(line);
    }
    return textLines;
}

void errorOutput(string message)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("Error: " + message);
    Console.BackgroundColor = ConsoleColor.Black;

}

void warningOutput(string message)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Warning!: " + message);
    Console.BackgroundColor = ConsoleColor.Black;
}
