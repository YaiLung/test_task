using UnityEngine;
// Лимит для передвижения чтобы не выпасть за карту
public class Limit : MonoBehaviour
{
    [SerializeField] private Vector2 planeSize = new Vector2(25f, 25f); // Размер 

    private void LateUpdate()
    {
       
        float halfWidth = planeSize.x / 2f;
        float halfLength = planeSize.y / 2f;

        // Ограничиваем позицию персонажа в пределах площадки
        float clampedX = Mathf.Clamp(transform.position.x, -halfWidth, halfWidth);
        float clampedZ = Mathf.Clamp(transform.position.z, -halfLength, halfLength);

        // Применяем ограничение
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}