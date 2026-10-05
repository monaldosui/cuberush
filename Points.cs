using UnityEngine;
using TMPro;
using System.Collections;

public class Points : MonoBehaviour
{
    public int score = 0;
    public GameObject pointGlitter;
    public TextMeshProUGUI scoreText;
    public GameObject redExplosion;
    public Cubespawner cubeSpawner;

    public Color normalColor = Color.white;
    public Color gainColor = Color.green;
    public Color loseColor = Color.red;

    public float flashDuration = 0.25f;

    private Coroutine flashCoroutine;

    private void Start()
    {
        scoreText.color = normalColor;
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blue"))
        {
            score += 10;

            Instantiate(
                pointGlitter,
                collision.transform.position,
                Quaternion.identity
            );

            cubeSpawner.SpawnCube();
            Destroy(collision.gameObject);

            FlashScore(gainColor);
        }
        else if (collision.gameObject.CompareTag("Red"))
        {
            score -= 5;

            Instantiate(
                redExplosion,
                collision.transform.position,
                Quaternion.identity
            );

            cubeSpawner.SpawnCube();
            Destroy(collision.gameObject);

            FlashScore(loseColor);
        }

        UpdateScoreText();

        Debug.Log("Score: " + score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void FlashScore(Color flashColor)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashScoreCoroutine(flashColor));
    }

    private IEnumerator FlashScoreCoroutine(Color flashColor)
    {
        scoreText.color = flashColor;

        yield return new WaitForSeconds(flashDuration);

        scoreText.color = normalColor;
    }
}