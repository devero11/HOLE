using UnityEngine;

public class Prop : MonoBehaviour
{
  public int thresholdScore;
  public int score =1;
  private Rigidbody rb;

  public void UnfreezeRigidbody()
  {
    rb = GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.None;
  }

}
