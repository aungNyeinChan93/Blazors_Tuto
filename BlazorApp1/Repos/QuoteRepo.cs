using BlazorApp1.Models;

namespace BlazorApp1.Repos
{
    public static class QuoteRepo
    {
        private static readonly List<Quote> _quotes = new List<Quote>
        {
            new Quote{Name = "Quote One",Author="susu" ,QuoteId =1},
            new Quote{Name = "Quote Two",Author="koko",QuoteId =2},
            new Quote{Name = "Quote Three",Author="jojo",QuoteId=3},
            new Quote{Name = "Quote Four",Author="mgmg",QuoteId =4}
        };

        public static List<Quote> AllQuotes()
        {
            return _quotes;
        }

        public static Quote? GetById(int id)
        {
            var quote = _quotes.FirstOrDefault(q => q.QuoteId == id);
            return quote;
        }

        public static void AddQuote(Quote quote)
        {
            _quotes.Add(quote);
        }

        public static void DeleteQuote(int id)
        {
            var quote = _quotes.FirstOrDefault(q=>q.QuoteId == id);
             _quotes.Remove(quote!);
            
        }
    }
}
