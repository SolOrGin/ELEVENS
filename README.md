# ELEVENS
This is a simplistic card game where a deck consisting of 52 cards (A, 2 , ....10 , Jack, Queen King) is shuffled and deals 9 cards to the player facing up. The goal is to match cards in order to get to 0 remaining cards to win the game. For more details check out the READ ME


## Game Rules: 







## Steps:
Continuing from the code from class, I attended SI session where we attempted to code the validation logic for the selected cards. 
However there was a flaw in the way I was viewing things. I was attempting to pass the parameter of the array Value in the cards but instead
of thinking about it in a way of I just want the CARD I kept thinking of what was in the CARD that I want. Which isnt wrong but since we are creating a class for CARD our selections are CARD not the value. From there we can access the value that we need to do our check

### Advice from Hong: 
`My suggestion is to first clearly define what this method is responsible for.
Start by identifying the inputs: what data do you need, where does it come from, and should it be passed in as parameters or stored as class variables?
Next, think about the output of the method.
Only after that should you design the internal logic—how to use and transform the input data to produce the desired result.`

When you want to use another class inside a class, you should work with an object of that class, and call its methods through the object,
instead of trying to use the class itself as a value.

However after finishing the code for the selected cards I seem to be unorganized so first step is creating the classes. 
WE have our cards, Deck. The cards class looks fine but we need to finish Deck class before we can move on.

The Deck should have 52 cards, which was created in class but now we need to a shuffle function and also a deal function

