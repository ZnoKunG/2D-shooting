using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;

    private void Awake()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

}
