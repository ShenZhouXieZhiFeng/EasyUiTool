﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUiTool
{
    public static class EasyUiDefaultConfig
    {
        /// <summary>
        /// dialog预制体在resources中的路径,以/结尾
        /// </summary>
        public const string UiPrefabPath = "UiPrefabs/";

        #region 默认配置
        public const UiAnimationType DefaultAnimationType = UiAnimationType.Fade;
        public const float DefaultAnimationTime = 0.5f;

        public const string DefaultTitle = "TITLE";
        public const string DefaultMsg = "MESSAGE";
        public const string DefaultCancelDesc = "CANCEL";
        public const string DefaultConfirmDesc = "CONFIRM";

        public const float DefaultMessageShowTime = 2f;
        public const float DefaultMessageBoxMaxWidth = 800;
        public const float DefaultMessageBoxMaxHeight = 600;
        public const float DefaultWaitBoxRotateSpeed = 10f;

        public const string DefaultChooseTitle = "Enter Your CHOOSE";
        public const string DefaultPrograssTitle = "Loading...";

        public const string DefaultImageDialogTitle = "IMAGE SHOW";

        #endregion

    }

}