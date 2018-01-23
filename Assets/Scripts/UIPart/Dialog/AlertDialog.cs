using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class AlertDialog : UiBase
    {
        private Text txtTitle, txtMsg, txtCancel, txtConfirm;
        private Button btnCancel, btnConfirm;
        private UnityAction NegativeButtonAction, PositiveButtonAction;

        private void Awake()
        {
            Init();
        }

        void Init()
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
        public AlertDialog SetNegativeButton(UnityAction negativeAction)
        {
            NegativeButtonAction = negativeAction;
            return this;
        }

        /// <summary>
        /// 设置取消按钮
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeAction"></param>
        /// <returns></returns>
        public AlertDialog SetNegativeButton(string content, UnityAction negativeAction)
        {
            txtCancel.text = content;
            NegativeButtonAction = negativeAction;
            return this;
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        public AlertDialog SetPositiveButton(UnityAction positiveAction)
        {
            PositiveButtonAction = positiveAction;
            return this;
        }

        /// <summary>
        /// 设置确定按钮
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeAction"></param>
        /// <returns></returns>
        public AlertDialog SetPositiveButton(string content, UnityAction positiveAction)
        {
            txtConfirm.text = content;
            PositiveButtonAction = positiveAction;
            return this;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            txtTitle.text = StringConfig.DefaultTitle;
            txtMsg.text = StringConfig.DefaultMsg;
            txtCancel.text = StringConfig.DefaultCancelDesc;
            txtConfirm.text = StringConfig.DefaultConfirmDesc;
        }

        #endregion

    }
}
