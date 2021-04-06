
using strange.extensions.context.impl;

public class AppRoot : ContextView
{
    private void Awake()
    {
        var context = new LobbyContext(this, true);
        context.Start();
    }
}
