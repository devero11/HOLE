using UnityEngine;

public class UpdateScore : MonoBehaviour
{

    public PlayerScore playerScore;
    public Transform player;
    public const float sizeIncrease = 0.5f;
    public int nextTreshhold = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "prop"){
            playerScore.score += col.GetComponent<Prop>().score;
            if(playerScore.score-nextTreshhold/2> nextTreshhold){
                nextTreshhold += 25;
                player.localScale += new Vector3(1,1,1) * sizeIncrease;
            }
            //Has to be replaced with a reset for respawning the object
            Destroy(col.gameObject);
        }
    }
}
