using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrbInteraction : MonoBehaviour
{
    public  int OrbCount = 0;

    public TextMeshProUGUI Points;

    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
            OrbCount++;
            Points.SetText("Puntuación: " + OrbCount);

            if (OrbCount == 5)
            {
                WinPanel.SetActive(true);
            }
        }
    }
}
