using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace EasyUiTool
{
    public class CountDownBox : UiBase
    {
        private Text txtH, txtM, txtS;
        private Action countOverAction;

        private TimeSpan timeSpan;
        private float needTime;
        private Tween dtTime;

        private void Awake()
        {
            init();
        }
        void init()
        {
            txtH = transform.Find("left/txtHour").GetComponent<Text>();
            txtM = transform.Find("mid/txtMin").GetComponent<Text>();
            txtS = transform.Find("right/txtSec").GetComponent<Text>();

            ResetSelf();
        }

        void beginCount()
        {
            double totalSec = timeSpan.TotalSeconds;
            dtTime = DOTween.To(() => totalSec, x => totalSec = x, 0, needTime).OnUpdate(() =>
            {
                timeSpan = new TimeSpan(0, 0, (int)totalSec);
                setTimeShow(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }).OnComplete(() =>
            {
                Close();
            });
        }

        void setTimeShow(int hour,int min,int sec)
        {
            txtH.text = hour < 10 ? "0" + hour : hour + "";
            txtM.text = min < 10 ? "0" + min : min + "";
            txtS.text = sec < 10 ? "0" + sec : sec + "";
        }

        #region set

        /// <summary>
        /// 设定倒计时结束的回调事件
        /// </summary>
        /// <param name="overAction"></param>
        /// <returns></returns>
        public CountDownBox SetOverAction(Action overAction)
        {
            countOverAction = overAction;
            return this;
        }

        /// <summary>
        /// 设定倒计时面板的显示时间
        /// </summary>
        /// <param name="sec">秒</param>
        /// <returns></returns>
        public CountDownBox SetCountShowTime(int sec)
        {
            timeSpan = new TimeSpan(0, 0, sec);
            return this;
        }

        /// <summary>
        /// 设定倒计时面板的显示时间
        /// </summary>
        /// <param name="hour">时</param>
        /// <param name="min">分</param>
        /// <param name="sec">秒</param>
        /// <returns></returns>
        public CountDownBox SetCountShowTime(int hour,int min,int sec)
        {
            timeSpan = new TimeSpan(hour, min, sec);
            return this;
        }

        /// <summary>
        /// 设置倒计时完成需要的时间（秒）
        /// </summary>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public CountDownBox SetCountWaitTime(float waitTime)
        {
            if (waitTime > 0)
                needTime = waitTime;
            return this;
        }

        #endregion

        #region override

        protected override void OnPanelShowBegin()
        {
            if (dtTime != null)
                dtTime.Pause();
            setTimeShow(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            base.OnPanelShowBegin();
        }

        protected override void OnPanelShowOver()
        {
            base.OnPanelShowOver();
            beginCount();
        }

        protected override void OnPanelCloseOver()
        {
            base.OnPanelCloseOver();
            if (countOverAction != null)
                countOverAction();
        }

        public override void ResetSelf()
        {
            base.ResetSelf();
            countOverAction = null;
            timeSpan = new TimeSpan(0, 0, 3661);//1 1 1
            needTime = 5;
        }

        #endregion

    }
}
