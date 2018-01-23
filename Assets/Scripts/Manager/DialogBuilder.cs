using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUiTool
{
    /// <summary>
    /// 对话框构建类
    /// </summary>
    public static class DialogBuilder
    {
        /// <summary>
        /// Dialog对象池
        /// </summary>
        private static Dictionary<DialogType, DialogBase> dialogPool = new Dictionary<DialogType, DialogBase>();

        public static DialogBase GetDialog(DialogType type)
        {
            if (EasyUiToolManager.Instance.EasyUiRootTransform == null)
            {
                Debug.LogError("未指定EasyUiRootTransform");
                return null;
            }
            if (dialogPool.ContainsKey(type))
            {
                DialogBase dialog = dialogPool[type];
                dialog.ResetDialog();
                return dialog;
            }
            //如果池中不存在，则进行创建
            GameObject dialogPrefab = Resources.Load("Dialogs/AlertDialog") as GameObject;
            if (dialogPrefab == null)
            {
                Debug.LogError("缺少" + type.ToString() + "预制体");
                return null;
            }
            GameObject newGo = Object.Instantiate(dialogPrefab);
            newGo.transform.parent = EasyUiToolManager.Instance.EasyUiRootTransform;
            DialogBase newDialog = newGo.GetComponent<DialogBase>();
            if (newDialog)
            {
                Debug.LogError(type.ToString() + "预制体上缺少Dialog组件");
                return null;
            }
            dialogPool.Add(type, newDialog);
            return newDialog;
        }

        /// <summary>
        /// 清空Dialog池，并销毁所有的实例对象
        /// </summary>
        public static void ClearPool()
        {
            foreach (DialogType type in dialogPool.Keys)
            {
                DialogBase dialog = dialogPool[type];
                Object.Destroy(dialog.gameObject);
            }
            dialogPool.Clear();
        }
       
    }
}
