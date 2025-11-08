using UnityEngine;
using Unity.Cinemachine;

public class DoorCameraSwitcher : MonoBehaviour
{
    public CinemachineCamera prevCam; // 문 열리기 전 카메라
    public CinemachineCamera lastCam; // 마지막으로 보여줄 카메라

    // 애니메이션 이벤트에서 이 함수 호출
    public void OnDoorOpened()
    {
        if (lastCam != null)
            lastCam.Priority.Value = 20; // Last 카메라 우선순위 ↑

        if (prevCam != null)
            prevCam.Priority.Value = 10; // 이전 카메라 우선순위 ↓
    }
}
