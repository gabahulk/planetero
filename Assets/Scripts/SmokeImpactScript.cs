using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeImpactScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        float secondsPassed = 0;
        float secondsTillDestruction = 4;

        while (secondsPassed < secondsTillDestruction)
        {
            yield return 0;
            secondsPassed += Time.deltaTime;
        }

        Destroy(this.gameObject);
    }
}
