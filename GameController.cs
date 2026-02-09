public class gameController
{
    public int getSelection()
    {
        return selection;
    }
    public bool validateSelection(List<Card> selectedCards)
    {
        
        
        if (selectedCards.Count == 2)
        {
           int total = selectedCards[0].getValue() + selectedCards[1].getValue();
           return total == 11;
            
        }
        
        if (selectedCards.Count == 3)
        {
            /*Going off the advice given for this I need the out to be true or false based on the rule that the three cards selected have to be
            a jack, a queen and a king. So I need these three to be in the selection

            */
            //bool hasJack, hasQueen, hasKing; //however this is just having an empty container, I need it to check if these values are true but as of right now they have no value
            bool hasJack = false;
            bool hasQueen = false;
            bool hasKing = false;

            //Now I want to check the cards one by one and see if they are true, remember I am checking the class object hard in the selectedCards

            foreach (Card card in selectedCards)
            {
                // Now that I have the first card in my hand I want to check the values 
                if (card.getValue() == 11)
                {
                    //I check the card to see if it has a value of 11 which is the jack and if so then that means our original state of not having a jack now becomes true
                    hasJack = true;
                }
                else if (card.getValue() == 12)
                {
                    hasQueen = true;
                }
                else if (card.getValue() == 13)
                {
                    hasKing = true;
                }
            }
            // then the output needs to be all three cards, if one of them if false then the return will be false so like booleans work I need the jack AND queen AND king to be true

                return hasJack && hasQueen && hasKing;

        }
            //then if none of these conditions are met, then the selection is cannot be validated
            return false;
        
    }


}

/*My suggestion is to first clearly define what this method is responsible for.
Start by identifying the inputs: what data do you need, where does it come from, and should it be passed in as parameters or stored as class variables?
Next, think about the output of the method.
Only after that should you design the internal logic—how to use and transform the input data to produce the desired result.

When you want to use another class inside a class, you should work with an object of that class, and call its methods through the object,
instead of trying to use the class itself as a value.
*/


//stop and think what the value you are using for the function first

//First think about where the data is coming from and what does it need to be and then where the data is going