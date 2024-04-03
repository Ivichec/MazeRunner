using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTp : MonoBehaviour
{
    public Transform signosMapa;
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
        other.transform.position = new Vector3 (6, 0, -80);
        signosMapa.gameObject.SetActive(false);
    }
}
