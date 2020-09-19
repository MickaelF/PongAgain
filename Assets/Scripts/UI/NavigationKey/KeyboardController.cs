using UnityEngine.InputSystem;
namespace SimplePong.Controller
{
    public class KeyboardController : AbstractController
    {
        private string aKeyDisplayNamePath;
        private string mKeyDisplayNamePath;
        private string qKeyDisplayNamePath;
        private string wKeyDisplayNamePath;
        private string zKeyDisplayNamePath;
        private string leftBracketKeyDisplayNamePath;
        private string rightBracketKeyDisplayNamePath;
        private string quoteKeyDisplayNamePath;
        private string semicolonKeyDisplayNamePath;
        private string backslashKeyDisplayNamePath;
        private string commaKeyDisplayNamePath;
        private string periodKeyDisplayNamePath;
        private string slashKeyDisplayNamePath;
        private string backquoteKeyDisplayNamePath;

        public void InitializePaths(Keyboard keyboard)
        {
            if (keyboard.qKey.displayName == "A") // Azerty
            {
                aKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Q";
                mKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Comma"; // TODO 
                qKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_A";
                wKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Z";
                zKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_W";
                leftBracketKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Circonflexe"; // TODO
                rightBracketKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Dollars"; // TODO
                quoteKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_U_Accent"; // TODO
                semicolonKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_M";
                backslashKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Asteriks";
                commaKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Semicolon";
                periodKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Deux_Point"; // TODO
                slashKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Exclamation"; // TODO
                backquoteKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Pow"; // TODO

            }
            else // Qwerty
            {

                aKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_A";
                mKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_M";
                qKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Q";
                wKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_W";
                zKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Z";
                leftBracketKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Bracket_Left";
                rightBracketKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Bracket_Right";
                quoteKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Quote";
                semicolonKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Semicolon";
                backslashKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Backslash"; // TODO
                commaKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Comma"; // TODO
                periodKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Period"; // TODO
                slashKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Slash";
                backquoteKeyDisplayNamePath = "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Backquote"; // TODO

            }
        }

        public override string KeyPathToSpritePath(string path)
        {

            if (path == "escape") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Esc";
            if (path == "F1") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F1";
            if (path == "F2") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F2";
            if (path == "F3") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F3";
            if (path == "F4") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F4";
            if (path == "F5") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F5";
            if (path == "F6") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F6";
            if (path == "F7") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F7";
            if (path == "F8") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F8";
            if (path == "F9") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F9";
            if (path == "F10") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F10";
            if (path == "F11") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F11";
            if (path == "F12") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F12";

            if (path == "backquote") return backquoteKeyDisplayNamePath;
            if (path == "0") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_0";
            if (path == "1") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_1";
            if (path == "2") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_2";
            if (path == "3") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_3";
            if (path == "4") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_4";
            if (path == "5") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_5";
            if (path == "6") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_6";
            if (path == "7") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_7";
            if (path == "8") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_8";
            if (path == "9") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_9";

            if (path == "tab") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Tab";
            if (path == "q") return qKeyDisplayNamePath;
            if (path == "w") return wKeyDisplayNamePath;
            if (path == "e") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_E";
            if (path == "r") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_R";
            if (path == "t") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_T";
            if (path == "y") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Y";
            if (path == "u") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_U";
            if (path == "i") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_I";
            if (path == "o") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_O";
            if (path == "p") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_P";
            if (path == "leftBracket") return leftBracketKeyDisplayNamePath;
            if (path == "rightBracket") return rightBracketKeyDisplayNamePath;

            if (path == "capsLock") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Caps_Lock";
            if (path == "a") return aKeyDisplayNamePath;
            if (path == "s") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_S";
            if (path == "d") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_D";
            if (path == "f") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_F";
            if (path == "g") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_G";
            if (path == "h") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_H";
            if (path == "j") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_J";
            if (path == "k") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_K";
            if (path == "l") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_L";
            if (path == "semicolon") return semicolonKeyDisplayNamePath;
            if (path == "quote") return quoteKeyDisplayNamePath;
            if (path == "backslash") return backslashKeyDisplayNamePath;

            if (path == "shift") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Shift";
            if (path == "OEM1") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Mark_Left";
            if (path == "z") return zKeyDisplayNamePath;
            if (path == "x") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_X";
            if (path == "c") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_C";
            if (path == "v") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_V";
            if (path == "b") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_B";
            if (path == "n") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_N";
            if (path == "m") return mKeyDisplayNamePath;
            if (path == "comma") return commaKeyDisplayNamePath;
            if (path == "period") return periodKeyDisplayNamePath;
            if (path == "slash") return slashKeyDisplayNamePath;
            if (path == "rightShift") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Shift_Alt";

            if (path == "control") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Ctrl";
            if (path == "alt") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Alt";
            if (path == "space") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Space";
            if (path == "enter") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Enter";
            if (path == "numpadEnter") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Enter";

            if (path == "leftArrow") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Arrow_Left";
            if (path == "rightArrow") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Arrow_Right";
            if (path == "upArrow") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Arrow_Up";
            if (path == "downArrow") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_Arrow_Down";


            if (path == "numpad0") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_0";
            if (path == "numpad1") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_1";
            if (path == "numpad2") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_2";
            if (path == "numpad3") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_3";
            if (path == "numpad4") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_4";
            if (path == "numpad5") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_5";
            if (path == "numpad6") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_6";
            if (path == "numpad7") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_7";
            if (path == "numpad8") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_8";
            if (path == "numpad9") return "Sprites/Controller/Keyboard/Dark/Keyboard_Black_9";

            return "Sprites/Controller/Placeholder";
        }

        public override bool IsHandled(string path)
        {
            if (path == "numpad0" || path == "numpad1" || path == "numpad2" || path == "numpad3" || path == "numpad4" ||
                path == "numpad5" || path == "numpad6" || path == "numpad7" || path == "numpad8" || path == "numpad9" ||
                path == "numpadDivide" || path == "numpadEnter" || path == "numpadEquals" || path == "numpadMinus" ||
                path == "numpadMultiply" || path == "numpadPeriod" || path == "numpadPeriod" || path == "OEM2" || path == "OEM3" || path == "OEM4" || path == "OEM5" ||
                 path == "pageUp" || path == "pageDown" || path == "pause" || path == "printScreen" || path == "home" || path == "leftMeta" || path == "rightMeta")
                return false;

            return true;
        }

        public override NavigationKeyInstructionHandler.Controller type
        {
            get { return NavigationKeyInstructionHandler.Controller.Keyboard; }
        }
    }
}