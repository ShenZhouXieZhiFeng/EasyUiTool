namespace EasyUiTool
{

    /// <summary>
    /// 组件类型
    /// </summary>
    public enum UiType
    {
        /// <summary>
        /// 警告对话框
        /// </summary>
        AlertDialog,
        /// <summary>
        /// 输入框
        /// </summary>
        InputDialog,
        /// <summary>
        /// 列表选择框，单选
        /// </summary>
        ListChooseDialog,
        /// <summary>
        /// 进度条弹出框
        /// </summary>
        ProgressDialog,
        /// <summary>
        /// 信息框
        /// </summary>
        MessageBox,
        /// <summary>
        /// 图片窗口
        /// </summary>
        ImageDialog,
        /// <summary>
        /// 视频查看列表
        /// </summary>
        VideoDialog,
        /// <summary>
        /// 等待进度圈
        /// </summary>
        WaitBox,
        /// <summary>
        /// 倒计时
        /// </summary>
        CountDownBox
    }

    /// <summary>
    /// UI动画类型
    /// </summary>
    public enum UiAnimationType
    {
        /// <summary>
        /// 渐变
        /// </summary>
        Fade,
        /// <summary>
        /// 缩放
        /// </summary>
        Zoom
    }

}