using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConsoleLog : MonoBehaviour
{
    public class ConsoleToGUI : MonoBehaviour
    {
        //#if !UNITY_EDITOR
        public TMP_Text text;
        static string myLog = "";
        private string output;
        private string stack;
     
        void OnEnable()
        {
            Application.logMessageReceived += Log;
        }
     
        void OnDisable()
        {
            Application.logMessageReceived -= Log;
        }

        public void Log(string logString, string stackTrace, LogType type)
        {
            output = logString;
            stack = stackTrace;
            myLog = output + "\n" + myLog;
            if (myLog.Length > 5000)
            {
                myLog = myLog.Substring(0, 4000);
            }
            text.text = output + stack;
        }
        //#endif
    }
}
