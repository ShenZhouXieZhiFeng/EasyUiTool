using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class MessageBox : UiBase
    {
        private Text txtMsg;
        private RectTransform rectTransform;

        private float perRowHeight = 26;//每多一行文字增加的高度
        private float showTime = 2f;
        private float maxWidth = 800;
        private float maxHeight = 600;

        private Action closeDelagate;

        private void Awake()
        {
            init();
        }
        void init()
        {
            rectTransform = GetComponent<RectTransform>();
            txtMsg = transform.Find("txtMsg").GetComponent<Text>();

            ResetSelf();
        }

        #region set

        /// <summary>
        /// 设置信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public MessageBox SetMsg(string msg)
        {
            txtMsg.text = msg;
            refresh();
            return this;
        }
        void refresh()
        {
            Vector2 sizeData = rectTransform.sizeDelta;
            float needLength = txtMsg.preferredWidth;
            if (needLength > maxWidth)
            {
                sizeData.x = maxWidth;
                int count = (int)(needLength / maxWidth);
                float countHeight = (count + 1) * perRowHeight;
                float needWidth = countHeight > maxHeight ? maxHeight : countHeight;
                sizeData.y = needWidth;
            }
            else
            {
                sizeData.x = needLength + 60;
            }
            rectTransform.sizeDelta = sizeData;
        }

        /// <summary>
        /// 设置显示时间
        /// </summary>
        /// <param name="showTime"></param>
        /// <returns></returns>
        public MessageBox SetShowTime(float showTime)
        {
            this.showTime = showTime;
            return this;
        }

        /// <summary>
        /// 设置自动关闭时的回调事件
        /// </summary>
        /// <param name="closeAction"></param>
        /// <returns></returns>
        public MessageBox SetCloseAction(Action closeAction)
        {
            closeDelagate = closeAction;
            return this;
        }

        public MessageBox SetMaxSize(float maxWidth,float maxHeight)
        {
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
            return this;
        }

        #endregion

        #region override

        protected override void OnPanelShowBegin()
        {
            base.OnPanelShowBegin();
            float delayTime = showTime + ShowAnimationTime;
            Invoke("autoClose", delayTime);
        }
        void autoClose()
        {
            if (closeDelagate != null)
                closeDelagate();
            Close();
        }

        public override void ResetSelf()
        {
            base.ResetSelf();
            closeDelagate = null;
            showTime = EasyUiDefaultConfig.DefaultMessageShowTime;
            maxWidth = EasyUiDefaultConfig.DefaultMessageBoxMaxWidth;
            maxHeight = EasyUiDefaultConfig.DefaultMessageBoxMaxHeight;
            SetMsg(EasyUiDefaultConfig.DefaultMsg);
        }

        #endregion
    }
}
