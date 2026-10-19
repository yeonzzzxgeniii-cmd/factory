using UnityEngine;

public class DeviceController : MonoBehaviour
{
    public DeviceData deviceData;//序列化：直接显示编辑
    public DevicePanelUI panelUI;//插槽
    private void Awake()
    {
        if (deviceData == null)
        {
            deviceData = new DeviceData();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("当前点击设备：" + deviceData.deviceName);
        if (panelUI != null)
        {
            panelUI.ShowDevice(deviceData);
        }
    }

    public void StartDevice()
    {
        deviceData.isRunning = true;//直接修改deviceData
        if (panelUI != null)
        {
            panelUI.ShowDevice(deviceData);//调用ShowDevice,并传入deviceData
        }
    }

    public void StopDevice()
    {
        deviceData.isRunning = false;
        if (panelUI != null)
        {
            panelUI.ShowDevice(deviceData);
        }
    }
}
