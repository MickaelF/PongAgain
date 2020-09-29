namespace SimplePong.Controller
{
    public class SwitchController : AbstractController
    {
        public override string KeyPathToSpritePath(string path)
        {
            if (path == "buttonSouth") return "Sprites/Controller/Switch/Switch_B";
            if (path == "buttonNorth") return "Sprites/Controller/Switch/Switch_X";
            if (path == "buttonEast") return "Sprites/Controller/Switch/Switch_A";
            if (path == "buttonWest") return "Sprites/Controller/Switch/Switch_Y";

            if (path == "leftShoulder") return "Sprites/Controller/Switch/Switch_LB";
            if (path == "leftTrigger") return "Sprites/Controller/Switch/Switch_LT";
            if (path == "rightShoulder") return "Sprites/Controller/Switch/Switch_RB";
            if (path == "rightTrigger") return "Sprites/Controller/Switch/Switch_RT";

            if (path == "leftStickPress") return "Sprites/Controller/Switch/Switch_Left_Stick";
            if (path == "rightStickPress") return "Sprites/Controller/Switch/Switch_Right_Stick";

            if (path == "leftStickPress") return "Sprites/Controller/Switch/Switch_Left_Stick";
            if (path == "rightStickPress") return "Sprites/Controller/Switch/Switch_Right_Stick";

            if (path == "select") return "Sprites/Controller/Switch/Switch_Minus";
            if (path == "start") return "Sprites/Controller/Switch/Switch_Plus";

            if (path == "dpad/down") return "Sprites/Controller/Switch/Switch_Dpad_Down";
            if (path == "dpad/up") return "Sprites/Controller/Switch/Switch_Dpad_Up";
            if (path == "dpad/left") return "Sprites/Controller/Switch/Switch_Dpad_Left";
            if (path == "dpad/right") return "Sprites/Controller/Switch/Switch_Dpad_Right";
            return "Sprites/Controller/Placeholder";
        }

        public override bool IsHandled(string path)
        {
            return true;
        }

        public override NavigationKeyInstructionHandler.Controller type
        {
            get { return NavigationKeyInstructionHandler.Controller.Switch; }
        }
    }
}