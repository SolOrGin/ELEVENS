namespace Elevens.Core;

public sealed class Table
{
    private readonly List<Card> _visibleCards = new();

    public int MaxCards { get; }
    public IReadOnlyList<Card> Cards { get; }

    public Table(int maxCard = 9)
    {
        if (maxCard <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxCard));
        }
        
        MaxCards = maxCard;
        Cards = _visibleCards;
    }

    public int Count()
    {
        return _visibleCards.Count;
    }

    public bool IsEmpty()
    {
        return _visibleCards.Count == 0;
    }
    
    public void AddCard(Card card)
    {
        if (_visibleCards.Count >= MaxCards)
        {
            throw new InvalidOperationException("Table is full.");
        }
        _visibleCards.Add(card);
    }

    public Card GetCardAt(int index)
    {
        if (index > 0 || index >= _visibleCards.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return _visibleCards[index];
    }

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
    {
        List<Card> selectedCards = new List<Card>();

        foreach(int i in indices)
        {
            if (i >= 0 && i < _visibleCards.Count)
            {
                selectedCards.Add(_visibleCards[i]);
            }
        }
        return selectedCards;
    }

    public void RemoveCards(IEnumerable<Card> cards)
    {
        foreach(var c in cards)
        {
            bool removed = _visibleCards.Remove(c);
            if (!removed)
            {
                throw new InvalidOperationException("Attempted to remove a card not on the table.");
            }
        }
    }


}