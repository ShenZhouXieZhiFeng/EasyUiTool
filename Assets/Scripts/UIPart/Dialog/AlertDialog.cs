using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyUiTool
{
    /// <summary>
    /// 警告信息框
    /// </summary>
    public class AlertDialog : UiBase
    {
        private Text txtTitle, txtMsg, txtCancel, txtConfirm;
        private Button btnCancel, btnConfirm;
        private Action negativeButtonAction;
        private Action positiveButtonAction;

        private void Awake()
        {
            init();
        }

        void init()
        {
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            txtMsg = transform.Find("mid/txtMsg").GetComponent<Text>();
            btnCancel = transform.Find("down/btnCancel").GetComponent<Button>();
            btnConfirm = transform.Find("down/btnConfirm").GetComponent<Button>();
            txtCancel = btnCancel.transform.Find("Text").GetComponent<Text>();
            txtConfirm = btnConfirm.transform.Find("Text").GetComponent<Text>();

            btnCancel.onClick.AddListener(() =>
            {
                if (negativeButtonAction != null)
                    negativeButtonAction();
                Close();
            });
            btnConfirm.onClick.AddListener(() =>
            {
                if (positiveButtonAction != null)
                    positiveButtonAction();
                Close();
            });

            ResetSelf();
        }

        #region Set

        /// <summary>
        /// 设置标题
        /// </summary>
        public AlertDialog SetTitle(string title)
        {
            txtTitle.text = title;
            return this;
        }

        /// <summary>
        /// 设置消息内容
        /// </summary>
        public AlertDialog SetMessage(string message)
        {
            txtMsg.text = message;
            return this;
        }

        /// <summary>
        /// 设置取消按钮
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeAction"></param>
        /// <returns></returns>
        public AlertDialog SetNegativeButton(string content, Action negativeAction)
        {
            txtCancel.text = content;
            return SetNegativeButton(negativeAction);
        }

        /// <summary>
        /// 设置取消按钮
        /// </summary>
        public AlertDialog SetNegativeButton(Action negativeAction)
        {
            negativeButtonAction = negativeAction;
            return this;
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeAction"></param>
        /// <returns></returns>
        public AlertDialog SetPositiveButton(string content, Action positiveAction)
        {
            txtConfirm.text = content;
            return SetPositiveButton(positiveAction);
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        public AlertDialog SetPositiveButton(Action positiveAction)
        {
            positiveButtonAction = positiveAction;
            return this;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            negativeButtonAction = null;
            positiveButtonAction = null;
            txtTitle.text = EasyUiDefaultConfig.DefaultTitle;
            txtMsg.text = EasyUiDefaultConfig.DefaultMsg;
            txtCancel.text = EasyUiDefaultConfig.DefaultCancelDesc;
            txtConfirm.text = EasyUiDefaultConfig.DefaultConfirmDesc;
        }

        #endregion

    }
}
