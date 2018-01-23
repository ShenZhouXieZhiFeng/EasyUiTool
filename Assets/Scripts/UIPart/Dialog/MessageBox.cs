using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class MessageBox : UiBase
    {
        public float MaxWidth = 800;
        public float MaxHeight = 600;

        private float perRowHeight = 26;

        private Text txtMsg;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            txtMsg = transform.Find("Text").GetComponent<Text>();
        }

        [ContextMenu("Test")]
        public void Test()
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
            }else
            {
                sizeData.x = needLength + 50;
            }
            rectTransform.sizeDelta = sizeData;
        }
    }
}
