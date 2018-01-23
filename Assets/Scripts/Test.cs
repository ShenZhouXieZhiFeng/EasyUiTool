using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUiTool;

public class Test : MonoBehaviour {

    private void OnGUI()
    {
        if (GUILayout.Button("AelrtButton"))
        {
            AlertDialog dialog = DialogBuilder.GetDialog(DialogType.AlertDialog) as AlertDialog;
        }
    }

}
