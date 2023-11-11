using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraShakeEffect : MonoBehaviour
{
    public static CameraShakeEffect instance;
    //public static float _durationTimer = 0;
    private static bool _isShaking;
    public static bool IsShaking => _isShaking;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    //private void FixedUpdate()
    //{
    //    _durationTimer += 0.07f;
    //}

    private static IEnumerator Shake(float duration, Vector2 positionOffsetLimits)
    {
        Debug.Log($"������ ������� �������� � :({Thread.CurrentThread}) ������");
        _isShaking = true;
        Vector3 origin = instance.transform.position;
        float _durationTimer = 0;

        //Shake Loop
        instance.transform.position = origin;
        _isShaking = false;

        while (_durationTimer < duration)
        {
            //Create a random offset within the limits from the parameter
            Vector2 offset = new Vector2(
                Random.Range(-positionOffsetLimits.x, positionOffsetLimits.x),
                Random.Range(-positionOffsetLimits.y, positionOffsetLimits.y)
                );

            origin = instance.transform.position;
            //Set transform.position to original position + offset
            instance.transform.position = origin + (Vector3)offset;

            //Increase _durationTimer
            _durationTimer += Time.deltaTime;

            //Wait for some time until next position change should happen
            //yield return new WaitForSecondsRealtime(duration);
            yield return null;
        }
    }

    public void StartShaking(float duration, Vector2 posOffsetLimits) =>
        instance.StartCoroutine(Shake(duration, posOffsetLimits));
}
