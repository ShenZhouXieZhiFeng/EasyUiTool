using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUiTool
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UiBase : MonoBehaviour
    {
        //动画帮组类
        UiAnimationHelper helper;
        //进入和退出动画类型
        protected UiAnimationType AnimationShow = UiAnimationType.Fade;
        protected UiAnimationType AnimationClose = UiAnimationType.Zoom;
        //动画时间
        protected float ShowAnimationTime = 1.5f;
        protected float CloseAnimationTime = 1.5f;

        public UiBase()
        {
            helper = new UiAnimationHelper();
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            OnPanelShowBegin();
            switch (AnimationShow)
            {
                case UiAnimationType.Fade:
                    helper.AnimationFadeIn(transform, ShowAnimationTime);
                    break;
                case UiAnimationType.Zoom:
                    helper.AnimationZoomIn(transform, ShowAnimationTime);
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

        #region virtual

        /// <summary>
        /// 当组件出现动画开始时执行
        /// </summary>
        protected virtual void OnPanelShowBegin()
        {
            gameObject.SetActive(true);
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
