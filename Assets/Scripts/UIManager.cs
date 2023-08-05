using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI _bulletCountText;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Subject>().AddObserver(this);

        _bulletCountText.text = ($"���������� ����: {_bulletCountText}");
        _healthText.text = ($"��������: {_healthText}");
    }

    public void OnNotify(GameObject obj, int damage)
    {
        if (obj.CompareTag("Player"))
        {
            _healthText.text = "��������: " + obj.GetComponent<PlayerController>().Health.ToString();
        }
        else if (obj.CompareTag("Enemy"))
        {
            // do something with enemy health display
        }
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _bulletCountText.text = "���������� ����: " + player.GetComponent<PlayerController>().BulletCount.ToString();
        _healthText.text = "��������: " + player.GetComponent<PlayerController>().Health.ToString();
    }
}