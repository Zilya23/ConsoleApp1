//Шагиахметова Зиля 220п
//Содержимое каталога
using System;
using System.IO;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        string path = @"C:\Users\rysta\Desktop\uu\";
        MyDir f1 = new MyDir(path);
        f1.Print();
    }
}

class MyFile
{
    public string name;
    public string extension;
    public long size;

    public MyFile(string path)
    {
        FileInfo fileInf = new FileInfo(path);
        name = fileInf.Name;
        extension = fileInf.Extension;
        size = fileInf.Length;
    }

    public void Print()
    {
        Console.WriteLine(name);
        Console.WriteLine(extension);
        Console.WriteLine(size);
    }
}

class MyDir
{
    public string name;
    public List<MyDir> Dir = new List<MyDir>();
    public List<MyFile> Fil = new List<MyFile>();

    public MyDir(string path)
    {
        name = path;
        string[] dirs = Directory.GetDirectories(path);
        foreach (string myDir in dirs)
        {
            Dir.Add(new MyDir(myDir));
        }

        string[] files = Directory.GetFiles(path);
        foreach (string fi in files)
        {
            Fil.Add(new MyFile(fi));
        }
    }

    public void Print()
    {
        foreach (MyDir dirs in Dir)
        {
            dirs.Print();
            Console.WriteLine(dirs.name);
            Console.WriteLine();
        }

        foreach (MyFile fils in Fil)
        {
            Console.WriteLine(fils.name);
            Console.WriteLine(fils.extension);
            Console.WriteLine(fils.size);
            Console.WriteLine();
        }
    }
}