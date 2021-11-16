using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SmartPhoneManager : MonoBehaviour
{
    static string timeFormat12Hour = "h:mm tt";
    static string timeFormat24Hour = "H:mm";
    string timeString;

    [SerializeField] NetworkManager networkManager;
    [SerializeField] GameObject window;
    [SerializeField] public bool isVisible;
    [SerializeField] public bool isAnimating;
    [SerializeField] TMP_Text textTime;
    [SerializeField] string currentTimeFormat = timeFormat24Hour;
    [SerializeField] bool use24HourTime = true;
    [SerializeField] float lerpDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        window.transform.localScale = Vector3.zero;
        isVisible = false;
        isAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (use24HourTime)
            currentTimeFormat = timeFormat24Hour;
        else
            currentTimeFormat = timeFormat12Hour;

        timeString = System.DateTime.Now.ToString(currentTimeFormat);
        textTime.text = timeString;
    }

    public void OpenSmartPhoneWindow()
    {
        isVisible = true;
        Vector3 targetScale = Vector3.one;
        StartCoroutine(LerpSmartPhoneWindow(targetScale));
    }

    public void CloseSmartPhoneWindow()
    {
        isVisible = false;
        Vector3 targetScale = Vector3.zero;
        StartCoroutine(LerpSmartPhoneWindow(targetScale));
    }

    public void HostButtonClick()
    {
        networkManager.CreateRoom();
    }

    public void JoinButtonClick()
    {
        networkManager.JoinRoom();
    }

    IEnumerator LerpSmartPhoneWindow(Vector3 targetScale)
    {
        float timeElapsed = 0;
        isAnimating = true;
        Vector3 currentScale = window.transform.localScale;

        while (timeElapsed < lerpDuration)
        {
            float lerpTime = timeElapsed / lerpDuration;
            lerpTime = lerpTime * lerpTime * (3f - 2f * lerpTime);
            window.transform.localScale = Vector3.Lerp(currentScale, targetScale, lerpTime);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        window.transform.localScale = targetScale;
        isAnimating = false;
    }
}
