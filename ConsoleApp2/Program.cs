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
        string examplePath = @"D:\dagbti-catalogy\First Sector\21\1323847\769813.png";
        string dirName = @"D:\dagbti-catalogy\First Sector";
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
        Console.WriteLine($"Общее кол-во файлов {hashs + nonhash}");
        Console.WriteLine($"Всего обнаружено {hashs} hash файлов и {nonhash} nonhash файлов\nУдалено {hashs} hash файлов");
    }
}