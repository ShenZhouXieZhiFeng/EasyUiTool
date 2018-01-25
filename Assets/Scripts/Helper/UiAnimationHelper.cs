using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace EasyUiTool
{
    /// <summary>
    /// ui动画帮助类
    /// </summary>
    public class UiAnimationHelper
    {
        #region Fade

        /// <summary>
        /// 渐变出现,目标上必须挂载有CanvasGroup
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="playTime">播放时间</param>
        /// <param name="overCall">结束回调</param>
        public void AnimationFadeIn(Transform target,float playTime,UnityAction overAction)
        {
            CanvasGroup cg = target.GetComponent<CanvasGroup>();
            if (cg == null)
            {
                doAction(overAction);
                return;
            }
            cg.alpha = 0;
            cg.DOFade(1, playTime).OnComplete(()=> { doAction(overAction); });
        }

        /// <summary>
        /// 渐变消失,目标上必须挂载有CanvasGroup
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="playTime"></param>
        /// <param name="overCall"></param>
        public void AnimationFadeOut(Transform target, float playTime,UnityAction overAction)
        {
            CanvasGroup cg = target.GetComponent<CanvasGroup>();
            if (cg == null)
            {
                doAction(overAction);
                return;
            }
            cg.DOFade(0, playTime).OnComplete(() =>
            {
                cg.alpha = 1;
                doAction(overAction);
            });
        }

        #endregion

        #region Zoom

        /// <summary>
        /// 缩放进入
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="playTime">动画时间</param>
        public void AnimationZoomIn(Transform target, float playTime,UnityAction overAction)
        {
            target.localScale = Vector3.zero;
            target.DOScale(1, playTime).OnComplete(()=> { doAction(overAction); });
        }

        /// <summary>
        /// 缩放退出
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="playTime">动画时间</param>
        public void AnimationZoomOut(Transform target, float playTime,UnityAction overAction)
        {
            target.DOScale(0, playTime).OnComplete(() =>
            {
                target.localScale = Vector3.one;
                doAction(overAction);
            });
        }

        #endregion

        #region tool

        void doAction(UnityAction ac)
        {
            if (ac != null)
                ac();
        }

        #endregion
    }
}
