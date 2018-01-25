using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class ImageDialog : UiBase
    {
        private Button btnClose, btnRefresh, btnLeft, btnRight;
        private Text txtTitle,txtImgDesc;
        private Image imgShow;
        private EventTrigger imageTrigger;

        private Action closeAction;

        private void Awake()
        {
            init();
        }
        void init()
        {
            btnClose = transform.Find("up/btnClose").GetComponent<Button>();
            btnRefresh = transform.Find("down/btnRefresh").GetComponent<Button>();
            btnLeft = transform.Find("down/btnLeft").GetComponent<Button>();
            btnRight = transform.Find("down/btnRight").GetComponent<Button>();
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            txtImgDesc = transform.Find("mid/imgShow/txtImageDesc").GetComponent<Text>();
            imgShow = transform.Find("mid/imgShow").GetComponent<Image>();
            imageTrigger = imgShow.GetComponent<EventTrigger>();

            btnClose.onClick.AddListener(Close);

            ResetSelf();
        }

        #region set

        /// <summary>
        /// 设置上方标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ImageDialog SetTitle(string title)
        {
            txtTitle.text = title;
            return this;
        }

        /// <summary>
        /// 设定关闭回调事件
        /// </summary>
        /// <param name="closeAction"></param>
        /// <returns></returns>
        public ImageDialog SetCloseAction(Action closeAction)
        {
            this.closeAction = closeAction;
            return this;
        }

        #endregion

        #region override

        protected override void OnPanelCloseOver()
        {
            doAction(closeAction);
            base.OnPanelCloseOver();
        }

        public override void ResetSelf()
        {
            base.ResetSelf();
            closeAction = null;
            SetTitle(EasyUiDefaultConfig.DefaultImageDialogTitle);

        }

        #endregion

    }
}
