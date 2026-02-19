namespace Elevens.Core;

public enum Suit{Clubs, Diamonds, Hearts, Spades}
public sealed class Card
{
    public int Rank {get;}

    public Suit Suit{get;}

    public Card(int rank, Suit suit)
    {
        if (rank<1 || rank>13)
        {
            throw new ArgumentOutOfRangeException(nameof(rank));
        }
        Rank = rank;
        Suit = suit;
    }

    public int ValueForEvelen => (Rank >= 1 && Rank <= 10) ? Rank : 0;



/* Below is fast way of writing
public bool IsJack()
{
    return Rank == 11;
}


*/
    public bool IsJack => Rank == 11;
    public bool IsQueen => Rank == 12;
    public bool IsKing => Rank == 13;

    public override string ToString()
    {
        string r = Rank switch
        {
            1 => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
            _ => Rank.ToString()
        };
    
        String suit = Suit switch
        {
            Suit.Spades => "♠️",
            Suit.Clubs => "♣️",
            Suit.Hearts => "❤️",
            Suit.Diamonds => "♦️",
            _ => "?"
        };
        return $"{r}{suit}";

    }

    


}
