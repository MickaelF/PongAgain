namespace SimplePong.Controller
{
    public abstract class AbstractController
    {
        public abstract string KeyPathToSpritePath(string path);

        public abstract bool IsHandled(string path);

        public abstract NavigationKeyInstructionHandler.Controller type { get; }
    }
}