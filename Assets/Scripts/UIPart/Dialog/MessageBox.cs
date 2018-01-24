using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public delegate void MessageBoxCloseDelagate();

    public class MessageBox : UiBase
    {
        public float MaxWidth = 800;
        public float MaxHeight = 600;

        private Text txtMsg;
        private RectTransform rectTransform;

        private float perRowHeight = 26;
        private float showTime = 2f;

        private MessageBoxCloseDelagate closeDelagate;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            txtMsg = transform.Find("Text").GetComponent<Text>();
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
            if (needLength > MaxWidth)
            {
                sizeData.x = MaxWidth;
                int count = (int)(needLength / MaxWidth);
                float countHeight = (count + 1) * perRowHeight;
                float needWidth = countHeight > MaxHeight ? MaxHeight : countHeight;
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
        public MessageBox SetCloseAction(MessageBoxCloseDelagate closeAction)
        {
            closeDelagate = closeAction;
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
            this.showTime = EasyUiDefaultConfig.DefaultMessageShowTime;
            SetMsg(EasyUiDefaultConfig.DefaultMsg);
        }

        #endregion
    }
}
