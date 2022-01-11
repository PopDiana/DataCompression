namespace DataCompression.Interfaces
{
    public interface ICompression
    {
        int Compress(string inputURL, string outputURL);
        int Decompress(string inputURL, string outputURL);
    }
}
