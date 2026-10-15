using UnityEngine;
using UnityEngine.UI;

public class DevicePanelUI : MonoBehaviour {
	public Text deviceNameText;//插槽
	public Text temperatureText;//插槽
    public Text speedText;//插槽
    public Text statusText;//插槽
    public GameObject deviceInfoContent;//插槽

    private DeviceData currentData;//用来存储当前正在显示的设备数据对象
    void Start()
    {
        ShowNoDevice();
		deviceInfoContent.SetActive(false);// 将设备信息内容面板设置为隐藏
    }

    public void ShowDevice(DeviceData data)//定义一个公开的方法：接收一个类为DeviceData的data参数
	{
		if (data == null)
		{
			ShowNoDevice();// 如果数据为空，就调用方法显示“尚未选择设备”的默认状态
            return;//提前退出
        }
		deviceInfoContent.SetActive (true);
		currentData = data;
		UpdatePanel();//调用下面方法，刷新一次

	}

    /*怎么判断要不要 return？
1.有返回值时：如果你方法定义的返回值不是 void（比如是 int, string 等），你必须用 return 返回一个结果。
2.提前退出时（你代码里的情况）：如果你在执行过程中发现条件不满足（比如数据是空的、玩家血量是0了），不想让后面的代码继续执行，
    就可以提前写一个 return; 来直接结束方法。*/

    public void ShowNoDevice()
	{
		currentData=null;
		deviceNameText.text = "尚未选择设备";
		temperatureText.text = "温度：---";
		speedText.text = "转速：---";
		statusText.text = "状态：---";

	}
    void Update()
	{
		if (currentData != null)// 判断当前是否有有效的设备数据
        {
			UpdatePanel();// 如果有数据，每一帧都调用刷新面板的方法--实时显示动态变化数据
        }
	}

	void UpdatePanel()
	{
		deviceNameText.text = "设备名称:" + currentData.deviceName;
		temperatureText.text = "温度:" + currentData.temperature.ToString("F2") + "℃";
		speedText.text = "转速:" + currentData.speed.ToString("F0") + "rpm";
		statusText.text = "状态:" + (currentData.isRunning ? "运行中" : "已停止");
	}
}
