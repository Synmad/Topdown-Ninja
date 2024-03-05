using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour, IDamageable
{
    PlayerMovement movement;
    PlayerAttack attack;
    PlayerDamageFlash damageFlash;

    SpriteRenderer sprite;

    public static Action onPlayerAttack;
    public static Action onPlayerHurt;

    [SerializeField] public int maxHealth;
    [SerializeField] public int curHealth;

    Material defaultMaterial;
    [SerializeField] Material flashMaterial;
    [SerializeField] float flashDuration;
    Coroutine flashCoroutine;

    [SerializeField] bool immune;
    [SerializeField] float immunityDuration;

    void Awake() 
    { 
        movement = GetComponent<PlayerMovement>(); attack = GetComponent<PlayerAttack>(); damageFlash = GetComponent<PlayerDamageFlash>(); sprite = GetComponent<SpriteRenderer>(); defaultMaterial = sprite.material;
        curHealth = maxHealth;
    }

    void Update()
    {
        movement.MovementControls(); attack.AttackUpdate(); attack.ShurikenUpdate();

        if (Input.GetKeyDown(KeyCode.Space)) attack.Katana();
        if (Input.GetMouseButtonDown(0)) attack.Shuriken(); 
    }
    void FixedUpdate()
    {
        if (attack.attacking == false) movement.MovementPhysics();
    }

    public void TakeDamage(int damageAmount, GameObject attacker)
    {
        if (immune) { return; }
        curHealth -= damageAmount;
        onPlayerHurt?.Invoke();
        StartCoroutine(movement.Knockback(1f, 40, attacker.transform));
        DamageFlash();
        StartCoroutine(ImmunityCoroutine());
        if (curHealth <= 0) { SceneManager.LoadScene("Defeat"); }
    }

    void DamageFlash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        sprite.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = defaultMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = defaultMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        sprite.material = defaultMaterial;
        flashCoroutine = null;
    }
    IEnumerator ImmunityCoroutine()
    {
        immune = true;
        yield return new WaitForSeconds(immunityDuration);
        immune = false;
    }
}