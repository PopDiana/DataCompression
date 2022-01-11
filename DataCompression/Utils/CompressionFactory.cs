using DataCompression.Interfaces;
using DataCompression.Algorithms;

namespace DataCompression
{
    public enum CompressionType
    {
        LZ4 = 0,
        Deflate = 1,
        GZip = 2,
        ZStandard = 3,
    }

    public static class CompressionFactory
    {
        public static ICompression CreateAlgorithm(CompressionType type)
        {
            switch (type)
            {
                case CompressionType.LZ4:
                    return new LZ4Compression();
                case CompressionType.Deflate:
                    return new DeflateCompression();
                case CompressionType.GZip:
                    return new GZipCompression();
                case CompressionType.ZStandard:
                    return new ZStandardCompression();
                default:
                    return null;
            }
        }
    }
}
