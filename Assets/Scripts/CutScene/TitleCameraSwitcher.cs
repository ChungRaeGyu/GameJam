using UnityEngine;
using Unity.Cinemachine;  // 중요!

public class TitleCameraSwitcher : MonoBehaviour
{
    public CinemachineCamera titleCam;
    public CinemachineCamera zoomCam;

    public void OnStartButtonPressed()
    {
        // 줌인 카메라를 우선순위 높게
        zoomCam.Priority.Value = 20;
        // 타이틀 카메라는 낮게
        titleCam.Priority.Value = 10;
    }
}
