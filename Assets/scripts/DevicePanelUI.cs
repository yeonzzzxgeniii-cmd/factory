using UnityEngine;
using UnityEngine.UI;

public class DevicePanelUI : MonoBehaviour {
	public Text deviceNameText;//插槽
	public void ShowDevice(DeviceData data)//定义一个公开的方法：接收一个类为DeviceData的data参数
	{
		if (data == null)
		{
			deviceNameText.text = "尚未选择设备";
			return;//如果为空，终止方法

        /*怎么判断要不要 return？
	1.有返回值时：如果你方法定义的返回值不是 void（比如是 int, string 等），你必须用 return 返回一个结果。
	2.提前退出时（你代码里的情况）：如果你在执行过程中发现条件不满足（比如数据是空的、玩家血量是0了），不想让后面的代码继续执行，
		就可以提前写一个 return; 来直接结束方法。*/

		}
		deviceNameText.text="设备名称："+ data.deviceName;//不为空才会继续执行
	}
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
}
