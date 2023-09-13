using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtonShot : MonoBehaviour
{
    private Rigidbody rb;
    public float force = -200.0f;
    public float destroyAfter = 3;
    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.childCount>=0)
        rb = this.transform.GetChild(0).GetComponent<Rigidbody>();

        Destroy(this.gameObject, destroyAfter);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb!=null)
        rb.AddRelativeForce(new Vector3(0, 0, force));
    }
}
