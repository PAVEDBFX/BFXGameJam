using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField]
    public Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    public void HandleHealthChanged(float pct)
    {
        //foregroundImage.fillAmount = pct;
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foregroundImage.fillAmount = pct;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}