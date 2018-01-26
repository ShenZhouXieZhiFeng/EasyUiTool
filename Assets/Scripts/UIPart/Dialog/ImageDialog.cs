using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace EasyUiTool
{
    public class ImageDialog : UiBase,IPointerEnterHandler,IPointerExitHandler
    {

        #region members
        [Header("拖拽灵敏度")]
        [SerializeField]
        private float DragSentiviVal = 20f;
        [SerializeField]
        private float DragAnimTime = 1f;
        [Header("最大宽高")]
        [SerializeField]
        private float MaxWidth = 1060;
        [SerializeField]
        private float MaxHeight = 500;

        private Button btnClose, btnRefresh, btnLeft, btnRight;
        private Text txtTitle;
        //show
        private RectTransform showRect;
        private Text txtImgDesc;
        private RawImage imgShow;
        //temp
        private RectTransform tempRect;
        private Text txtImgDesc_temp;
        private RawImage imgShow_temp;

        private Action closeAction;
        private List<ImageModel> images = new List<ImageModel>();
        private List<Texture> imageCache = new List<Texture>();
        private int curImageIndex = 0;
        private bool CanDrag = true;
        #endregion

        #region funcs
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
            txtImgDesc = transform.Find("mid/midMid/imgShow/txtImageDesc").GetComponent<Text>();
            imgShow = transform.Find("mid/midMid/imgShow").GetComponent<RawImage>();
            txtImgDesc_temp = transform.Find("mid/midTemp/imgShow/txtImageDesc").GetComponent<Text>();
            imgShow_temp = transform.Find("mid/midTemp/imgShow").GetComponent<RawImage>();

            showRect = transform.Find("mid/midMid").GetComponent<RectTransform>();
            tempRect = transform.Find("mid/midTemp").GetComponent<RectTransform>();

            txtImgDesc.transform.localScale = new Vector3(1, 0, 1);
            btnClose.onClick.AddListener(Close);
            btnLeft.onClick.AddListener(dragLeft);
            btnRefresh.onClick.AddListener(() =>
            {
                if (CanDrag)
                    loadImage(imgShow, txtImgDesc);
            });
            btnRight.onClick.AddListener(dragRight);

            ResetSelf();
        }

        float mouseDownX = 0;
        private void OnGUI()
        {
            if (Event.current.type == EventType.mouseDown)
            {
                mouseDownX = Input.mousePosition.x;
            }
            else if (Event.current.type == EventType.mouseUp)
            {
                float diff = Input.mousePosition.x - mouseDownX;
                if (diff > DragSentiviVal)
                {
                    dragLeft();
                }
                else if (diff < -DragSentiviVal)
                {
                    dragRight();
                }
            }
        }

        void loadImage(RawImage targetImg, Text targetText)
        {
            int index = curImageIndex;
            if (images.Count <= index)
            {
                Debug.Log("图片为空");
                return;
            }
            ImageModel image = images[index];
            if (imageCache.Count >= index && imageCache[index] != null)
            {
                //取缓存
                showImages(targetImg, targetText, imageCache[index], image.ImageDesc);
                return;
            }
            //加载网络图片
            StartCoroutine(loadImageIenumerator(targetImg, targetText, image.ImageUrl, index));
        }
        IEnumerator loadImageIenumerator(RawImage targetImg, Text targetText, string url, int index)
        {
            WWW www = new WWW(url);
            yield return www;
            if (www.isDone && www.error == null)
            {
                Texture img = www.texture;
                imageCache[index] = img;
                loadImage(targetImg, targetText);
            }
            yield return 0;
        }

        void showImages(RawImage targetImg, Text targetText, Texture img, string desc)
        {
            Vector2 newSize = targetImg.rectTransform.sizeDelta;
            float iW = img.width;
            float iH = img.height;
            if ((iW <= MaxWidth && iH <= MaxHeight))
            {
                newSize.x = iW;
                newSize.y = iH;
            }
            else if (iW > MaxWidth && iH > MaxHeight)
            {
                float lv1 = iW / iH;
                float lv2 = MaxWidth / MaxHeight;
                if (lv1 >= lv2)
                {
                    newSize.x = MaxWidth;
                    newSize.y = MaxHeight * (MaxWidth / iW);
                }
                else
                {
                    newSize.y = MaxHeight;
                    newSize.x = MaxWidth * (MaxHeight / iH);
                }
            }
            else if (iW > MaxWidth && iH < MaxHeight)
            {
                newSize.x = MaxWidth;
                newSize.y = MaxHeight * (MaxWidth / iW);
            }
            else if (iH > MaxHeight && iW < MaxWidth)
            {
                newSize.y = MaxHeight;
                newSize.x = MaxWidth * (MaxHeight / iH);
            }
            targetImg.rectTransform.sizeDelta = newSize;
            targetImg.texture = img;
            targetText.text = desc;
        }

        void dragLeft()
        {
            if (curImageIndex == 0 || !CanDrag)
                return;
            CanDrag = false;
            curImageIndex--;
            tempRect.localPosition = new Vector3(-MaxWidth, tempRect.localPosition.y, 0);
            loadImage(imgShow_temp, txtImgDesc_temp);
            tempRect.DOLocalMoveX(0, DragAnimTime);
            showRect.DOLocalMoveX(MaxWidth, DragAnimTime).OnComplete(() =>
            {
                loadImage(imgShow, txtImgDesc);
                showRect.localPosition = new Vector3(0, tempRect.localPosition.y, 0);
                CanDrag = true;
            });
        }

        void dragRight()
        {
            if (curImageIndex >= (images.Count - 1) || !CanDrag)
                return;
            CanDrag = false;
            curImageIndex++;
            tempRect.localPosition = new Vector3(MaxWidth, tempRect.localPosition.y, 0);
            loadImage(imgShow_temp, txtImgDesc_temp);
            tempRect.DOLocalMoveX(0, DragAnimTime);
            showRect.DOLocalMoveX(-MaxWidth, DragAnimTime).OnComplete(() =>
            {
                loadImage(imgShow, txtImgDesc);
                showRect.localPosition = new Vector3(0, tempRect.localPosition.y, 0);
                CanDrag = true;
            });
        } 
        #endregion

        #region set

        /// <summary>
        /// 设置图片列表
        /// </summary>
        /// <param name="imageList"></param>
        /// <returns></returns>
        public ImageDialog SetImageList(List<ImageModel> imageList)
        {
            images = imageList;
            for (int i = 0; i < imageList.Count; i++)
            {
                imageCache.Add(null);
            }
            return this;
        }

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

        protected override void OnPanelShowBegin()
        {
            base.OnPanelShowBegin();
            loadImage(imgShow, txtImgDesc);
        }

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
            curImageIndex = 0;
            CanDrag = true;
            imageCache.Clear();
            images.Clear();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            txtImgDesc.transform.DOPause();
            txtImgDesc.transform.DOScaleY(1, 0.5f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            txtImgDesc.transform.DOPause();
            txtImgDesc.transform.DOScaleY(0, 0.5f);
        }

        #endregion

    }

    public struct ImageModel
    {
        public string ImageDesc;
        public string ImageUrl;
        public ImageModel(string desc,string url)
        {
            ImageDesc = desc;
            ImageUrl = url;
        }
    }
}
