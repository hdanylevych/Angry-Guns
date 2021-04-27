public class LobbyModel
{
    private LobbyState _state;

    public string PlayerNickname
    {
        get => _state.PlayerNickname;

        set
        {
            _state.PlayerNickname = value;
        }
    }

    public int CurrentUnitId
    {
        get => _state.CurrentUnitId;

        set
        {
            _state.CurrentUnitId = value;
        }
    }

    public string GameMode
    {
        get => _state.GameMode;

        set
        {
            _state.GameMode = value;
        }
    }

    public LobbyModel(LobbyState state)
    {
        _state = state;
    }
}
