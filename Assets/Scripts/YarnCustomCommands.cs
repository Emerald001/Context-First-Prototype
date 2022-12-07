// WARNING: Do not modify this file. It is automatically generated on every Yarn project import.
//          To add/change behavior, make a subclass of YarnCustomCommands.
//          Generated on: 12/7/2022 3:02:12 PM

using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

namespace PixelCrushers.DialogueSystem.Yarn
{
    public class YarnCustomCommands : MonoBehaviour
    {
        public const string ClearAndAddStringFormatArgumentLuaName = "clr_add_str_fmt_arg";
        public const string AddStringFormatArgumentLuaName = "add_str_fmt_arg";

        // Can't pass an array of values from Lua to C#, only primitives.
        // So arguments to string.Format functions must be individually added to a list
        // by calling AddStringFormatArgument().
        private Dictionary<int, Dictionary<int, List<string>>> stringFormatArgumentMap = new Dictionary<int, Dictionary<int, List<string>>>();

        private static bool isRegistered = false;
        private static bool didIRegister = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            isRegistered = false;
            didIRegister = false;
        }

        public virtual void OnEnable()
        {
            if (!isRegistered)
            {
                isRegistered = true;
                didIRegister = true;
                RegisterFunctions();
            }
        }

        public virtual void OnDisable()
        {
            if (isRegistered && didIRegister)
            {
                isRegistered = false;
                didIRegister = false;
                UnregisterFunctions();
            }
        }

        public virtual void RegisterFunctions()
        {
            // Debug.Log("YarnCustomCommands::OnEnable()");
            // These calls register your custom commands. You must replace two sections of each register call:
            // <MethodName>: Replace this with your custom command implementation's method call
            // <Parameters>: Replace this with a list of arguments, of the proper type, to complete your method call
            //               It is fine to use the default value for argument types, e.g.:
            //                  BoolValue: false
            //                  FloatValue: 0F
            //                  None: null or 0
            //                  StringValue: string.Empty
            Lua.RegisterFunction(ClearAndAddStringFormatArgumentLuaName, this, SymbolExtensions.GetMethodInfo(() => ClearAndAddStringFormatArgument(0D, 0D, string.Empty)));
            // Debug.Log($"YarnCustomCommands::OnEnable() - Registering lua function: {ClearAndAddStringFormatArgumentLuaName}");
            Lua.RegisterFunction(AddStringFormatArgumentLuaName, this, SymbolExtensions.GetMethodInfo(() => AddStringFormatArgument(0D, 0D, string.Empty)));
            // Debug.Log($"YarnCustomCommands::OnEnable() - Registering lua function: {AddStringFormatArgumentLuaName}");
        }

        public virtual void UnregisterFunctions()
        {
            // Debug.Log("YarnCustomCommands::OnDisable()");
            // Note: If this script is on your Dialogue Manager & the Dialogue Manager is configured
            // as Don't Destroy On Load (on by default), don't unregister Lua functions.
            Lua.UnregisterFunction(ClearAndAddStringFormatArgumentLuaName);
            // Debug.Log($"YarnCustomCommands::OnEnable() - Unregistering lua function: {ClearAndAddStringFormatArgumentLuaName}");
            Lua.UnregisterFunction(AddStringFormatArgumentLuaName);
            // Debug.Log($"YarnCustomCommands::OnDisable() - Unregistering lua function: {AddStringFormatArgumentLuaName}");
        }

        public virtual void OnConversationLine(Subtitle subtitle)
        {
            // Debug.Log($"YarnCustomCommands::OnConversationLine(\"{subtitle}\")");
            if (!string.IsNullOrEmpty(subtitle.formattedText.text?.Trim()))
            {
                subtitle.formattedText.text = FormatText(
                    subtitle.dialogueEntry.conversationID,
                    subtitle.dialogueEntry.id,
                    subtitle.formattedText.text);
            }
        }

        public virtual void OnConversationResponseMenu(Response[] responses)
        {
            // Debug.Log("YarnCustomCommands::OnConversationResponseMenu()");
            foreach (Response response in responses)
            {
                if (!string.IsNullOrEmpty(response.formattedText.text?.Trim()))
                {
                    response.formattedText.text = FormatText(
                        response.destinationEntry.conversationID,
                        response.destinationEntry.id,
                        response.formattedText.text);
                }
            }
        }

