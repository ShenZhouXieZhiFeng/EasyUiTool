# EasyUiTool
EasyUiTool简单易的UI小面板框架，内置了一些常用的面板，使用组件池管理所有的小工具组件。
------- 
目前添加组件有：
------- 
AlertDialog <br><br>
![AlertDialog](https://raw.githubusercontent.com/ShenZhouXieZhiFeng/EasyUiTool/master/ReadMe/AlertDialog.png)  <br>
使用方式 
```c#
//加载一个AlertDialog
AlertDialog aDialog = DialogBuilder.GetDialog(UiType.AlertDialog) as AlertDialog;
//内容
aDialog.SetTitle("test标题")
    .SetMessage("这是test的内容")
    .SetNegativeButton("取消",() =>
    {
        Debug.Log("Click Negative Button");
    })
    .SetPositiveButton("确定",() =>
    {
        Debug.Log("Click Positive Button");
    });
//设置动画类型
aDialog.SetAnimation(UiAnimationType.Zoom, 0.5f, UiAnimationType.Zoom, 0.5f);
aDialog.Show();
```
InputDialog<br><br>
![InputDialog](https://raw.githubusercontent.com/ShenZhouXieZhiFeng/EasyUiTool/master/ReadMe/InputDialog.png)  <br>
使用方式 
```c#
InputDialog iDialog = DialogBuilder.GetDialog(UiType.InputDialog) as InputDialog;
iDialog.SetTitle("请输入一个数字")
    .SetInputType(UnityEngine.UI.InputField.ContentType.IntegerNumber)
    .SetCloseButton(() =>
    {
        Debug.Log("关闭输入框");
    })
    .SetConfirmButton((string inputStr) =>
    {
        Debug.Log(string.Format("你输入了{0}", inputStr));
    });
iDialog.Show();
```
