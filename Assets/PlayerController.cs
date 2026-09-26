using UnityEngine;

public class PlayerController : MonoBehaviour {
	private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * Vector3.right * 10f, Space.Self);
    }
}
