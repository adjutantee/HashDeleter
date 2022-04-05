using System;

public class MainClass
{
    static string GetFileHash(string fileName)
    {
        var content = File.ReadAllBytes(fileName);

        return Convert.ToBase64String(content);
    }

    public static void Main()
    {
        string examplePath = @"C:\Users\Izagakhmaevra\Desktop\хеш файлы\769817.png";
        string dirName = @"C:\Users\Izagakhmaevra\Desktop\хеш файлы";
        string hash = GetFileHash(examplePath);

        string[] files = Directory.GetFiles(dirName, "*.png", SearchOption.AllDirectories);

        int hashs = 0;
        int nonhash = 0;
        foreach (string s in files)
        {
            if (GetFileHash(s) == hash)
            {
                Console.WriteLine(s);
                hashs++;
                File.Delete(s);
            } 
            else if (GetFileHash(s) != hash)
            {
                Console.WriteLine(s);
                nonhash++;
            }    
        }
        Console.WriteLine($"Всего обнаружено {hashs} hash файлов и {nonhash} nonhash файлов\nУдалено {hashs} hash файлов");
    }
}