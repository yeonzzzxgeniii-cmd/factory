using System;

[Serializable]
public class DeviceData
    //没有继承 : MonoBehaviour意味着它不是一个脚本组件，不能挂载到游戏物体上。它只存在于代码里，用来被其他脚本使用。
{
    public string deviceName;
    public float temperature = 25f;
    public float speed = 0f;
    public bool isRunning = true;
    /*在别的脚本里面定义这个类：public DeviceData deviceA;  
     * 就会出现在此脚本的Inspector 面板里，并且自动展开成：
            Device Name (文本框)
            Temperature (数字框，默认25)
            Speed (数字框，默认0)
            Is Running (勾选框)*/
}
