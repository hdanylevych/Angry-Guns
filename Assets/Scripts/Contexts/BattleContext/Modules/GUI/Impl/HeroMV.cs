using UnityWeld.Binding;

[Binding]
public class HeroMV : CanvasMV
{
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
}
