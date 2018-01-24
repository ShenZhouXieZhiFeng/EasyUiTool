using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUiTool
{
    public class ListChooseDialog : UiBase
    {
        private Button  btnClose,btnConfirm;
        private Text txtTitle;
        private Dropdown dropList;

        private Action actionClose;
        private Action<int> actionConfirm;

        private void Awake()
        {
            init();
        }
        void init()
        {
            btnClose = transform.Find("btnClose").GetComponent<Button>();
            btnConfirm = transform.Find("down/btnConfirm").GetComponent<Button>();
            txtTitle = transform.Find("up/txtTitle").GetComponent<Text>();
            dropList = transform.Find("down/dropList").GetComponent<Dropdown>();

            btnClose.onClick.AddListener(() =>
            {
                if (actionClose != null)
                    actionClose();
                Close();
            });
            btnConfirm.onClick.AddListener(() =>
            {
                if (actionConfirm != null)
                {
                    actionConfirm(dropList.value);
                }
                Close();
            });

            ResetSelf();
        }

        #region set

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ListChooseDialog SetTitle(string title)
        {
            txtTitle.text = title;
            return this;
        }

        /// <summary>
        /// 设置选择列表
        /// </summary>
        /// <param name="chooseList"></param>
        /// <returns></returns>
        public ListChooseDialog SetDropList(string[] chooseList)
        {
            dropList.ClearOptions();
            if (chooseList != null && chooseList.Length != 0)
            {
                List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
                for (int i = 0; i < chooseList.Length; i++)
                {
                    Dropdown.OptionData data = new Dropdown.OptionData();
                    data.text = chooseList[i];
                    options.Add(data);
                }
                dropList.AddOptions(options);
            }
            return this;
        }

        /// <summary>
        /// 设置关闭回调事件
        /// </summary>
        /// <param name="closeAction"></param>
        /// <returns></returns>
        public ListChooseDialog SetCloseAction(Action closeAction)
        {
            actionClose = closeAction;
            return this;
        }

        /// <summary>
        /// 设置确定回调事件
        /// </summary>
        /// <param name="confirmAction"></param>
        /// <returns></returns>
        public ListChooseDialog SetConfirmAction(Action<int> confirmAction)
        {
            actionConfirm = confirmAction;
            return this;
        }

        #endregion

        #region override

        public override void ResetSelf()
        {
            base.ResetSelf();
            actionClose = null;
            actionConfirm = null;

            SetTitle(EasyUiDefaultConfig.DefaultChooseTitle);
            SetDropList(null);
            dropList.value = 0;
        }

        #endregion

    }
}
