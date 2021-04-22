using UnityEngine;

public class Pacdot : MonoBehaviour {

	public GameManager GM;
    private void Start()
    {
		GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "pacman")
		{
		    GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
			Destroy(gameObject);

		    if (pacdots.Length < 150)
		    {
				GM.Win();
		    }
		}
	}
}
