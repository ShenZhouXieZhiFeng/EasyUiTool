using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class WaitBox : UiBase
    {
        private Transform imgIcon;

        private float curWaitTime = 0f;
        private float rotateSpeed = 20;
        private Action waitEndAction;

        private void Awake()
        {
            init();
        }
        void init()
        {
            imgIcon = transform.Find("imgIcon");
            ResetSelf();
        }

        private void Update()
        {
            imgIcon.Rotate(-Vector3.forward * rotateSpeed);
        }

        #region set

        /// <summary>
        /// 设置旋转速度
        /// </summary>
        /// <param name="needSpeed"></param>
        /// <returns></returns>
        public WaitBox SetRotateSpeed(float needSpeed)
        {
            rotateSpeed = needSpeed;
            return this;
        }

        /// <summary>
        /// 设置等待结束的回调事件
        /// </summary>
        /// <param name="endAction"></param>
        /// <returns></returns>
        public WaitBox SetEndAction(Action endAction)
        {
            waitEndAction = endAction;
            return this;
        }

        /// <summary>
        /// 设置等待时间，如果不进行设定，则需要主动调用WaitEnd方法
        /// </summary>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public WaitBox SetWaitTime(float waitTime)
        {
            curWaitTime = waitTime;
            return this;
        }

        /// <summary>
        /// 等待结束
        /// </summary>
        public void WaitEnd()
        {
            if (waitEndAction != null)
                waitEndAction();
            Close();
        }

        #endregion

        #region override

        protected override void OnPanelShowBegin()
        {
            base.OnPanelShowBegin();
            if (curWaitTime > 0)
            {
                Invoke("WaitEnd", curWaitTime + ShowAnimationTime);
            }
        }

        public override void ResetSelf()
        {
            base.ResetSelf();
            waitEndAction = null;
            transform.rotation = Quaternion.identity;
            rotateSpeed = EasyUiDefaultConfig.DefaultWaitBoxRotateSpeed;
            curWaitTime = 0;
        }

        #endregion

    }
}
