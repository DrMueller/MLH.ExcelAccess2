namespace MLH.ExcelAccess2.Models;

public class ExcelFile
{
    public ExcelFile(byte[] data)
    {
        Data = data;
    }

    public byte[] Data { get; }
}