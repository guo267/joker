using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogmove : MonoBehaviour
{
    public Transform PosA,PosB;
    private Transform MovePos;
    [SerializeField] private float MoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        MovePos = PosA;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PosA.position) < 1)
        {
            MovePos = PosB;
            transform.localScale = new Vector2(-2.2398f, 2.3076f);
        }
        if (Vector2.Distance(transform.position, PosB.position) < 1)
        {
            MovePos = PosA;
            transform.localScale = new Vector2(2.2398f, 2.3076f);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, MovePos.position, MoveSpeed * Time.deltaTime);

    }
}
