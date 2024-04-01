using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamasElasticas : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
        RaycastHit hit;
        bool resultado = Physics.Raycast(ray, out hit, 0.5f);

        if (resultado)
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            if (hit.collider.CompareTag("CuadradoSalto"))
            {
                rb.velocity = Vector3.zero;

                float _fuerzaSalto = Mathf.Sqrt(1f * -1.5f * Physics.gravity.y);
                rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.VelocityChange);
            }
        }
    }
}
