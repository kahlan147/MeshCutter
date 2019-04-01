using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Material capMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit)){

                GameObject[] pieces = MeshCut.Cut(hit.collider.gameObject, transform.position, transform.right, capMaterial);

                if (!pieces[1].GetComponent<Rigidbody>())
                {
                    pieces[1].AddComponent<Rigidbody>();
                }
                if (!pieces[1].GetComponent<Collider>())
                {
                    pieces[1].AddComponent<MeshCollider>().convex = true;
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
        Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward*5.0f);
        Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);
    }
}
