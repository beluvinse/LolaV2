using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBulletFactory : MonoBehaviour
{
    //public static BulletFactory Instance
    //{
    //    get
    //    {
    //        return _instance;
    //    }
    //}
    //static BulletFactory _instance;

    public static ZombieBulletFactory Instance { get; private set; }

    [SerializeField] ZombieBullet _bulletPrefab;
    [SerializeField] int _bulletStock = 5;

    ObjectPool<ZombieBullet> _pool;

    void Start()
    {
        Instance = this;

        //Creo un nuevo pool pasandole:
        //1.- La funcion que contiene la logica de instanciar el objeto (factoryMethod)
        //2.- La funcion que contiene la logica de que hacer al pedir el objeto (turnOnCallback)
        //3.- La funcion que contiene la logica de que hacer al devolver el objeto (turnOffCallback)
        //4.- La cantidad de objetos que se crearan en un principio
        //5.- Si es dinamico o no
        _pool = new ObjectPool<ZombieBullet>(BulletCreator, ZombieBullet.TurnOn, ZombieBullet.TurnOff, _bulletStock);

        //_pool = new ObjectPool<Bullet>(() => Instantiate(_bulletPrefab), (x) => x.gameObject.SetActive(true), (x) => x.gameObject.SetActive(false), 3);
    }

    //Funcion que contiene la logica de la creacion de la bala
    ZombieBullet BulletCreator()
    {
        return Instantiate(_bulletPrefab, transform);
    }

    //Funcion que va a ser llamada cuando se pida un objeto
    public ZombieBullet GetObject()
    {
        return _pool.GetObject();
    }

    //Funcion que va a ser llamada cuando el objeto tenga que ser devuelto al Pool
    public void ReturnBullet(ZombieBullet b)
    {
        _pool.ReturnObject(b);
    }
}
