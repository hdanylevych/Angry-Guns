using UnityEngine.SceneManagement;

public class SceneTransitionController : ISceneTransitionController
{
    [Inject] public BattleSceneLoadedSignal BattleSceneLoadedSignal { get; set; }

    [PostConstruct]
    private void Construct()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Lobby")
            return;

        SceneManager.SetActiveScene(scene);
        BattleSceneLoadedSignal.Dispatch();
    }
}
