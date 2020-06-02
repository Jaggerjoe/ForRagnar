using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
   public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float xPos = Random.Range(-1f, 1f) * magnitude;
            float zPos = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(xPos, originalPos.y, zPos);
            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
