using UnityEngine;
using UnityEngine.UI;

public class DeviceDetection : MonoBehaviour
{
    [SerializeField] private Canvas CanvasGamepad;
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            CanvasGamepad.gameObject.SetActive(true);
            Debug.Log("Игра запущена на мобильном устройстве.");
        }
        else
        {
            Debug.Log("Игра запущена на компьютере.");
        }
    }
}

