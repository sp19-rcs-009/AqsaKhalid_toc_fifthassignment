using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject theSphere;
   
    public Text CountText;
    private Rigidbody rb;
    //string  revs = "";
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
       
        
        if (other.gameObject.CompareTag("Pick Up"))
        {   
            string objectName = other.gameObject.name;
            char c = objectName.Last();
            string sphere = ("Sphere" + c);
            string revs="";
         Text   name = GameObject.Find(sphere + "/Canvas/Text").GetComponent<Text>();
             string myst = name.text.ToString();
            for (int i = myst.Length - 1; i >= 0; i--) //String Reverse  
            {
                revs += myst[i].ToString();
            }
            Debug.Log(revs.Equals(myst));
            Debug.Log("revs  "+revs);
            Debug.Log("myst  "+revs);

            if ((string.Equals(myst, revs))==true) // Checking whether string is palindrome or not  
            {   
                theSphere = GameObject.Find(sphere);
                other.gameObject.SetActive(false);
                theSphere.SetActive(false);
                count = count + 1;
            }
           Debug.Log(count);
        }
        setCountText();
    }
    void setCountText()
    {
        CountText.text = count.ToString() + "  Total Palindrome";
    }
}
