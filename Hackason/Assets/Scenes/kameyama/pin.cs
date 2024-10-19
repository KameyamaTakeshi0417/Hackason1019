using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pin : MonoBehaviour
{
    public int addScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnCollisionEnter(Collision collision){
if(collision.gameObject.tag=="Player"){
    GameObject.Find("scoreManager").GetComponent<score>().AddScore(addScore);
}

   }
}
