using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { Speed, Jump, Score }
    public PickupType type;
    public float rotateSpeed = 90f;
    public float speedDuration = 5f;
    public float jumpDuration = 30f;
    public float respawnTime = 30f;
    public int scoreAmount = 1;
    private Collider col;
    private MeshRenderer mesh;

    void Start()
    {
        col = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CharacterMovement player = other.GetComponent<CharacterMovement>();

        switch (type)
        {
            case PickupType.Speed:
                StartCoroutine(SpeedBoost(player));
                break;

            case PickupType.Jump:
                StartCoroutine(JumpBoost(player));
                break;

            case PickupType.Score:
                GameManager.Instance.AddScore(scoreAmount);
                Debug.Log("Score pickup collected! Score = " + GameManager.Instance.score);
                break;
        }

        if (type == PickupType.Score)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(RespawnRoutine());
        }
    }

    IEnumerator SpeedBoost(CharacterMovement player)
    {
        float originalMultiplier = player.runMultiplier;
        player.runMultiplier *= 1.3f;

        yield return new WaitForSeconds(speedDuration);

        player.runMultiplier = originalMultiplier;
    }

    IEnumerator JumpBoost(CharacterMovement player)
    {
        player.hasDoubleJumpPower = true;

        yield return new WaitForSeconds(jumpDuration);

        player.hasDoubleJumpPower = false;
    }

    IEnumerator RespawnRoutine()
    {
        col.enabled = false;
        mesh.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        col.enabled = true;
        mesh.enabled = true;
    }


}
