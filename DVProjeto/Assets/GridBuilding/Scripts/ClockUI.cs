using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{

    private const float REAL_SECONDS_PER_INGAME_DAY = 30f;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private Text timeText;
    private float day;
    private bool isPlaying;

    private void Awake()
    {
        clockHourHandTransform = transform.Find("hourHand");
        clockMinuteHandTransform = transform.Find("minuteHand");
        timeText = transform.Find("timeText").GetComponent<Text>();
        isPlaying = true;
    }

    private void Update()
    {
        if (isPlaying)
        {
            day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

            float dayNormalized = day % 1f;

            float rotationDegreesPerDay = 360f;
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

            float hoursPerDay = 24f;
            clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

            string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

            float minutesPerHour = 60f;
            string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

            timeText.text = hoursString + ":" + minutesString;
        }

    }

    public void StopTime()
    {
        isPlaying = false;
    }

    public void ResumeTime()
    {
        isPlaying = true;
    }
}
