namespace SimplePong.Controller
{
    public class DualShockController : AbstractController
    {
        public override string KeyPathToSpritePath(string path)
        {
            if (path == "buttonSouth") return "Sprites/Controller/PS4/PS4_Cross";
            if (path == "buttonNorth") return "Sprites/Controller/PS4/PS4_Triangle";
            if (path == "buttonEast") return "Sprites/Controller/PS4/PS4_Circle";
            if (path == "buttonWest") return "Sprites/Controller/PS4/PS4_Square";

            if (path == "leftShoulder") return "Sprites/Controller/PS4/PS4_L1";
            if (path == "leftTrigger") return "Sprites/Controller/PS4/PS4_L2";
            if (path == "rightShoulder") return "Sprites/Controller/PS4/PS4_R1";
            if (path == "rightTrigger") return "Sprites/Controller/PS4/PS4_R2";

            if (path == "leftStickPress") return "Sprites/Controller/PS4/PS4_Left_Stick";
            if (path == "rightStickPress") return "Sprites/Controller/PS4/PS4_Right_Stick";

            if (path == "start") return "Sprites/Controller/PS4/PS4_Options";

            if (path == "dpad/down") return "Sprites/Controller/PS4/PS4_Dpad_Down";
            if (path == "dpad/up") return "Sprites/Controller/PS4/PS4_Dpad_Up";
            if (path == "dpad/left") return "Sprites/Controller/PS4/PS4_Dpad_Left";
            if (path == "dpad/right") return "Sprites/Controller/PS4/PS4_Dpad_Right";
            return "Sprites/Controller/Placeholder";
        }

        public override bool IsHandled(string path)
        {
            if (path == "systemButton" || path == "select" || path == "touchpadButton")
                return false;

            return true;
        }

        public override NavigationKeyInstructionHandler.Controller type
        {
            get { return NavigationKeyInstructionHandler.Controller.DualShock; }
        }
    }
}