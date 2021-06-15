using UnityEngine;

using UnityWeld.Binding;

[Binding]
public class HeroMV : CanvasMV
{
    private UnitModel _model;
    private string _nickname = "Player";
    private float _healthBarValue;

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

    [Binding]
    public float HealthBarValue
    {
        get => _healthBarValue;

        set
        {
            _healthBarValue = value;

            OnPropertyChanged();
        }
    }

    public void Initialize(UnitModel model)
    {
        _model = model;

        Nickname = model.Nickname;
        HealthBarValue = (float)model.HP / model.MaxHP;
    }

    private void Update()
    {
        transform.position = _model.CurrentPosition + new Vector3(0, 7, 0);
        HealthBarValue = (float)_model.HP / _model.MaxHP;
    }
}