        public virtual void OnConversationEnd(Transform actor)
        {
            // Debug.Log("YarnCustomCommands::OnConversationEnd()");
            ClearConversationStringArgumentsMap(DialogueManager.instance.lastConversationID);
        }

        // Calls string.Format (if there are any args) on the text, then runs it through Yarn's format function logic.
        private string FormatText(int conversationId, int dialogueEntryId, string text)
        {
            // Debug.Log($"YarnCustomCommands::FormatText({conversationId}, {dialogueEntryId}, \"{text}\")");

            // Grab the string, then format it if necessary.
            // We know this if there are format arguments for the dialogue entry in string arguments map.
            var displayText = text;

            if (stringFormatArgumentMap.ContainsKey(conversationId) && stringFormatArgumentMap[conversationId].ContainsKey(dialogueEntryId))
            {
                var args = stringFormatArgumentMap[conversationId][dialogueEntryId];

                if (args.Count > 0)
                {
                    displayText = String.Format(displayText, args.ToArray());
                }
            }

            // Run it through Yarn's string format function handler
            // var locale = Localization.Language;
            var result = Dialogue.ExpandFormatFunctions(displayText, Localization.Language);
            return result;
        }

        private void ClearConversationStringArgumentsMap(int conversationId)
        {
            // Debug.Log($"YarnCustomCommands::ClearConversationStringArgumentsMap({conversationId})");
            var cId = DialogueManager.instance.lastConversationID;
            if (stringFormatArgumentMap.ContainsKey(cId))
            {
                // Probably unnecessary to do before clearing the map,
                // but let's just do it anyway.
                foreach (var argsEntry in stringFormatArgumentMap[cId])
                {
                    argsEntry.Value.Clear();
                }

                stringFormatArgumentMap.Clear();
            }
        }

        // Call this method with the first argument for string.Format. This clears the list before adding anything,
        // making sure that no extra args are present from previous runs. This is extra defensive, as all string arg
        // lists associated with a conversation are cleared on conversation start and end but hey, can't hurt to be careful!
        public void ClearAndAddStringFormatArgument(double conversationId, double dialogueEntryId, string arg)
        {
            // Debug.Log($"YarnCustomCommands::ClearAndAddStringFormatArgument({conversationId}, {dialogueEntryId}, \"{arg})\")");
            var cId = (int)conversationId;
            var dId = (int)dialogueEntryId;

            if (stringFormatArgumentMap.ContainsKey(cId) && stringFormatArgumentMap[cId].ContainsKey(dId))
            {
                stringFormatArgumentMap[cId][dId].Clear();
            }

            AddStringFormatArgument(conversationId, dialogueEntryId, arg);
        }

        public void AddStringFormatArgument(double conversationId, double dialogueEntryId, string arg)
        {
            // Debug.Log($"YarnCustomCommands::AddStringFormatArgument({conversationId}, {dialogueEntryId}, \"{arg})\")");
            var cId = (int)conversationId;
            var dId = (int)dialogueEntryId;

            if (!stringFormatArgumentMap.ContainsKey(cId))
            {
                stringFormatArgumentMap[cId] = new Dictionary<int, List<string>>();
            }

            if (!stringFormatArgumentMap[cId].ContainsKey(dId))
            {
                stringFormatArgumentMap[cId][dId] = new List<string>();
            }

            stringFormatArgumentMap[cId][dId].Add(arg);
        }

        // These methods do nothing, but are implemented as placeholders
        // in case functionality needs to be added in the future.
        public virtual void OnConversationStart(Transform actor) {}
        public virtual void OnConversationCancelled(Transform actor) {}
        public virtual void OnPrepareConversationLine(DialogueEntry entry) {}
        public virtual void OnConversationLineEnd(Subtitle subtitle) {}
        public virtual void OnConversationLineCancelled(Subtitle subtitle) {}
        public virtual void OnConversationTimeout() {}
        public virtual void OnLinkedConversationStart(Transform actor) {}
        public virtual void OnTextChange(UnityEngine.UI.Text text) {}

        public virtual void OnBarkStart(Transform actor) {}
        public virtual void OnBarkEnd(Transform actor) {}
        public virtual void OnBarkLine(Subtitle subtitle) {}
    }
}
