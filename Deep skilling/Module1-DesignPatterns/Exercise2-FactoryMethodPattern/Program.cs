using System;

interface IDocument
{
    void Open();
}

class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Word Document Opened");
    }
}

class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("PDF Document Opened");
    }
}

class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Excel Document Opened");
    }
}

class DocumentFactory
{
    public static IDocument CreateDocument(string type)
    {
        if (type == "word")
            return new WordDocument();
        else if (type == "pdf")
            return new PdfDocument();
        else if (type == "excel")
            return new ExcelDocument();
        else
            return null;
    }
}

class Program
{
    static void Main()
    {
        IDocument doc1 = DocumentFactory.CreateDocument("word");
        doc1.Open();

        IDocument doc2 = DocumentFactory.CreateDocument("pdf");
        doc2.Open();

        IDocument doc3 = DocumentFactory.CreateDocument("excel");
        doc3.Open();
    }
}