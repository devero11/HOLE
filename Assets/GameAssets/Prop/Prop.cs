using UnityEngine;

public class Prop : MonoBehaviour
{
  public int propThresholdScore = 500;
  public int propValue = 1;
  private Rigidbody rb;

  public void UnfreezeRigidbody()
  {
    rb = GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.None;
  }
}
