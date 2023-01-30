using UnityEngine;

public class CHARACTER_CAMERA : MonoBehaviour
{
    public float mouseSensivity, thirdPersonDistance;
    public Transform parent, cam;

    private float xRotation;
    private bool thirdPerson;

    private void Update()
    {
        if (Input.GetMouseButton(1)) MouseRotation();

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (thirdPerson) cam.localPosition = Vector3.zero;
            else cam.Translate(0, 0, -thirdPersonDistance);

            thirdPerson = !thirdPerson;
        }
    }

    private void MouseRotation()
    {
        var mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mouse *= mouseSensivity / Screen.width * 100000 * Time.deltaTime;

        xRotation -= mouse.y;
        xRotation = Mathf.Clamp(xRotation, thirdPerson ? -19 : -45, 45);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        parent.Rotate(Vector3.up * mouse.x);
    }
}