using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Creation : MonoBehaviour
{
    [SerializeField] Transform body;
    [SerializeField] Settings.SO_Settings_Balance settings;
    [SerializeField] GameObject mobPrefab;

    float appearanceTime = 2f;
    float size;

    private void Start()
    {
        size = settings.Boss_Size;
        body.localScale = Vector3.zero;
        StartCoroutine(AppearanceCoroutine());
    }

    IEnumerator AppearanceCoroutine()
    {
        float timer = 0f;
        while (timer < appearanceTime)
        {
            timer += Time.deltaTime;
            //Debug.Log(size * timer / appearanceTime);
            body.localScale = size * Vector3.one * timer / appearanceTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Instantiate(mobPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}