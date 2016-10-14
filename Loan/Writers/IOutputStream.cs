using Quote.Helpers;

namespace Quote.Writers
{
    public interface IOutputStream
    {
        void Write(QuoteResults quote);
        void NoQuoteMessage();
    }
}
