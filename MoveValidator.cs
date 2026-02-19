namespace Elevens.Core;

public sealed class MoveValidator
{
    public bool IsValidSelection(IReadOnlyList<Card> selected)
    {
        if(selected == null) return false;
        if (selected.Count == 2) return IsValidPair(selected[0], selected[1]);
        if (selected.Count == 3) return IsValidTriple(selected);
        return false;
    }

    public bool HasLegalMoves(IReadOnlyList<Card> tableCards)
    {
        if(tableCards == null || tableCards.Count == 0) return false;
        
        for(int i = 0; i < tableCards.Count; i++)
        {
            for(int j = i + 1; j < tableCards.Count; j++)
            {
                if(IsValidPair(tableCards[i], tableCards[j])) return true;
            }
        }
        bool hasJ = tableCards.Any(c => c.IsJack);
        bool hasQ = tableCards.Any(c => c.IsQueen);
        bool hasK = tableCards.Any(c => c.IsKing);


        if (hasJ && hasQ && hasK)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsValidPair(Card a, Card b)
    {
        return a.ValueForEvelen > 0 && b.ValueForEvelen > 0 && (a.ValueForEvelen + b.ValueForEvelen == 11);
    }

    private bool IsValidTriple(IReadOnlyList<Card> three)
    {
        bool hasJ = three.Any(c => c.IsJack);
        bool hasQ = three.Any(c => c.IsQueen);
        bool hasK = three.Any(c => c.IsKing);
        return hasJ && hasQ && hasK;

        /*
        bool hasJ = false; 
        hasQ = false;
        hasK = false;
        foreach(var c in three)
        {
            if(c.IsJack) hasJ = true;
            if(c.IsQueen) hasQ = true;
            if(c.IsKing) hasK = true
        }
        */
    }
}