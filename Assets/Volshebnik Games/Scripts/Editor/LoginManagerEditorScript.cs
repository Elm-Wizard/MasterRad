using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is resonsible for connecting to Photon Servers.", MessageType.Info);

        LoginManager loginManager = (LoginManager)target; // target je iz Editor klase, referenca na inspektovani objekat
        if (GUILayout.Button("Connect Anonymously"))
        {
            loginManager.ConnectAnonymously();

        }
    }
}
