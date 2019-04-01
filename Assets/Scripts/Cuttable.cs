using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{

    private bool canCut = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position += transform.up * 0.1f;
        StartCoroutine(cutTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cut()
    {
        StartCoroutine(cutTimer());
        Destroy(GetComponent<Collider>());
        this.gameObject.AddComponent<MeshCollider>().convex = true;
    }

    public bool canBeCut()
    {
        return canCut;
    }


    private IEnumerator cutTimer()
    {
        canCut = false;
        yield return new WaitForSeconds(.5f);
        canCut = true;
    }
}
