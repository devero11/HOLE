using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public PlayerScore playerScore;
    public Transform player;
    public const float holeSizeIncrease = 0.5f;
    public int nextLevelScore = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "prop")
        {
            playerScore.playerScore += col.GetComponent<Prop>().propValue;
            if (playerScore.playerScore - nextLevelScore / 2 > nextLevelScore)
            {
                nextLevelScore += 25;
                player.localScale += new Vector3(1, 1, 1) * holeSizeIncrease;
            }
            //Has to be replaced with a reset for respawning the object
            Destroy(col.gameObject);
        }
    }
}
