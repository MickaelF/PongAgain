namespace SimplePong.Controller
{
    public class XboxController : AbstractController
    {
        public override string KeyPathToSpritePath(string path)
        {
            if (path == "buttonSouth") return "Sprites/Controller/Xbox One/XboxOne_A";
            if (path == "buttonNorth") return "Sprites/Controller/Xbox One/XboxOne_Y";
            if (path == "buttonEast") return "Sprites/Controller/Xbox One/XboxOne_B";
            if (path == "buttonWest") return "Sprites/Controller/Xbox One/XboxOne_X";

            if (path == "leftShoulder") return "Sprites/Controller/Xbox One/XboxOne_LB";
            if (path == "leftTrigger") return "Sprites/Controller/Xbox One/XboxOne_LT";
            if (path == "rightShoulder") return "Sprites/Controller/Xbox One/XboxOne_RB";
            if (path == "rightTrigger") return "Sprites/Controller/Xbox One/XboxOne_RT";

            if (path == "leftStickPress") return "Sprites/Controller/Xbox One/XboxOne_Left_Stick";
            if (path == "rightStickPress") return "Sprites/Controller/Xbox One/XboxOne_Right_Stick";

            if (path == "start") return "Sprites/Controller/Xbox One/XboxOne_Menu";

            if (path == "dpad/down") return "Sprites/Controller/Xbox One/XboxOne_Dpad_Down";
            if (path == "dpad/up") return "Sprites/Controller/Xbox One/XboxOne_Dpad_Up";
            if (path == "dpad/left") return "Sprites/Controller/Xbox One/XboxOne_Dpad_Left";
            if (path == "dpad/right") return "Sprites/Controller/Xbox One/XboxOne_Dpad_Right";
            return "Sprites/Controller/Placeholder";
        }

        public override bool IsHandled(string path)
        {
            if (path == "select")
                return false;

            return true;
        }

        public override NavigationKeyInstructionHandler.Controller type
        {
            get { return NavigationKeyInstructionHandler.Controller.Xbox; }
        }
    }
}