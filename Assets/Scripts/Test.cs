using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUiTool;

public class Test : MonoBehaviour {

    public Transform UIRoot;

    private void Start()
    {
        //先设置跟节点
        DialogBuilder.SetUiRootTransform(UIRoot);
    }

    private void OnGUI()
    {
        #region AlertDialog
        if (GUILayout.Button("AlertDialog"))
        {
            //加载一个AlertDialog
            AlertDialog aDialog = DialogBuilder.GetDialog(UiType.AlertDialog) as AlertDialog;
            //内容
            aDialog.SetTitle("test标题")
                .SetMessage("这是test的内容")
                .SetNegativeButton("取消",() =>
                {
                    Debug.Log("Click Negative Button");
                })
                .SetPositiveButton("确定",() =>
                {
                    Debug.Log("Click Positive Button");
                });
            //设置动画类型
            aDialog.SetAnimation(UiAnimationType.Zoom, 0.5f, UiAnimationType.Zoom, 0.5f);
            aDialog.Show();
        }
        #endregion

        #region InputDialog

        if (GUILayout.Button("InputDialog"))
        {
            InputDialog iDialog = DialogBuilder.GetDialog(UiType.InputDialog) as InputDialog;
            iDialog.SetTitle("请输入一个数字")
                .SetInputType(UnityEngine.UI.InputField.ContentType.IntegerNumber)
                .SetCloseButton(() =>
                {
                    Debug.Log("关闭输入框");
                })
                .SetConfirmButton((string inputStr) =>
                {
                    Debug.Log(string.Format("你输入了{0}", inputStr));
                });
            iDialog.Show();
        }

        #endregion

        #region MessageBox

        if (GUILayout.Button("MessageBox"))
        {
            MessageBox mbox = DialogBuilder.GetDialog(UiType.MessageBox) as MessageBox;
            mbox.SetMsg("这是一个小的小的小的消息框")
                .SetShowTime(1.5f)
                .SetCloseAction(()=> { Debug.Log("MessageBox关闭了"); });
            mbox.Show();
        }

        #endregion

        #region ListChooseDialog

        if (GUILayout.Button("ListChooseDialog"))
        {
            ListChooseDialog lcDialog = DialogBuilder.GetDialog(UiType.ListChooseDialog) as ListChooseDialog;
            string[] lsList = { "香蕉", "苹果", "葡萄" };
            lcDialog.SetTitle("请选择你最喜欢的水果")
                .SetDropList(lsList)
                .SetConfirmAction((int x) =>
                {
                    Debug.Log("你最喜欢的水果是:" + lsList[x]);
                });
            lcDialog.Show();
        }

        #endregion

    }

}
