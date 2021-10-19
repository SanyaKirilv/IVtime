using UnityEngine;

public class Eagle : MonoBehaviour {
    public WinGame WG;
    public AudioSource eagleDestroy;
    public AudioSource gameOver;
    public Transform player1;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Transform other = collider.GetComponent<Transform>();

        if (other.name.Contains("Bullet") && !other.GetComponent<Animator>().GetBool("hit") && !gameObject.GetComponent<Animator>().GetBool("isDestroyed"))
        {
            other.GetComponent<Animator>().SetBool("hit", true);
            gameObject.GetComponent<Animator>().SetBool("isDestroyed", true);
            eagleDestroy.Play();
            
            this.DoAfter(1, () => gameOver.Play());
        }
    }
    private void FinishGame()
    {
        player1.SendMessage("SetLevel", 7);
        player1.SendMessage("SetLives", 3);
        player1.SendMessage("SetIsTemplate", false);
        gameObject.SendMessage("LoadMap", 7);
        WG.FinishGame();
    }
}
