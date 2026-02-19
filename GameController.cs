namespace Elevens.Core;

public enum GameState {NotStarted, Running, Won, Lost}

public sealed class GameController
{
    private readonly Deck _deck;
    private readonly Table _table;

    private readonly MoveValidator _validator;

    public GameState State {get; private set;} = GameState.NotStarted;

    public Deck Deck => _deck;

    public Table Table => _table;

    public GameController(Deck? deck=null, Table? table=null, MoveValidator? validator=null)
    {
        _deck = deck ?? new Deck();
        _table = table ?? new Table(9);
        _validator = validator ?? new MoveValidator();
    }

    public void StartGame()
    {
        _deck.Shuffle();
        RefillTableToNine();
        State = GameState.Running;
        CheckEndState();
    }

    public void RefillTableToNine()
    {
        while(_table.Count() < _table.MaxCards && !_deck.IsEmpty())
        {
            var card = _deck.DealCard();
            _table.AddCard(card);
        }
    }

    public bool SubmitSelection(IReadOnlyList<int> indices, out string message)
    {
        message = "";
        if(State != GameState.Running)
        {
            message = "Game is not running";
            return false;
        }

        List<Card> selected;
        try
        {
            selected = _table.GetCardsByIndices(indices);
        }
        catch (Exception ex)
        {
            message = $"Invalid selection: {ex.Message}";
            return false;
        }

        if(!_validator.IsValidSelection(selected))
        {
            message = "Invalid move. Select 2 cards summing to 11, or 3 cards that are J-Q-K.";
            return false;
        }
        _table.RemoveCards(selected);
        RefillTableToNine();
        CheckEndState();
        message = "Move Accepted";
        return true;

    }

    public void CheckEndState()
    {
        if(CheckWin())
        {
            State = GameState.Won;
            return;
        }
        if(CheckLose())
        {
            State = GameState.Lost;
            return;
        }

        State = GameState.Running;
    }
    
    public bool CheckWin()
    {
        return _deck.IsEmpty() && _table.IsEmpty();
    }

    public bool CheckLose()
    {
        return !_validator.HasLegalMoves(_table.Cards);
    }


}