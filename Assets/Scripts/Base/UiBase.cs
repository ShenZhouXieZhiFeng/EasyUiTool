using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUiTool
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UiBase : MonoBehaviour
    {
        #region member

        //动画帮组类
        UiAnimationHelper helper;
        //进入和退出动画类型
        protected UiAnimationType AnimationShow = EasyUiDefaultConfig.DefaultAnimationType;
        protected UiAnimationType AnimationClose = EasyUiDefaultConfig.DefaultAnimationType;
        //动画时间
        protected float ShowAnimationTime = EasyUiDefaultConfig.DefaultAnimationTime;
        protected float CloseAnimationTime = EasyUiDefaultConfig.DefaultAnimationTime;

        #endregion

        public UiBase()
        {
            helper = new UiAnimationHelper();
        }

        #region func

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            OnPanelShowBegin();
            switch (AnimationShow)
            {
                case UiAnimationType.Fade:
                    helper.AnimationFadeIn(transform, ShowAnimationTime, OnPanelShowOver);
                    break;
                case UiAnimationType.Zoom:
                    helper.AnimationZoomIn(transform, ShowAnimationTime, OnPanelShowOver);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            OnPanelCloseBegin();
            switch (AnimationClose)
            {
                case UiAnimationType.Fade:
                    helper.AnimationFadeOut(transform, ShowAnimationTime, OnPanelCloseOver);
                    break;
                case UiAnimationType.Zoom:
                    helper.AnimationZoomOut(transform, ShowAnimationTime, OnPanelCloseOver);
                    break;
                default:
                    OnPanelCloseOver();
                    break;
            }
        }

        /// <summary>
        /// 设置动画类型和动画时间
        /// </summary>
        /// <param name="animationIn">进入动画</param>
        /// <param name="inTime">进入动画播放时间</param>
        /// <param name="animationOut">退出动画</param>
        /// <param name="outTime">退出动画显示时间</param>
        public void SetAnimation(UiAnimationType animationIn,float inTime,UiAnimationType animationOut,float outTime)
        {
            AnimationShow = animationIn;
            ShowAnimationTime = inTime;
            AnimationClose = animationOut;
            CloseAnimationTime = outTime;
        }

        #endregion

        #region virtual

        /// <summary>
        /// 当组件出现动画开始时执行
        /// </summary>
        protected virtual void OnPanelShowBegin()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 当组件出现动画结束时执行
        /// </summary>
        protected virtual void OnPanelShowOver()
        {

        }

        /// <summary>
        /// 当组件关闭动画开始时执行
        /// </summary>
        protected virtual void OnPanelCloseBegin()
        {

        }

        /// <summary>
        /// 当组件关闭动画结束时执行
        /// </summary>
        protected virtual void OnPanelCloseOver()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// 重置Dialog
        /// </summary>
        public virtual void ResetSelf()
        {

        }

        #endregion

    }
}
