using Elevens.Core;

Card card = new Card(1, Suit.Hearts);
Console.WriteLine(card.ToString());
Deck deck = new Deck();
deck.Shuffle();
Card drawCard = deck.DealCard();

Console.WriteLine($"Drawn card: {drawCard}");
Console.WriteLine($"Cards remaining: {deck.Count}");
