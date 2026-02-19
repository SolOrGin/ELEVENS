namespace Elevens.Core;
using System.Security.Cryptography;

public sealed class Deck
{
    private readonly List<Card> _cards = new();

    public int Count => _cards.Count;

    public Deck()
    {
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            for (int r = 1; r<=13; r++)
            {
                _cards.Add(new Card(r, s));
            }
        }
    }

    public bool IsEmpty()
    {
        return _cards.Count == 0;
    }

    public void Shuffle()
    {
        //Random random = new Random();
        
        for(int i = _cards.Count - 1; i > 0; i--)
        {
            
            // int j = Random.Next(0, 52);
            
            int j = RandomNumberGenerator.GetInt32(i+1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Card DealCard()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Deck is empty");
        }
        Card top = _cards[Count - 1];
        _cards.RemoveAt(Count - 1);
        return top;

    }
}