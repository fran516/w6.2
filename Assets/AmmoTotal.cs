using UnityEngine;
using UnityEngine.UI;

public class AmmoTotal : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ammoValue = player.GetComponent<CollectAmmoBox>().ammo;
        Text text = GetComponent<Text>();
        text.text = ammoValue.ToString();
    }
}
