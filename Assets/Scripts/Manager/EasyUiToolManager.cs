using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUiTool
{
    public class EasyUiToolManager : MonoBehaviour
    {
        public static EasyUiToolManager Instance;

        [Header("指定UI组件的父组件")]
        public Transform EasyUiRootTransform;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("存在两个EasyUiToolManager管理类");
                return;
            }
            Instance = this;
        }

    }
}
