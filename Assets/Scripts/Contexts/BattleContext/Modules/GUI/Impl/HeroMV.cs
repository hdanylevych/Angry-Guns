using UnityWeld.Binding;

[Binding]
public class HeroMV : CanvasMV
{
    private UnitModel _model;
    private string _nickname = "Player";

    [Binding]
    public string Nickname
    {
        get => _nickname;

        set
        {
            _nickname = value;

            OnPropertyChanged();
        }
    }

    public void Initialize(UnitModel model)
    {
        _model = model;
    }
}
