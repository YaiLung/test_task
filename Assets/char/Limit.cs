using UnityEngine;
// записка, для поднятия нужно нажать клавишу, надпись уведомляющая что ее можно нажать появится при столкновении BC, внутри есть панель(картинка) на ней размещается текст, для этого в картинке есть еще text(legasy) с сообщением
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

