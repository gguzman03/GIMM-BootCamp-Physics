using UnityEngine;
using System.Collections;

public class DodgeRoll : MonoBehaviour
{
    //refers to the object type Movement2D, which in itself is defined by an existing script
    private Movement2D move;

    bool canRoll = false;

    public int cooldownTime = 0;

    [SerializeField] float boost = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        move = GetComponent<Movement2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("right click");

            if (!canRoll){
                Debug.Log("Roll was false. Rolling...");
                canRoll = true;
                Dodge();
            }
        }
        
    }
    public void Dodge()
    {
        move.Dodger(boost);
        StartCoroutine(coolDown());

    }

    public IEnumerator coolDown()
    {
        //pause for .1 seconds before doing anything else
        yield return new WaitForSeconds(.1f);


        float sd = boost - (boost * 2);
        //actually dodge by this much
        move.Dodger(sd);

        //wait again, but this time implementing the cooldown mechanic in doing so
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(cooldownTime);

        canRoll= false;


    }



}
