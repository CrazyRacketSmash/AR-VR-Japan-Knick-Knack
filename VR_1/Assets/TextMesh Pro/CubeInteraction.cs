using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public Animator unityChanAnimator;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    unityChanAnimator.Play("unitychan_JUMP00");
                }
            }
        }
    }
}