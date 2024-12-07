using UnityEngine;

public class Prop : MonoBehaviour
{
  public int thresholdScore;
  private Rigidbody rb;
  private Collider propCollider;

  void Start()
  {
    thresholdScore = 500; // Score required to consume this object
    rb = GetComponent<Rigidbody>();
    propCollider = GetComponent<Collider>();
  }

  public void UpdateCollisionMask(int playerLayer)
  {
    gameObject.layer = playerLayer;
  }

  public void UnfreezeRigidbody()
  {
    rb.constraints = RigidbodyConstraints.None;
  }

  public void FreezeRigidbody()
  {
    rb.constraints = RigidbodyConstraints.FreezePositionY;
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log($"OnTriggerEnter Triggered for {other.gameObject.tag}");

    if (other.CompareTag("Untagged"))
    {
      GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
      playerController player = playerObject.GetComponent<playerController>();

      if (player.score >= thresholdScore)
      {
        Debug.Log($"Player Score: {player.score}, Threshold: {thresholdScore}");
        player.score += thresholdScore; // - just for testing purposes -  Will need to update score only when consumed not on trigger
        player.UpdateSizeBasedOnScore(); // - just for testing purposes -  Will need to update score only when consumed not on trigger

        UnfreezeRigidbody();
        rb.useGravity = true;
        UpdateCollisionMask(playerObject.gameObject.layer);
      }
      else
      {
        FreezeRigidbody();
        Debug.Log($"Object's threshold is higher than the player's score!");
      }
    }
  }

  void OnTriggerExit(Collider other)
  {
    Debug.Log($"OnTriggerExit triggered for {other.gameObject.name}");

    if (other.CompareTag("Untagged"))
    {
      other.gameObject.layer = 1; // Reset to Ground Layer
    }
  }
}
