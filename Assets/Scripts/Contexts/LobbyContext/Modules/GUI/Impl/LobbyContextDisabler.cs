using strange.extensions.mediation.impl;

public class LobbyContextDisabler : View
{
    [Inject] public BattleSceneLoadedSignal BattleSceneLoadedSignal { get; set; }

    [PostConstruct]
    private void Construct()
    {
        BattleSceneLoadedSignal.AddListener(() => gameObject.SetActive(false));
    }
}
