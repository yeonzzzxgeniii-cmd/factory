using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceAlarmEffect : MonoBehaviour {
	public DeviceController deviceController;//插槽：放入设备
	private Renderer deviceRenderer;//当前物体上的渲染组件，用来修改颜色
    private Color originalColor;//记录设备最开始的颜色，方便报警结束后恢复

    // Use this for initialization
    void Start ()
	{
		deviceRenderer= GetComponent<Renderer>();
		if(deviceRenderer!=null)
		{
            //获取成功，就把当前材质颜色保存到 originalColor 里
            originalColor = deviceRenderer.material.color;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
        //逻辑或||：有一个为 true，整个结果就是 true；只有两边都是 false 时，结果才是 false
        if (deviceController == null || 
			deviceController.deviceData == null ||
			deviceRenderer == null)
		{
			return;
		}
		
		DeviceData data = deviceController.deviceData;

		if (data.isAlarm)
		{
			deviceRenderer.material.color=Color.red;
		}

		else if (data.isRunning)
		{
			deviceRenderer.material.color= Color.green;
		}
		else
		{
			deviceRenderer.material.color = originalColor;
		}
	}
}
