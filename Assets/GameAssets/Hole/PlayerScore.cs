using System.ComponentModel.Design.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 1;

    public void OnTriggerEnter(Collider col)
    {


        if (col.tag == "prop")
        {
            Prop prop = col.GetComponent<Prop>();
            Debug.Log($"Player Score: {playerScore}. Prop ThresholdScore: {prop.propThresholdScore}");
            if (playerScore >= prop.propThresholdScore)
                prop.UnfreezeRigidbody();
        }
    }
}
