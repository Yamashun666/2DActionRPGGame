using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] GameObject explodedFire;
    private EnemyBase _enemyHP;
    public float fireSpeed = default;
    private Vector3 direction;
    private float power = default;
    public float deleteTime = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FireGenerate(float _power)
    {
        power = _power;

        Vector3 MousePosition = Input.mousePosition;
        Vector3 screenPosition = transform.position;
        screenPosition = Camera.main.ScreenToWorldPoint(MousePosition);

        direction = screenPosition - this.transform.position;
        direction.z = 0;
        direction = Vector3.Normalize(direction);

        StartCoroutine(DeleteCount());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * fireSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            _enemyHP = hit.GetComponent<EnemyBase>();
            _enemyHP.enemyCurrentHP -= power;
            for (int i = 0; i < 5; i++)
            {
                GameObject fire = Instantiate(explodedFire, this.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Debug.Log(_enemyHP.enemyCurrentHP);
        }
        
    }
    IEnumerator DeleteCount()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
