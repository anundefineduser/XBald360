namespace BaldiEngine.Player
{
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController cc;

        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float sensitivity;

        private Vector3 movementVelocity;

        private void Update()
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivity, 0f, Space.World);
            MovePlayer();
        }

        private void MovePlayer()
        {
            movementVelocity = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            if (movementVelocity.sqrMagnitude > 1f) movementVelocity.Normalize();
            movementVelocity *= walkSpeed;
            cc.Move(movementVelocity * Time.deltaTime);
        }
    }

}