using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;

    private List<Vector2> _points = new List<Vector2>();

    void Start()
    {
        _collider.transform.position -= transform.position;
    }

    // Criando o caminho da linha
    public void SetPosition(Vector2 pos) 
    {
        if (!CanAppend(pos)) return;

        _points.Add(pos);

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount-1, pos);

        _collider.points = _points.ToArray(); // Adicionando colisor
    }

    // Acresenta nova posi��o da linha.
    // Nova posi��o n�o pode ser maior que a RESOLUTION
    public bool CanAppend(Vector2 pos)
    {
        if(_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }
}
