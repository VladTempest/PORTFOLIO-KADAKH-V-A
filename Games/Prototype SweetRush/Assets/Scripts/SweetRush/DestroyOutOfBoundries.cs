using UnityEngine;


namespace SweetRush
{
    public class DestroyOutOfBoundries : MonoBehaviour
    {
        [SerializeField]
        private float _minXCoordinateTillDestroy = -25f;
        [SerializeField]
        private float _minYCoordinateTillDestroy = -10f;

        // Update is called once per frame
        private void Update()
        {
            if (transform.position.x < _minXCoordinateTillDestroy || transform.position.y < _minYCoordinateTillDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}