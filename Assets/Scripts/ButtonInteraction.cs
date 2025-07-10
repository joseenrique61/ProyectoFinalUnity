using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public float InitialYPlatformPosition;

    public float FinalYPlatformPosition;

    public Transform Platform;

    private OrbInteraction OrbInteraction;

    // Start is called before the first frame update
    void Start()
    {
        OrbInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<OrbInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && OrbInteraction.OrbCount == 4)
        {
            StartCoroutine(LowerAndRaisePlatform());
        }
    }

    private IEnumerator ChangePlatformPosition(bool up)
    {
        float end = up ? InitialYPlatformPosition : FinalYPlatformPosition;
        if (!up)
        {
            while (Platform.position.y - end > 0)
            {
                Platform.position = new Vector3(Platform.position.x, Platform.position.y - 0.1f, Platform.position.z);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            while (Platform.position.y - end < 0)
            {
                Platform.position = new Vector3(Platform.position.x, Platform.position.y + 0.1f, Platform.position.z);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private IEnumerator LowerAndRaisePlatform()
    {
        StartCoroutine(ChangePlatformPosition(false));

        yield return new WaitForSeconds(10);

        StartCoroutine(ChangePlatformPosition(true));
    }
}
