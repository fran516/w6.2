using UnityEngine;

public class CollectAmmoBox : MonoBehaviour
{
    public int ammo;
    public AudioSource audio;
    public AudioClip reload;
    public AudioClip empty;
    public AudioClip full;
    public AudioClip bridgeDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //If you left click and amno is greater than 0 the ammo will go down.
        if (Input.GetButtonDown("Fire1") && ammo > 0) {
            ammo--;
            audio.clip = full;
            audio.Play();
           
            //Setting the Origin and Direction to the RedDot. 
            Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
            RaycastHit result; 

            //Casts a ray in the position and direction defined.
            Physics.Raycast(ray, out result);

            //The object that has been hit is called g.
            GameObject g = result.collider.gameObject;
            //Returns the name of the object that has been hit.
            Debug.Log(""+g.name);

            //If the object that has been hit is the target. The bridge will lower by playing the animation.
            if (g.name == "Target") {
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
                audio.clip = reload;     
            }
       } 
        else if (Input.GetButtonDown("Fire1") && ammo == 0) {
           audio.clip = bridgeDown;
           audio.Play();
       }
    }

    void OnTriggerEnter(Collider other) {
        //Collision with a specific object.
        if (other.gameObject.name == "AmmoBox") {
            ammo = 20;
            audio.clip = reload;
            audio.Play();
            //.SetActive(false) disables the object.
            other.gameObject.SetActive(false);
       }


    }
    
}
