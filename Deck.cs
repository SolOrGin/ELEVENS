using System;
using System.Collections.Generic;

public class Deck
{
    private List <Card> cards = new List<Card>();
    // so we create a private list of CArds
    // then our deck is created by looping through the four suits and 13 values of cards to create our Deck

    
    public Deck ()
    {
        for (int i = 0; i < Card.Suits.Length; i++ )
        {
            for (int j = 0; j < Card.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i], Card.Values[j]));

            }
        }
        Shuffle(); // so after loading ordered deck we now have our shuffle method so we can shuffle our deck
    }

    // is the shuffle returning a value? public or private? and the how are we shuffling these cards? our deck is a list of variable cards
    // since we dont need to access this shuffle funtion, we dont care to show it to the public, this is something the spawn of the deck takes care of

    private Random rng = new Random();
    private void Shuffle()
    {
        /*AI says that we need to divide our list into two, one side that is shuffled and the other unshuffled
        and it doesnt matter where we start but it looks cleaner if we start from the end. 
        begin from the last card and work our way down

        */
        for (int i = cards.Count - 1; i > 0; i--)
        {
            /* i is the end of the unshuffled deck so in this case since we have 52 cards our end right now is 52
               then we randomly select a card from the unshuffled deck and that cards value is stored onto j but we need to swap


            */
            int j = rng.Next(i + 1);

            Card temp = cards[i];  // we move this card that is located at the end of the deck onto a seperate place
            cards[i] = cards[j];   // then we move the card that was selected onto the last position of the deck
            cards[j] = temp;      // now that empty space where we took the card from is replaced with the card that was moved to the side
                                  // we continue to do this until we have all cards shuffled


        }

    }

    // for the deal what are we dealing? what are we doing and what are we returning?
    // we are dealing cards, we are dealing 9 cards ... but are we dealing the cards here? isnt the table taking care of this?
    //

    public Card deal()
    {

    }





         

}