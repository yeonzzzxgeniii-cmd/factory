using UnityEngine;

public class ClickDiagnostic : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("【检测1】检测到鼠标左键点击");

            Camera cam = Camera.main;

            if (cam == null)
            {
                Debug.LogError("【检测错误】没有找到 Main Camera，请检查摄像机 Tag");
                return;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.Log("【检测2】射线命中物体：" + hit.collider.name);

                DeviceController controller =
                    hit.collider.GetComponent<DeviceController>();

                if (controller == null)
                {
                    controller =
                        hit.collider.GetComponentInParent<DeviceController>();
                }

                if (controller != null)
                {
                    Debug.Log("【检测3】找到了 DeviceController：" +
                        controller.gameObject.name);
                }
                else
                {
                    Debug.LogWarning("【检测3】命中了物体，但没有找到 DeviceController");
                }
            }
            else
            {
                Debug.LogWarning("【检测2】射线没有命中任何 3D 碰撞体");
            }
        }
    }
}