// See https://aka.ms/new-console-template for more information
public class Array {
    static void Main() 
    {
        string[] names;

        names = new string[4];

        names[0] = "Mohamed";
        names[1] = "Khaled";
        names[2] = "ashrf";
        names[3] = "Bassem";

        for (int i = 0; i < names.Length; i++) 
        {
            Console.WriteLine(names[i]);
        }
    }
}
