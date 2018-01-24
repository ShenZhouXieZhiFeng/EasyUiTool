using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class ProgressDialog : UiBase
    {
        private Text txtTitle;
        private Slider slider;
        private Text txtValue;

        private Action progressEndAction;

        private void Awake()
        {
            init();
        }
        void init()
        {
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            slider = transform.Find("down/slider").GetComponent<Slider>();
            txtValue = transform.Find("down/txtValue").GetComponent<Text>();

            ResetSelf();
        }

        #region set

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ProgressDialog SetTitle(string title)
        {
            txtTitle.text = title;
            return this;
        }

        /// <summary>
        /// 更新进度0-1
        /// </summary>
        /// <param name="curProgress">0-1</param>
        /// <returns></returns>
        public ProgressDialog UpdateSlider(float curProgress)
        {
            slider.value = curProgress;
            txtValue.text = string.Format("{0}%", Mathf.RoundToInt(curProgress * 100));

            if (curProgress == 1)
            {
                if (progressEndAction != null)
                    progressEndAction();
                Close();
            }

            return this;
        }

        /// <summary>
        /// 设置进度完成的回调事件
        /// </summary>
        /// <param name="completedAction"></param>
        /// <returns></returns>
        public ProgressDialog SetCompletedAction(Action completedAction)
        {
            progressEndAction = completedAction;
            return this;
        }

        #endregion

        #region get

        /// <summary>
        /// 获取当前进度
        /// </summary>
        /// <returns></returns>
        public float GetCurrentProgress()
        {
            return slider.value;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            SetTitle(EasyUiDefaultConfig.DefaultPrograssTitle);
            UpdateSlider(0);
            progressEndAction = null;
        }

        #endregion

    }
}
