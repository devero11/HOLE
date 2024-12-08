using System.ComponentModel.Design.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{   

    public int score = 1;




    public void OnTriggerEnter(Collider col){
        if(col.tag == "prop")
        {
            Prop prop = col.GetComponent<Prop>();
            if(score >= prop.thresholdScore)
                prop.UnfreezeRigidbody();
        }
    }
}
