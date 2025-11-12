using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
          GameObject parent = transform.parent.gameObject;
          Animation animation = parent.GetComponent<Animation>();
          AudioSource da = GetComponent<AudioSource>();
          animation.Play("OpenDoor");  
          da.Play();
        }
        
    }
}
