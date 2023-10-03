using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BulletsPool : MonoBehaviour
{   
    [SerializeField] private int _capacity;

    private List<GameObject> _bullets = new List<GameObject>();
    private Camera _camera;    

    protected void Init(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    protected bool TryGetBullet(out GameObject bullet)
    {
        bullet = _bullets.FirstOrDefault(bullet => bullet.activeSelf == false);

        return bullet != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 rightDisablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        Vector3 leftDisablePoint = _camera.ViewportToWorldPoint(new Vector2(1, 0.5f));
                
        foreach (var bullet in _bullets)
        {
            if (bullet.activeSelf == true)
            {
                if (bullet.transform.position.x < rightDisablePoint.x || bullet.transform.position.x > leftDisablePoint.x)
                    bullet.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var bullet in _bullets)
        {
            bullet.SetActive(false);
        }
    }
}
