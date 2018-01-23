using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUiTool;

public class Test : MonoBehaviour {

    private void OnGUI()
    {
        #region AlertDialog
        if (GUILayout.Button("AlertDialog"))
        {
            AlertDialog dialog = DialogBuilder.GetDialog(UiType.AlertDialog) as AlertDialog;
            dialog.SetTitle("test标题")
                .SetMessage("这是test的内容")
                .SetNegativeButton(() =>
                {
                    Debug.Log("Click Negative Button");
                })
                .SetPositiveButton(() =>
                {
                    Debug.Log("Click Positive Button");
                });
            dialog.Show();
        }
        #endregion

    }

}
