using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    /// <summary>
    /// 输入对话框
    /// </summary>
    public class InputDialog : UiBase
    {
        private Button btnClose,btnConfirm;
        private Text txtTitle;
        private InputField input;
        private Action delegateClose;
        private Action<string> delegateConfirm;

        private void Awake()
        {
            init();
        }

        void init()
        {
            btnClose = transform.Find("btnClose").GetComponent<Button>();
            btnConfirm = transform.Find("down/btnConfirm").GetComponent<Button>();
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            input = transform.Find("down/inputValue").GetComponent<InputField>();

            btnClose.onClick.AddListener(() =>
            {
                if (delegateClose != null)
                    delegateClose();
                Close();
            });
            btnConfirm.onClick.AddListener(() =>
            {
                if (delegateConfirm != null)
                {
                    string inputStr = input.text;
                    delegateConfirm(inputStr);
                }
                Close();
            });
            ResetSelf();
        }

        #region set

        /// <summary>
        /// 设置标题
        /// </summary>
        public InputDialog SetTitle(string title)
        {
            txtTitle.text = title;
            return this;
        }

        /// <summary>
        /// 设置关闭按钮
        /// </summary>
        /// <param name="closeAction">关闭回调</param>
        /// <returns></returns>
        public InputDialog SetCloseButton(Action closeAction)
        {
            delegateClose = closeAction;
            return this;
        }

        /// <summary>
        /// 设置提交按钮
        /// </summary>
        /// <param name="content">按钮内容</param>
        /// <param name="confirmAction">点击回调</param>
        /// <returns></returns>
        public InputDialog SetConfirmButton(string content, Action<string> confirmAction)
        {
            txtTitle.text = content;
            return SetConfirmButton(confirmAction);
        }

        /// <summary>
        /// 设置提交按钮
        /// </summary>
        /// <param name="confirmAction">提交按钮点击回调</param>
        /// <returns></returns>
        public InputDialog SetConfirmButton(Action<string> confirmAction)
        {
            delegateConfirm = confirmAction;
            return this;
        }

        /// <summary>
        /// 设置输入框输入类型
        /// </summary>
        /// <param name="contentType">输入类型</param>
        /// <returns></returns>
        public InputDialog SetInputType(InputField.ContentType contentType)
        {
            input.contentType = contentType;
            return this;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            delegateClose = null;
            delegateConfirm = null;
            txtTitle.text = EasyUiDefaultConfig.DefaultTitle;
            input.contentType = InputField.ContentType.Standard;
        }

        #endregion

    }
}
