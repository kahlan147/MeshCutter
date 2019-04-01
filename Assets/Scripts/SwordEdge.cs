using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEdge : MonoBehaviour
{
    public int id;

    public Sword sword;

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
        if (other.gameObject.GetComponent<Cuttable>().canBeCut())
        {
            sword.edgeHit(id, other.GetComponent<Cuttable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Cuttable>())
        {
            sword.edgeHit(id, null);
        }
    }
}
