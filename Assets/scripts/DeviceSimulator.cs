using UnityEngine;

public class DeviceSimulator : MonoBehaviour {
	public DeviceController deviceController;//插槽
	public float temperatureChangeSpeed = 2f;//输入框
	public float speedChangeSpeed = 100f;//输入框


    void Start () {
		
	}
	
	
	void Update () {
		if (deviceController == null || deviceController.deviceData == null)//插槽or数据是不是空
		{
			return;
		}
		DeviceData data=deviceController.deviceData;
		if (data.isRunning)//设备开启时
		{
			data.temperature += Random.Range(-0.1f, 0.1f) * temperatureChangeSpeed * Time.deltaTime;
			//+=：累加到当前的温度上
            data.temperature = Mathf.Clamp(data.temperature, 20f, 80f);
			//Mathf.Clamp(当前值, 最小值, 最大值)：这是一个钳制函数
            data.speed=Mathf.MoveTowards(data.speed,1200f,speedChangeSpeed*Time.deltaTime);
			//Mathf.MoveTowards(当前值, 目标值, 单步最大变化量)：这是一个“平滑靠近”函数。
        }
		else//设备关闭时
		{
			data.speed=Mathf.MoveTowards(data.speed,0f,speedChangeSpeed*Time.deltaTime);
		}
	}
}
