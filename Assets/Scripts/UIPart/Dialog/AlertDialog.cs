using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyUiTool
{
    public delegate void AlertDialogNegativeDelegate();
    public delegate void AlertDialogPositionDelegate();
    /// <summary>
    /// 警告信息框
    /// </summary>
    public class AlertDialog : UiBase
    {
        private Text txtTitle, txtMsg, txtCancel, txtConfirm;
        private Button btnCancel, btnConfirm;
        private AlertDialogNegativeDelegate NegativeButtonAction;
        private AlertDialogPositionDelegate PositiveButtonAction;

        private void Awake()
        {
            init();
        }

        void init()
        {
            txtTitle = transform.Find("Up/Title").GetComponent<Text>();
            txtMsg = transform.Find("Mid/Msg").GetComponent<Text>();
            btnCancel = transform.Find("Down/CancelButton").GetComponent<Button>();
            btnConfirm = transform.Find("Down/ConfirmButton").GetComponent<Button>();
            txtCancel = btnCancel.transform.Find("Text").GetComponent<Text>();
            txtConfirm = btnConfirm.transform.Find("Text").GetComponent<Text>();

            btnCancel.onClick.AddListener(() =>
            {
                if (NegativeButtonAction != null)
                    NegativeButtonAction();
                Close();
            });
            btnConfirm.onClick.AddListener(() =>
            {
                if (PositiveButtonAction != null)
                    PositiveButtonAction();
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
        public AlertDialog SetNegativeButton(string content, AlertDialogNegativeDelegate negativeAction)
        {
            txtCancel.text = content;
            return SetNegativeButton(negativeAction);
        }

        /// <summary>
        /// 设置取消按钮
        /// </summary>
        public AlertDialog SetNegativeButton(AlertDialogNegativeDelegate negativeAction)
        {
            NegativeButtonAction = negativeAction;
            return this;
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeAction"></param>
        /// <returns></returns>
        public AlertDialog SetPositiveButton(string content, AlertDialogPositionDelegate positiveAction)
        {
            txtConfirm.text = content;
            return SetPositiveButton(positiveAction);
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        public AlertDialog SetPositiveButton(AlertDialogPositionDelegate positiveAction)
        {
            PositiveButtonAction = positiveAction;
            return this;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            NegativeButtonAction = null;
            PositiveButtonAction = null;
            txtTitle.text = EasyUiDefaultConfig.DefaultTitle;
            txtMsg.text = EasyUiDefaultConfig.DefaultMsg;
            txtCancel.text = EasyUiDefaultConfig.DefaultCancelDesc;
            txtConfirm.text = EasyUiDefaultConfig.DefaultConfirmDesc;
        }

        #endregion

    }
}
