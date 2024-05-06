using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Explosion—ontroller _explosion—ontroller;

    private void OnMouseDown()
    {
        _explosion—ontroller.SpawnNewCubes(gameObject);
        Destroy(gameObject);
    }

    //private void FixedUpdate()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hitInfo;
    //        if (Physics.Raycast(ray, out hitInfo))
    //        {
    //            Debug.Log("smt");
    //            if (hitInfo.collider.gameObject.tag == "Cubes")
    //            {
    //                Debug.Log("tag");

    //            }
    //        }
    //    }
    //}
}
