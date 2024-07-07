using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class PlayerControll : MonoBehaviour
{
    public float PlayerSpeed;
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;
    private Rigidbody rbd;
    private int Count;
    private float XMovement;
    private float YMovement;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        rbd=this.GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }


    // Update is called once per frame
    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();
        XMovement = MovementVector.x;
        YMovement = MovementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 Movement=new Vector3(XMovement,0.0f,YMovement);

        rbd.AddForce(Movement*PlayerSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Count++;
            SetCountText();
        }
        
    }

    void SetCountText()
    {
        CountText.text = "Count:" + Count.ToString();
        if (Count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
   
}


//void OnMove(InputValue MovementValue)
//Vector2 MovementVector = MovementValue.Get<Vector2>();
//XMovement = MovementVector.x;
//YMovement = MovementVector.y;
//Vector3 Movement = new Vector3(XMovement, 0.0f, YMovement);

//rbd.AddForce(Movement);