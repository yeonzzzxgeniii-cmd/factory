using UnityEngine;
using UnityEngine.UI;

public class DevicePanelUI : MonoBehaviour {
	public Text deviceNameText;//插槽
	public Text temperatureText;//插槽
    public Text speedText;//插槽
    public Text statusText;//插槽
    
	public GameObject deviceInfoContent;//插槽
	public Button startButton;//插槽
    public Button stopButton;//插槽

    private DeviceData currentData;//用来存储当前正在显示的设备数据对象
	private DeviceController currentController;// 用来存储当前正在显示的设备控制器（用于在 UI 上反向调用控制设备启动或停止）
    void Start()
    {
        ShowNoDevice();//游戏开始调用默认的“未选择”状态
    }

    public void ShowDevice(DeviceData data)//定义一个公开的方法：接收一个类为DeviceData的data参数
	{
		currentData = data;
		currentController = null;

        DeviceController[] controllers = FindObjectsOfType<DeviceController>();
        //寻找所有挂载了 DeviceController 脚本的对象，返回一个数组

        foreach (DeviceController controller in controllers)
		{
			if (controller.deviceData == data)
			{
				currentController = controller;
				break;// 跳出循环
            }
		}
		if (data == null)
		{
			ShowNoDevice();// 如果数据为空，就调用方法显示“尚未选择设备”的默认状态
            return;//结束方法
        }
		deviceInfoContent.SetActive (true);
		UpdatePanel();//调用下面方法，刷新一次
        UpdateButtons();

    }

    /*怎么判断要不要 return？
1.有返回值时：如果你方法定义的返回值不是 void（比如是 int, string 等），你必须用 return 返回一个结果。
2.提前退出时（你代码里的情况）：如果你在执行过程中发现条件不满足（比如数据是空的、玩家血量是0了），不想让后面的代码继续执行，
    就可以提前写一个 return; 来直接结束方法。*/

    public void ShowNoDevice()
	{
		currentData=null;
		currentController = null;

		deviceInfoContent.SetActive(true);

		deviceNameText.text = "尚未选择设备";
		temperatureText.text = "温度：---";
		speedText.text = "转速：---";
		statusText.text = "状态：---";

		UpdateButtons();
	}

	public void OnStartButtonClick()
	{
		if (currentController != null)
		{
			currentController.StartDevice();
			UpdatePanel();	
			UpdateButtons();
		}
	}
    public void OnStopButtonClick()
    {
        if (currentController != null)
        {
            currentController.StopDevice();
            UpdatePanel();
            UpdateButtons();
        }
    }
    void Update()
	{
		if (currentData != null && currentController != null)// 判断当前是否有有效的设备数据
        {
			UpdatePanel();// 如果有数据，每一帧都调用刷新面板的方法--实时显示动态变化数据
			UpdateButtons();
        }
	}

	void UpdatePanel()
	{
		deviceNameText.text = "设备名称:" + currentData.deviceName;
		temperatureText.text = "温度:" + currentData.temperature.ToString("F2") + "℃";
		speedText.text = "转速:" + currentData.speed.ToString("F0") + "rpm";
		statusText.text = "状态:" + (currentData.isRunning ? "运行中" : "已停止");
	}

	void UpdateButtons()
	{
		bool hasDevice=currentData != null && currentController != null;//当前data和controller都不为空

		if (startButton != null)//如果为空，安静跳过
		{
			startButton.interactable = hasDevice && !currentData.isRunning;//必须选中了有效设备+没有在运行（! 是取反）
        }
		if (stopButton != null)
		{
			stopButton.interactable = hasDevice && currentData.isRunning;
		}
    }
}
