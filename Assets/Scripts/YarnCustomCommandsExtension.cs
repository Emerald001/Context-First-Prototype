using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.Yarn;


namespace PixelCrushers.DialogueSystem.Yarn
{
    public class YarnCustomCommandsExtension : YarnCustomCommands
    {
        public override void RegisterFunctions()
        {
            // This MUST be called here:
            base.RegisterFunctions();

            Lua.RegisterFunction("my_command", this, SymbolExtensions.GetMethodInfo(() => MyCustomCommand("", 0f, false)));
        }

        public override void UnregisterFunctions()
        {
            // This MUST be called here:
            base.UnregisterFunctions();

            Lua.UnregisterFunction("my_command");
        }


        public void MyCustomCommand(string arg1, float arg2, bool arg3)
        {
            Debug.Log($"MyCustomCommand('{arg1}', {arg2}, {arg3}) - SUCCESS");
        }
    }
}


