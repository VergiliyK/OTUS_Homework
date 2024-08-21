using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TestScript : MonoBehaviour
{
    public GameObject _character;


    private void Start()
    {
        Test1();
    }

    private void Test1()
    {
        GameObject newCharacter = Instantiate(_character, new Vector3(), new Quaternion());
        HealthComponent health = newCharacter.GetComponent<HealthComponent>();
        newCharacter.SetActive(true);
        StartCoroutine(TestDeath(health));
    }

    public IEnumerator TestDeath(HealthComponent health)
    {

        for (int i = 0; i < 10; i++)
        {
            health.TakeDamage(15);
            Debug.Log(health.Health);
            yield return new WaitForSeconds(1);
        }
    }

}
