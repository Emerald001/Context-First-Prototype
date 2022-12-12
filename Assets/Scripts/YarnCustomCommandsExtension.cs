using UnityEngine;
using PixelCrushers.DialogueSystem.Yarn;


namespace PixelCrushers.DialogueSystem.Yarn
{
    public class YarnCustomCommandsExtension : YarnCustomCommands
    {
        public MovementManager movementManager;
        public override void RegisterFunctions()
        {
            // This MUST be called here:
            base.RegisterFunctions();

            Lua.RegisterFunction("my_command", this, SymbolExtensions.GetMethodInfo(() => MyCustomCommand("", 0f, false)));
            Lua.RegisterFunction("Test", this, SymbolExtensions.GetMethodInfo(() => TestCommand()));
            Lua.RegisterFunction("TriggerInteractionState", this, SymbolExtensions.GetMethodInfo(() => CurrentlyInteracting(true)));
        }

        public override void UnregisterFunctions()
        {
            // This MUST be called here:
            base.UnregisterFunctions();

            Lua.UnregisterFunction("my_command");
            Lua.UnregisterFunction("Test");
            Lua.UnregisterFunction("TriggerInteractionState");
        }


        
        public void MyCustomCommand(string arg1, float arg2, bool arg3)
        {
            Debug.Log($"MyCmd('{arg1}', {arg2}, {arg3}) - SUCCESS");
        }
        
        public void TestCommand()
        {
            Debug.Log("You did it, finally.");
        }

        public void CurrentlyInteracting(bool trigger)
        {
            movementManager.SetInteracting(trigger);
        }
    }
}


