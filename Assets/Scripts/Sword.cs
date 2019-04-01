using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Material capMaterial;

    public Transform middlePoint;

    private Cuttable edge1Hit;
    private Cuttable edge2Hit;

    private bool canCut = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void edgeHit(int id,  Cuttable gameObject)
    {
        if (canCut)
        {
            if (id == 1)
            {
                edge1Hit = gameObject;
            }
            else if (id == 2)
            {
                edge2Hit = gameObject;
            }
            if (edge1Hit != null && edge2Hit != null)
            {
                if (edge1Hit.Equals(edge2Hit))
                {
                    cut();
                }
            }
        }
    }


    private void cut() {
        edge1Hit = null;
        edge2Hit = null;

        RaycastHit hit;

        if (Physics.Raycast(middlePoint.position, middlePoint.forward, out hit))
        {
            GameObject cuttingObject = hit.collider.gameObject;
            if (!cuttingObject.GetComponent<Cuttable>())
            {
                return;
            }
            GameObject[] pieces = MeshCut.Cut(cuttingObject, transform.position, transform.right, capMaterial);

            pieces[0].GetComponent<Cuttable>().cut();

            if (!pieces[1].GetComponent<Rigidbody>())
            {
                pieces[1].AddComponent<Rigidbody>();
            }
            if (!pieces[1].GetComponent<Collider>())
            {
                pieces[1].AddComponent<MeshCollider>().convex = true;
            }
            pieces[1].AddComponent<Cuttable>();
            pieces[1].transform.parent = pieces[0].transform;
        }
    }
}
