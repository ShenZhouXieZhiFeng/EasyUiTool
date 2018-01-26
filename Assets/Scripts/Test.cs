using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUiTool;
using DG.Tweening;

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

        #region ProgressDialog

        if (GUILayout.Button("ProgressDialog"))
        {
            ProgressDialog pDialog = DialogBuilder.GetDialog(UiType.ProgressDialog) as ProgressDialog;
            pDialog.SetTitle("加载中，请稍等");
            pDialog.SetCompletedAction(() =>
            {
                Debug.Log("加载完成了");
                CancelInvoke("updatePrograssDialog");
            });
            pDialog.Show();
            float val = 0;
            DOTween.To(() => val, x => val = x, 1, 5).OnUpdate(() =>
            {
                pDialog.UpdateSlider(val);
            });
        }

        #endregion

        #region WaitBox

        if (GUILayout.Button("WaitBox"))
        {
            WaitBox wBox = DialogBuilder.GetDialog(UiType.WaitBox) as WaitBox;
            wBox.SetRotateSpeed(10)
                .SetWaitTime(5)
                .SetEndAction(() =>
                {
                    Debug.Log("等待结束");
                });
            wBox.Show();
        }

        #endregion

        #region CountDownBox

        if (GUILayout.Button("CountDownBox"))
        {
            CountDownBox cdBox = DialogBuilder.GetDialog(UiType.CountDownBox) as CountDownBox;
            cdBox.SetCountShowTime(24, 0, 0)
                .SetCountWaitTime(20)
                .SetOverAction(() => { Debug.Log("计时结束"); });
            cdBox.Show();
        }

        #endregion

        #region ImageDialog

        if (GUILayout.Button("ImageDialog"))
        {
            //网络图片
            //List<ImageModel> images = new List<ImageModel>();
            //images.Add(new ImageModel("图片1", "http://www.bavlo.com/NewsImage/20120601205840_495.png"));
            //images.Add(new ImageModel("图片2", "http://img13.360buyimg.com/n0/jfs/t1978/18/1896890800/23165/d53299e/56812e0cNe1676e78.jpg"));
            //images.Add(new ImageModel("图片3", "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1516956451402&di=d836b57e165b8a09edf273136f398ce5&imgtype=0&src=http%3A%2F%2Fpic34.photophoto.cn%2F20150104%2F0005018399195651_b.jpg"));
            //本地图片
            List<ImageModel> images = new List<ImageModel>();
            images.Add(new ImageModel("unity800x300", Application.dataPath + "/Resources/imgs/unity800x300.png"));
            images.Add(new ImageModel("unity900x1200", Application.dataPath + "/Resources/imgs/unity900x1200.png"));
            images.Add(new ImageModel("unity1060x500", Application.dataPath + "/Resources/imgs/unity1060x500.png"));
            images.Add(new ImageModel("unity1070x800", Application.dataPath + "/Resources/imgs/unity1070x800.png"));
            images.Add(new ImageModel("unity2000x300", Application.dataPath + "/Resources/imgs/unity2000x300.png"));

            ImageDialog iDialog = DialogBuilder.GetDialog(UiType.ImageDialog) as ImageDialog;
            iDialog.SetTitle("图片")
                .SetCloseAction(() =>
                {
                    Debug.Log("close image Dialog");
                })
                .SetImageList(images)
                .SetAnimation(UiAnimationType.Zoom, 1f, UiAnimationType.Zoom, 1f);
            iDialog.Show();
        }

        #endregion

        #region VideoDialog

        if(GUILayout.Button("VideoDialog"))
        {
            VideoDialog vDialog = DialogBuilder.GetDialog(UiType.VideoDialog) as VideoDialog;
            vDialog.SetAnimation(UiAnimationType.Zoom, 1, UiAnimationType.Zoom, 1);
            vDialog.Show();
        }

        #endregion

    }
}
