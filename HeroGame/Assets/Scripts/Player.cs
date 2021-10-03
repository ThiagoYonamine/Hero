
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _life;

    Animator _animator;
    Rigidbody2D _playerRb;
    Vector2 _moveAmount;

    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            if (_life <= 0)
            {
                //Todo change destroy
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveAmount = moveInput.normalized * _speed;
        _animator.SetBool("running", _moveAmount != Vector2.zero);
    }

    private void FixedUpdate()
    {
        _playerRb.MovePosition(_playerRb.position + _moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        Life -= damageAmount;
    }
}
